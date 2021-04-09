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
    public class AnnotationBuilderExtensions_DisplayFormat
    {
        [Fact]
        public void SetsDisplayFormatDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DisplayFormat();

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
        }

        [Fact]
        public void SetsDisplayFormatDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DisplayFormat(typeof(AttributeTestResource));

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsDisplayFormatDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DisplayFormat(typeof(AttributeTestResource));

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
        }

        [Fact]
        public void SetsRequiredDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string), typeof(ModelTestResource));
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DisplayFormat();

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource));
        }
    }
}
