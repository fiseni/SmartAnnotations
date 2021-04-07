using FluentAssertions;
using SmartAnnotations.Internal;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class AnnotationBuilderExtensions_Required
    {
        [Fact]
        public void SetsRequiredDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Required();

            descriptor.Required.Should().NotBeNull();
        }

        [Fact]
        public void SetsRequiredDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Required(typeof(AttributeTestResource));

            descriptor.Required.Should().NotBeNull();
            descriptor.Required!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsRequiredDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Required(typeof(AttributeTestResource));

            descriptor.Required.Should().NotBeNull();
            descriptor.Required!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsRequiredDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Required();

            descriptor.Required.Should().NotBeNull();
            descriptor.Required!.ModelResourceType.Should().Be(typeof(ModelTestResource));
        }
    }
}
