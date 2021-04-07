using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.ValidationAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ValidationAttribute
{
    public class ResourceTypeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeAndModelResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource), typeof(ModelTestResource)) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ErrorMessageResourceType = typeof(AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource)) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ErrorMessageResourceType = typeof(AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithModelResource_GivenHasModelResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(null, typeof(ModelTestResource)) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"ErrorMessageResourceType = typeof(ModelTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasNoResourceType()
        {
            var descriptor = new ValidationAttributeDescriptor();
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasResourceTypeAndHasNoErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource));
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
