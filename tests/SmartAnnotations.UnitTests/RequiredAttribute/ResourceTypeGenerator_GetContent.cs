using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAttribute
{
    public class ResourceTypeGenerator_GetContent
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }

        [Fact]
        public void ReturnsAttributeResourceTypeContent_GivenHasAttributeAndModelResourceTypeAndSomeOfTheStringPatametersHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource), typeof(ModelTestResource)) { Description = "SomeDescription" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ResourceType = typeof(AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsAttributeResourceTypeContent_GivenHasAttributeResourceTypeAndSomeOfTheStringPatametersHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource)) { Description = "SomeDescription" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ResourceType = typeof(AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsModelResourceTypeContent_GivenHasModelResourceTypeAndSomeOfTheStringPatametersHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor(null, typeof(ModelTestResource)) { Description = "SomeDescription" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ResourceType = typeof(ModelTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasNoResourceType()
        {
            var descriptor = new DisplayAttributeDescriptor();
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasResourceTypeHasNoStringParameters()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource));
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
