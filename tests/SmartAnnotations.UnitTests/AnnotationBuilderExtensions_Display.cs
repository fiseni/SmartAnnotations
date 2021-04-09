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
    public class AnnotationBuilderExtensions_Display
    {
        [Fact]
        public void SetsDisplayDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Display();

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
        }

        [Fact]
        public void SetsDisplayDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Display(typeof(AttributeTestResource));

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsDisplayDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Display(typeof(AttributeTestResource));

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsRequiredDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Display();

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
