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
    public class AnnotationBuilderExtensions_Display
    {
        [Fact]
        public void SetsDisplayDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Display();

            descriptor.Display.Should().NotBeNull();
        }

        [Fact]
        public void SetsDisplayDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Display(typeof(AttributeTestResource));

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsDisplayDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Display(typeof(AttributeTestResource));

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsRequiredDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.Display();

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.ModelResourceType.Should().Be(typeof(ModelTestResource));
        }
    }
}
