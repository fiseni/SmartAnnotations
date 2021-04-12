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
        public void ReturnsReadOnlyAttribute_GivenIsReadOnlyTrue()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new ReadOnlyAttributeDescriptor(true));

            var generator = ReadOnlyAttributeGenerator.Instance;

            var expected = @"[ReadOnly(true)]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsReadOnlyAttribute_GivenIsReadOnlyFalse()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new ReadOnlyAttributeDescriptor(false));

            var generator = ReadOnlyAttributeGenerator.Instance;

            var expected = @"[ReadOnly(false)]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullReadOnlyDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = ReadOnlyAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
