using FluentAssertions;
using SmartAnnotations.Attributes.Url;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Url
{
    public class UrlAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsUrlAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new UrlAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = UrlAttributeGenerator.Instance;

            var expected = @"[Url(ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessUrlAttribute_GivenEmptyUrlDescriptor()
        {
            var descriptor = new UrlAttributeDescriptor();

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = UrlAttributeGenerator.Instance;

            var expected = @"[Url()]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullUrlDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = UrlAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
