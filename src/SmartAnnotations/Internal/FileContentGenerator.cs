using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class FileContentGenerator : IContentGenerator
    {
        private readonly AnnotationContext context;

        internal FileContentGenerator(AnnotationContext context)
        {
            this.context = context;
        }

        public string GetContent()
        {
            var output = string.Empty;

            foreach (var descriptor in context.Descriptors)
            {
                var content = new AnnotationGenerator(descriptor.Value).GetContent();
                if (!string.IsNullOrEmpty(content))
                {
                    output = string.IsNullOrEmpty(output) ? content : $"{output}{Environment.NewLine}{content}";
                }
            }

            return GetFileContent(output);
        }

        private string GetFileContent(string innerContent)
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
            , context.Type.Namespace, context.Type.Name, innerContent);

            return content;
        }
    }
}
