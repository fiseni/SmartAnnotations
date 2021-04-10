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
    public class AnnotationBuilderExtensions_Min
    {
        [Fact]
        public void SetsMinLengthDescriptorWithLength_GivenLengthValue()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Min(10);

            var attributeDescriptor = annotationDescriptor.Get<MinLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.Length.Should().Be(10);
        }

        [Fact]
        public void SetsMinLengthDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Min(10);

            var attributeDescriptor = annotationDescriptor.Get<MinLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
        }

        [Fact]
        public void SetsMinLengthDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Min(10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<MinLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsMinLengthDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Min(10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<MinLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsMinLengthDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Min(10);

            var attributeDescriptor = annotationDescriptor.Get<MinLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
