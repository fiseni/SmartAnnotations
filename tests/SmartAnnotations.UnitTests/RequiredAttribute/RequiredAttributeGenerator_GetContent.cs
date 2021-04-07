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
        public void ReturnsEmptyContent_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
