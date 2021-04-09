using FluentAssertions;
using SmartAnnotations.RequiredAnnotation;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAnnotation
{
    public class RequiredAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsRequiredAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                AllowEmptyStrings = true,
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = @"[Required(AllowEmptyStrings = true, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = new RequiredAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
