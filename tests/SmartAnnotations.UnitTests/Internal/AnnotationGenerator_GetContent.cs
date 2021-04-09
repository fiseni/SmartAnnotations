using FluentAssertions;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Internal
{
    public class AnnotationGenerator_GetContent
    {
        [Fact]
        public void ReturnsReadOnlyAndDisplayAttributes_GivenReadOnlyAndDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("TestProperty")
                .Add(new ReadOnlyAttributeDescriptor(true))
                .Add(new DisplayAttributeDescriptor() { Name = "SomeName" });

            var generator = new AnnotationGenerator(annotationDescriptor);

            generator.GetContent().Should().Be(GetContentForReadOnlyAndDisplayAttribute());
        }

        [Fact]
        public void ReturnsReadOnlyAttribute_GivenReadOnlyDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("TestProperty")
                .Add(new ReadOnlyAttributeDescriptor(true));

            var generator = new AnnotationGenerator(annotationDescriptor);

            generator.GetContent().Should().Be(GetContentForReadOnlyAttribute());
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNoDescriptors()
        {
            var annotationDescriptor = new AnnotationDescriptor("TestProperty");
            var generator = new AnnotationGenerator(annotationDescriptor);

            generator.GetContent().Should().Be(string.Empty);
        }

        private string GetContentForReadOnlyAttribute()
        {
            return
@"        [ReadOnly(true)]
        public object TestProperty;
";
        }

        private string GetContentForReadOnlyAndDisplayAttribute()
        {
            return
@"        [ReadOnly(true)]
        [Display(Name = ""SomeName"")]
        public object TestProperty;
";
        }
    }
}
