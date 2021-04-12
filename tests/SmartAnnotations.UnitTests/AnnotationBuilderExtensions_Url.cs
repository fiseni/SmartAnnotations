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
    public class AnnotationBuilderExtensions_Url
    {
        [Fact]
        public void SetsUrlDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Url();

            var attributeDescriptor = annotationDescriptor.Get<UrlAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().BeNull();
            attributeDescriptor!.ModelResourceType.Should().BeNull();
            attributeDescriptor!.HasResourceType.Should().BeFalse();
            attributeDescriptor!.GetResourceTypeFullName().Should().BeNull();
        }

        [Fact]
        public void SetsUrlDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Url(typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<UrlAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsUrlDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Url(typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<UrlAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsUrlDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Url();

            var attributeDescriptor = annotationDescriptor.Get<UrlAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
