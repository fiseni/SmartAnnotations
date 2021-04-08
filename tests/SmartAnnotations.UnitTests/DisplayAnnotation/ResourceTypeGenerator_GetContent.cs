using FluentAssertions;
using SmartAnnotations.DisplayAnnotation;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class ResourceTypeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeAndModelResourceTypeAndSomeOfTheStringPatametersHaveValue()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource), typeof(ModelTestResource)) { Description = "SomeDescription" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ResourceType = typeof(AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeResourceTypeAndSomeOfTheStringPatametersHaveValue()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource)) { Description = "SomeDescription" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ResourceType = typeof(AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithModelResource_GivenHasModelResourceTypeAndSomeOfTheStringPatametersHaveValue()
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
        public void ReturnsEmptyContent_GivenHasResourceTypeAndHasNoStringParameters()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource));
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
