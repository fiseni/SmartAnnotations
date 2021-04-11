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
    public class AnnotationBuilderExtensions_Length
    {
        [Fact]
        public void SetsStringLengthDescriptorWithMinMax_GivenMinMax()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Length(1, 10);

            var attributeDescriptor = annotationDescriptor.Get<StringLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.MinimumLength.Should().Be(1);
            attributeDescriptor!.MaximumLength.Should().Be(10);
        }

        [Fact]
        public void SetsStringLengthDescriptorWithMaxAndNullMin_GivenMax()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Length(10);

            var attributeDescriptor = annotationDescriptor.Get<StringLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.MinimumLength.Should().BeNull();
            attributeDescriptor!.MaximumLength.Should().Be(10);
        }

        [Fact]
        public void SetsStringLengthDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Length(10);

            var attributeDescriptor = annotationDescriptor.Get<StringLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().BeNull();
            attributeDescriptor!.ModelResourceType.Should().BeNull();
            attributeDescriptor!.HasResourceType.Should().BeFalse();
            attributeDescriptor!.GetResourceTypeFullName().Should().BeNull();
        }

        [Fact]
        public void SetsStringLengthDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Length(1, 10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<StringLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsStringLengthDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Length(10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<StringLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsStringLengthDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Length(10);

            var attributeDescriptor = annotationDescriptor.Get<StringLengthAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
