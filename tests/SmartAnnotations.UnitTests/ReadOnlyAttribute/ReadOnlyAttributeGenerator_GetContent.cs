using FluentAssertions;
using SmartAnnotations.ReadOnlyAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ReadOnlyAttribute
{
    public class ReadOnlyAttributeGenerator_GetContent
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }
        public string? TestProperty { get; set; } = null;

        [Fact]
        public void ReturnsContent_GivenIsReadOnlyHasValue()
        {
            var descriptor = new ReadOnlyAttributeDescriptor(true);
            var annotationDescriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { ReadOnly = descriptor };

            var generator = new ReadOnlyAttributeGenerator(annotationDescriptor);

            var expected = $"[ReadOnly(true)]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullIsReadOnly()
        {
            var descriptor = new ReadOnlyAttributeDescriptor(null);
            var annotationDescriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { ReadOnly = descriptor };

            var generator = new ReadOnlyAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullReadOnlyDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string));

            var generator = new ReadOnlyAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
