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
    public class AnnotationBuilderExtensions_Required
    {
        [Fact]
        public void SetsRequiredDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(annotationDescriptor);

            annotationBuilder.Required();

            var attributeDescriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
        }

        [Fact]
        public void SetsRequiredDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(annotationDescriptor);

            annotationBuilder.Required(typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsRequiredDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder<string>(annotationDescriptor);

            annotationBuilder.Required(typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsRequiredDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder<string>(annotationDescriptor);

            annotationBuilder.Required();

            var attributeDescriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource));
        }
    }
}
