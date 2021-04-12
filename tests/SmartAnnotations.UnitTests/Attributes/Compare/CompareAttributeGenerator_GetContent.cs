using FluentAssertions;
using SmartAnnotations.Attributes.Compare;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Compare
{
    public class CompareAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsCompareAttributeWithMessageOnly_GivenOtherPropertyAndAllParameters()
        {
            var descriptor = new CompareAttributeDescriptor("OtherProperty", typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = CompareAttributeGenerator.Instance;

            var expected = @"[Compare(""OtherProperty"", ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullCompareDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = CompareAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
