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
        public void ReturnsDisplayAndReadOnlyAttributes_GivenDisplayAndReadOnlyDescriptor()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string))
            {
                Display = new DisplayAttributeDescriptor() { Name = "SomeName" },
                ReadOnly = new ReadOnlyAttributeDescriptor(true)
            };

            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForDisplayAndReadOnlyAttribute());
        }

        [Fact]
        public void ReturnsDisplayAttribute_GivenDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string))
            {
                Display = new DisplayAttributeDescriptor() { Name = "SomeName" }
            };

            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForDisplayAttribute());
        }

        [Fact]
        public void ReturnsDisplayAttribute_GivenDisplayDescriptorAndAdditionalInvalidDescriptor()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string))
            {
                Display = new DisplayAttributeDescriptor() { Name = "SomeName" },
                ReadOnly = new ReadOnlyAttributeDescriptor(null)
            };

            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForDisplayAttribute());
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNoDescriptors()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string));
            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(string.Empty);
        }

        private string GetContentForDisplayAttribute()
        {
            return
@"        [Display(Name = ""SomeName"")]
        public object TestProperty;
";
        }

        private string GetContentForDisplayAndReadOnlyAttribute()
        {
            return
@"        [ReadOnly(true)]
        [Display(Name = ""SomeName"")]
        public object TestProperty;
";
        }
    }
}
