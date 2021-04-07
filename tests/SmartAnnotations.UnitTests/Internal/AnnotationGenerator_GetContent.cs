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
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string))
            {
                ReadOnly = new ReadOnlyAttributeDescriptor(true),
                Display = new DisplayAttributeDescriptor() { Name = "SomeName" }
            };

            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForReadOnlyAndDisplayAttribute());
        }

        [Fact]
        public void ReturnsReadOnlyAttribute_GivenReadOnlyDescriptor()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string))
            {
                ReadOnly = new ReadOnlyAttributeDescriptor(true)
            };

            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForReadOnlyAttribute());
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNoDescriptors()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string));
            var generator = new AnnotationGenerator(descriptor);

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
