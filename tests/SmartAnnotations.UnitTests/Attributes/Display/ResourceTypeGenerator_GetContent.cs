using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class ResourceTypeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeAndModelResourceTypeAndSomeOfTheStringPatametersHaveValue()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource).FullName, typeof(ModelTestResource).FullName) { Description = "SomeDescription" };
            var generator = ResourceTypeGenerator.Instance;

            var expected = @"ResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource)";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeResourceTypeAndSomeOfTheStringPatametersHaveValue()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource).FullName) { Description = "SomeDescription" };
            var generator = ResourceTypeGenerator.Instance;

            var expected = @"ResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource)";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithModelResource_GivenHasModelResourceTypeAndSomeOfTheStringPatametersHaveValue()
        {
            var descriptor = new DisplayAttributeDescriptor(null, typeof(ModelTestResource).FullName) { Description = "SomeDescription" };
            var generator = ResourceTypeGenerator.Instance;

            var expected = @"ResourceType = typeof(SmartAnnotations.UnitTests.Fixture.ModelTestResource)";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasNoResourceType()
        {
            var descriptor = new DisplayAttributeDescriptor();
            var generator = ResourceTypeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasResourceTypeAndHasNoStringParameters()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var generator = ResourceTypeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
