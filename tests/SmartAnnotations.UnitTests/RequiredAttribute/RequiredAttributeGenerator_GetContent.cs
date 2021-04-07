using FluentAssertions;
using SmartAnnotations.RequiredAttribute;
using SmartAnnotations.UnitTests.Fixture;
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
        [Fact]
        public void ReturnsRequiredAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required(ErrorMessage = \"SomeErrorMessage\")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsRequiredAttributeWithMessageOnly_GivenMessageAndResourceType()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required(ErrorMessage = \"SomeErrorMessage\")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsRequiredAttributeWithMessageOnly_GivenMessageAndKey()
        {
            var descriptor = new RequiredAttributeDescriptor()
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required(ErrorMessage = \"SomeErrorMessage\")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsRequiredAttributeWithKeyAndResourceType_GivenResourceAndKey()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required(ErrorMessageResourceName = \"SomeErrorKey\", ErrorMessageResourceType = typeof(AttributeTestResource))]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessRequiredAttribute_GivenResourceOnly()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource));

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required()]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessRequiredAttribute_GivenKeyOnly()
        {
            var descriptor = new RequiredAttributeDescriptor()
            {
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = $"[Required()]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessRequiredAttribute_GivenEmptyRequiredDescriptor()
        {
            var descriptor = new RequiredAttributeDescriptor();
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = descriptor };

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = "[Required()]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
