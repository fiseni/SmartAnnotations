using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SmartAnnotations.Generators
{
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

            var appDomain = AppDomain.CurrentDomain;
            appDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var assembly = GetAssembly();

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

            //AppDomain.Unload(this.appDomain);
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

        // This is a hack, but it's the easiest way to handle this and load referenced assemblies.
        // Any other approach just gets insane (much stuff not available on .NET Standard 2.0).
        // Compilation.References contain all the referenced assemblies, but only the path to them, not the assembly name. So we're trying to match from args.Name.
        // Also, doing it this way, we don't have to care for the assemblies' TFMs, since the compilation already has handled that part and contains the correct path.
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
