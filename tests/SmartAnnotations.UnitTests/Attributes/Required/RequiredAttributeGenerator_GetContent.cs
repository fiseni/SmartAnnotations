using FluentAssertions;
using SmartAnnotations.Attributes.Required;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Required
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

            var generator = RequiredAttributeGenerator.Instance;

            var expected = @"[Required(AllowEmptyStrings = true, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = RequiredAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
