using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
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
        public void ReturnsEmptyLayout_GivenNoDescriptors()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string));
            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(string.Empty);
        }

        [Fact]
        public void ReturnsDisplayAttribute_GivenDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string));
            descriptor.Display = new DisplayAttributeDescriptor() { Name = "SomeName"};
            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForDisplayAttribute());
        }

        [Fact]
        public void ReturnsDisplayAttribute_GivenDisplayDescriptorAndAdditionalInvalidDescriptor()
        {
            var descriptor = new AnnotationDescriptor("TestProperty", typeof(string));
            descriptor.Display = new DisplayAttributeDescriptor() { Name = "SomeName" };
            descriptor.ReadOnly = new ReadOnlyAttributeDescriptor(null);
            var generator = new AnnotationGenerator(descriptor);

            generator.GetContent().Should().Be(GetContentForDisplayAttribute());
        }

        private partial class TestType
        {
            public string? TestProperty { get; set; } = null;
        }
        private class TestAnnotatorEmpty : Annotator<TestType>
        {
        }
        private class TestAnnotatorWithDisplayName : Annotator<TestType>
        {
            public TestAnnotatorWithDisplayName()
            {
                DefineFor(x => x.TestProperty).Display().Name("SomeName");
            }
        }

        private string GetContentForDisplayAttribute()
        {
            return
@"        [Display(Name = ""SomeName"")]
        public object TestProperty;
";
        }
    }
}
