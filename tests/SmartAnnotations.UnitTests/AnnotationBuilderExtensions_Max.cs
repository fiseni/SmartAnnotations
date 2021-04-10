using FluentAssertions;
using SmartAnnotations.Internal;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class AnnotationBuilderExtensions_Max
    {
        [Fact]
        public void SetsMaxLengthDescriptorWithLength_GivenLengthValue()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Max(10);

            var attributeDescriptor = annotationDescriptor.Get<MaxLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.Length.Should().Be(10);
        }

        [Fact]
        public void SetsMaxLengthDescriptorWithNullLength_GivenNullLengthValue()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Max();

            var attributeDescriptor = annotationDescriptor.Get<MaxLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.Length.Should().BeNull();
        }

        [Fact]
        public void SetsMaxLengthDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Max(10);

            var attributeDescriptor = annotationDescriptor.Get<MaxLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
        }

        [Fact]
        public void SetsMaxLengthDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Max(10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<MaxLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsMaxLengthDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Max(10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<MaxLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsMaxLengthDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Max(10);

            var attributeDescriptor = annotationDescriptor.Get<MaxLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
