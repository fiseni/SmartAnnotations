using FluentAssertions;
using SmartAnnotations.ValidationAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ValidationAttribute
{
    public class ResourceNameGenerator_GetContent
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }

        [Fact]
        public void ReturnsContent_GivenHasAttributeAndModelResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource), typeof(ModelTestResource)) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = new ResourceNameGenerator(descriptor);

            var expected = @"ErrorMessageResourceName = ""SomeResourceKey""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenHasAttributeResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource)) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = new ResourceNameGenerator(descriptor);

            var expected = @"ErrorMessageResourceName = ""SomeResourceKey""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenHasModelResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(null, typeof(ModelTestResource)) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = new ResourceNameGenerator(descriptor);

            var expected = @"ErrorMessageResourceName = ""SomeResourceKey""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasNoResourceType()
        {
            var descriptor = new ValidationAttributeDescriptor();
            var generator = new ResourceNameGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasResourceTypeHasNoErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource));
            var generator = new ResourceNameGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
