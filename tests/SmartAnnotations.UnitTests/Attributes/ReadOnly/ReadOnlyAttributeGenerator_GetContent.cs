using FluentAssertions;
using SmartAnnotations.Attributes.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.ReadOnly
{
    public class ReadOnlyAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsReadOnlyAttribute_GivenIsReadOnlyHasValue()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new ReadOnlyAttributeDescriptor(true));

            var generator = new ReadOnlyAttributeGenerator(annotationDescriptor);

            var expected = @"[ReadOnly(true)]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullReadOnlyDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = new ReadOnlyAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
