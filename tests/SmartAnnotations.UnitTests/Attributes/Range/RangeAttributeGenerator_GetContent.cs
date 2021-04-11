using FluentAssertions;
using SmartAnnotations.Attributes.Range;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Range
{
    public class RangeAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsRangeAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new RangeAttributeDescriptor("SometTypeFullName", "1", "10")
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = new RangeAttributeGenerator(annotationDescriptor);

            var expected = @"[Range(typeof(SometTypeFullName), ""1"", ""10"", ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullRangeDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = new RangeAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
