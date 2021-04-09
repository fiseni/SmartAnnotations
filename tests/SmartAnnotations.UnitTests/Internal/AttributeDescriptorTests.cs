using FluentAssertions;
using SmartAnnotations.Internal;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Internal
{
    public class AttributeDescriptorTests
    {
        [Fact]
        public void ReturnsAttributeResourceType_GivenAttributeAndModelResourceTypeParameters()
        {
            var descriptor = new TestDescriptor(typeof(AttributeTestResource).FullName, typeof(ModelTestResource).FullName);

            descriptor.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            descriptor.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            descriptor.HasResourceType.Should().BeTrue();
            descriptor.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void ReturnsAttributeResourceType_GivenOnlyAttributeResourceTypeParameter()
        {
            var descriptor = new TestDescriptor(typeof(AttributeTestResource).FullName);

            descriptor.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            descriptor.ModelResourceType.Should().BeNull();
            descriptor.HasResourceType.Should().BeTrue();
            descriptor.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void ReturnsModelResourceType_GivenNullAttributeResourceTypeParameter()
        {
            var descriptor = new TestDescriptor(null, typeof(ModelTestResource).FullName);

            descriptor.AttributeResourceType.Should().BeNull();
            descriptor.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            descriptor.HasResourceType.Should().BeTrue();
            descriptor.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }

        [Fact]
        public void ReturnsNull_GivenNoParameters()
        {
            var descriptor = new TestDescriptor();

            descriptor.AttributeResourceType.Should().BeNull();
            descriptor.ModelResourceType.Should().BeNull();
            descriptor.HasResourceType.Should().BeFalse();
            descriptor.GetResourceTypeFullName().Should().BeNull();
        }
    }
}
