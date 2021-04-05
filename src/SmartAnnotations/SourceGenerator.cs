using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using SmartAnnotations.Internal;
using System;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SmartAnnotations
{
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            //Utils.AttachDebugger();
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.Compilation is CSharpCompilation compilation)
            {
                var typeResolver = GetResolver(compilation);
                var allTypes = typeResolver.GetAllTypes();

                //var annotatorTypes = allTypes.Where(x => typeof(AnnotationContext).IsAssignableFrom(x));
                var annotatorTypes = allTypes.Where(x => x.IsSubclassOfRawGeneric(typeof(Annotator<>)));

                foreach (var annotatorType in annotatorTypes)
                {
                    var annotationContext = ((AnnotationContext)Activator.CreateInstance(annotatorType));

                    context.AddSource($"{annotationContext.Type.FullName}Generated", SourceText.From(new FileContentGenerator(annotationContext).GetContent(), Encoding.Unicode));
                }

                typeResolver.UnloadAssemblies();
            }
        }

        private TypeResolver GetResolver(CSharpCompilation compilation)
        {
            return new TypeResolver(compilation);

            // CreateInstanceAndUnwrap is not available for .NET Standard 2.0

            //AppDomain ad = AppDomain.CreateDomain("SourceGenerator");
            //TypeResolver resolver = (TypeResolver)ad.CreateInstanceAndUnwrap(
            //    typeof(TypeResolver).Assembly.FullName,
            //    "TypeResolver");

            //return resolver;
        }
    }
}
