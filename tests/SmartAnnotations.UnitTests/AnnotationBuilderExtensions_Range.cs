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
    public class AnnotationBuilderExtensions_Range
    {
        [Fact]
        public void SetsRangeDescriptorWithMinMax_GivenMinMaxAsInteger()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(1, 10);

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.MinimumAsString.Should().Be("1");
            attributeDescriptor!.MaximumAsString.Should().Be("10");
            attributeDescriptor!.OperandTypeFullName.Should().BeNull();
        }

        [Fact]
        public void SetsRangeDescriptorWithMinMax_GivenMinMaxAsDouble()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(1.0005d, 9.99999);

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.MinimumAsString.Should().Be("1.0005d");
            attributeDescriptor!.MaximumAsString.Should().Be("9.99999d");
            attributeDescriptor!.OperandTypeFullName.Should().BeNull();
        }

        [Fact]
        public void SetsRangeDescriptorWithOperandTypeAndMinMax_GivenTypeAndMinMaxAsString()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(typeof(decimal), "1.5", "10.5");

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.MinimumAsString.Should().Be("\"1.5\"");
            attributeDescriptor!.MaximumAsString.Should().Be("\"10.5\"");
            attributeDescriptor!.OperandTypeFullName.Should().Be(typeof(decimal).FullName);
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            Action action = () => annotationBuilder.Range(null!, "1.5", "10.5");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("type");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrWhiteSpaceMinimum()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            Action action = () => annotationBuilder.Range(typeof(decimal), " ", "10.5");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("minimum");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrWhiteSpaceMaximum()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            Action action = () => annotationBuilder.Range(typeof(decimal), "1.5", " ");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("maximum");
        }

        [Fact]
        public void SetsRangeDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(1, 10);

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().BeNull();
            attributeDescriptor!.ModelResourceType.Should().BeNull();
            attributeDescriptor!.HasResourceType.Should().BeFalse();
            attributeDescriptor!.GetResourceTypeFullName().Should().BeNull();
        }

        [Fact]
        public void SetsRangeDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(1, 10, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsRangeDescriptorWithAttributeResourceType_GivenOperandTypeAndResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(typeof(decimal), "1", "10", typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsRangeDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(1d, 10d, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsRangeDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Range(typeof(decimal), "1", "10");

            var attributeDescriptor = annotationDescriptor.Get<RangeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
