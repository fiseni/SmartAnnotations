using FluentAssertions;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class AnnotationBuilderExtensions_ReadOnly
    {
        [Fact]
        public void SetsReadOnlyDescriptor_GivenValue()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.ReadOnly(true);

            var attributeDescriptor = annotationDescriptor.Get<ReadOnlyAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.IsReadOnly.Should().BeTrue();
        }

        [Fact]
        public void SetsReadOnlyDescriptorWithDefaultValue_GivenNoParameters()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.ReadOnly();

            var attributeDescriptor = annotationDescriptor.Get<ReadOnlyAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.IsReadOnly.Should().BeTrue();
        }
    }
}
