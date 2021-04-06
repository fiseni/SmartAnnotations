using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SmartAnnotations.Internal
{
    // Not yet sure what the final design will be.
    [ExcludeFromCodeCoverage]
    internal class TypeResolver : MarshalByRefObject
    {
        private readonly CSharpCompilation compilation;
        private readonly List<MetadataReference> metadataReferences;

        internal TypeResolver(CSharpCompilation compilation)
        {
            this.compilation = compilation;
            this.metadataReferences = compilation.References.ToList();
        }

        internal Type[] GetAllTypes()
        {
            Type[] output = Array.Empty<Type>();

            //var appDomain = AppDomain.CurrentDomain;
            //appDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var assembly = GetAssembly();
            LoadReferencedAssemblies();

            if (assembly != null)
            {
                output = GetLoadableTypes(assembly);
            }

            return output;
        }

        internal void UnloadAssemblies()
        {
            // There is no way to unload assemblies.
            // We have to create a separate domain, but that will break on .NET Core, it supports single application domain only.
            // Also CreateInstanceAndUnwrap is not available on .NET Standard 2.0
            // This sucks :)

            // AppDomain.Unload(this.appDomain);
        }

        private Type[] GetLoadableTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null).ToArray();
            }
        }

        private Assembly? GetAssembly()
        {
            Assembly? assembly = null;

            using (var memoryStream = new MemoryStream())
            {
                EmitResult result = this.compilation.Emit(memoryStream);

                if (result.Success)
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    assembly = Assembly.Load(memoryStream.ToArray());
                }
            }

            return assembly;
        }

        // Switched to eager loading the missing compilation references.
        // Handling it though AssemblyResolve event is not a smart idea.
        // If there are several open solutions in VS, they all operate in the same app domain, and the handler will be serving all AssemblyResolve events.
        private void LoadReferencedAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Select(x=>x.GetName().Name.ToUpper()).ToList();

            foreach (var reference in this.metadataReferences)
            {
                if (reference.Display != null && !loadedAssemblies.Any(x => reference.Display.ToUpper().Contains($"{x}.DLL")))
                {
                    try
                    {
                        // Some of the assemblies can be loaded for reflection only.
                        // Also, while running through VS, if the project is .NET5 it will fail to load the runtime.
                        Assembly.LoadFrom(reference.Display);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        // This is a hack, but it's the easiest way to handle this and load referenced assemblies.
        // Any other approach just gets insane (much stuff not available on .NET Standard 2.0).
        // Compilation.References contain all the referenced assemblies, but only the path to them, not the assembly name. So we're trying to match from args.Name.
        // Also, doing it this way, we don't have to care for the assemblies' TFMs, since the compilation already has handled that part and contains the correct path.
        // EDIT: Shouldn't be used. It will break VisualStudio since everything runs in CurrentDomain, and this will handle all AssemblyResolve events!
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Equals(args.Name));
            if (loadedAssembly != null) return loadedAssembly;

            var name = args.Name?.Split(',').FirstOrDefault()?.ToUpper();
            if (name != null)
            {
                var path = this.metadataReferences.FirstOrDefault(x => x.Display != null && x.Display.ToUpper().Contains($"{name}.DLL"))?.Display;

                if (path != null)
                {
                    var assembly = Assembly.LoadFrom(path);
                    return assembly;
                }
            }

            return Assembly.Load(args.Name);
        }
    }
}
