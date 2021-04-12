using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class FileContentGenerator
    {
        private FileContentGenerator() { }
        internal static FileContentGenerator Instance { get; } = new();

        public string GetContent(AnnotationContext context)
        {
            var output = string.Empty;

            foreach (var descriptor in context.Descriptors)
            {
                var content = AnnotationGenerator.Instance.GetContent(descriptor.Value);
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}{Environment.NewLine}{content}";
                }
            }

            return GetFileContent(context, output);
        }

        private string GetFileContent(AnnotationContext context, string innerContent)
        {
            var content = string.Format(

@"using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace {0}
{{
    [MetadataType(typeof({1}MetaData))]
    public partial class {1} 
    {{
    }}

    public class {1}MetaData 
    {{
{2}
    }}
}}
"
            , context.TypeNamespace, context.TypeName, innerContent);

            return content;
        }
    }
}
