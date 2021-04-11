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
    public class AnnotationBuilderExtensions_Compare
    {
        [Fact]
        public void SetsCompareDescriptorWithOtherProperty_GivenValidOtherProperty()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Compare("OtherProperty");

            var attributeDescriptor = annotationDescriptor.Get<CompareAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.OtherProperty.Should().Be("OtherProperty");
        }

        [Fact]
        public void ThrowsArgumentException_GivenNullOrEmptyOtherProperty()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            Action action = () => annotationBuilder.Compare(string.Empty);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("otherProperty");
        }

        [Fact]
        public void SetsCompareDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Compare("OtherProperty");

            var attributeDescriptor = annotationDescriptor.Get<CompareAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().BeNull();
            attributeDescriptor!.ModelResourceType.Should().BeNull();
            attributeDescriptor!.HasResourceType.Should().BeFalse();
            attributeDescriptor!.GetResourceTypeFullName().Should().BeNull();
        }

        [Fact]
        public void SetsCompareDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Compare("OtherProperty", typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<CompareAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsCompareDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Compare("OtherProperty", typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<CompareAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsCompareDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Compare("OtherProperty");

            var attributeDescriptor = annotationDescriptor.Get<CompareAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
