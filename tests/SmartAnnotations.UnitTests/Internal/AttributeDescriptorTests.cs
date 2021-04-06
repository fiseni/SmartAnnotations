using FluentAssertions;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.UnitTests.Internal
{
    public class AttributeDescriptorTests
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }
        private class TestDescriptor : AttributeDescriptor
        {
            public TestDescriptor(Type? attributeResourceType = null, Type? modelResourceType = null)
                : base(attributeResourceType, modelResourceType) { }
        }

        public void ReturnsAttributeResourceType_GivenAttributeAndModelResourceTypeParameters()
        {
            var descriptor = new TestDescriptor(typeof(AttributeTestResource), typeof(ModelTestResource));

            descriptor.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
            descriptor.ModelResourceType.Should().Be(typeof(ModelTestResource));
            descriptor.HasResourceType.Should().BeTrue();
            descriptor.GetResourceType().Should().Be(typeof(AttributeTestResource));
            descriptor.GetResourceTypeName().Should().Be(nameof(AttributeTestResource));
        }

        public void ReturnsAttributeResourceType_GivenOnlyAttributeResourceTypeParameter()
        {
            var descriptor = new TestDescriptor(typeof(AttributeTestResource));

            descriptor.AttributeResourceType.Should().Be(typeof(AttributeTestResource));
            descriptor.ModelResourceType.Should().BeNull();
            descriptor.HasResourceType.Should().BeTrue();
            descriptor.GetResourceType().Should().Be(typeof(AttributeTestResource));
            descriptor.GetResourceTypeName().Should().Be(nameof(AttributeTestResource));
        }

        public void ReturnsModelResourceType_GivenNullAttributeResourceTypeParameter()
        {
            var descriptor = new TestDescriptor(null, typeof(ModelTestResource));

            descriptor.AttributeResourceType.Should().BeNull();
            descriptor.ModelResourceType.Should().Be(typeof(ModelTestResource));
            descriptor.HasResourceType.Should().BeTrue();
            descriptor.GetResourceType().Should().Be(typeof(ModelTestResource));
            descriptor.GetResourceTypeName().Should().Be(nameof(ModelTestResource));
        }

        public void ReturnsNull_GivenNoParameters()
        {
            var descriptor = new TestDescriptor();

            descriptor.AttributeResourceType.Should().BeNull();
            descriptor.ModelResourceType.Should().BeNull();
            descriptor.HasResourceType.Should().BeFalse();
            descriptor.GetResourceType().Should().BeNull();
            descriptor.GetResourceTypeName().Should().BeNull();
        }
    }
}
