using FluentAssertions;
using SmartAnnotations.RequiredAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAttribute
{
    public class RequiredAttributeGenerator_GetContent
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }
        public string? TestProperty { get; set; } = null;

        [Fact]
        public void ReturnsFullContent_GivenAllParameters()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };
            var annotationDescriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required(ErrorMessage = \"SomeErrorMessage\", ErrorMessageResourceName = \"SomeErrorKey\", ErrorMessageResourceType = typeof(AttributeTestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessRequiredAttribute_GivenNoParameters()
        {
            var descriptor = new RequiredAttributeDescriptor();
            var annotationDescriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = "[Required()]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string));

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
