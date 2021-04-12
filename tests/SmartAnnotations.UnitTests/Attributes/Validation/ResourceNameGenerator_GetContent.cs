using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Validation
{
    public class ResourceNameGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenHasAttributeAndModelResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName, typeof(ModelTestResource).FullName) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = ResourceNameGenerator.Instance;

            var expected = @"ErrorMessageResourceName = ""SomeResourceKey""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenHasAttributeResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = ResourceNameGenerator.Instance;

            var expected = @"ErrorMessageResourceName = ""SomeResourceKey""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsContent_GivenHasModelResourceTypeAndHasErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(null, typeof(ModelTestResource).FullName) { ErrorMessageResourceName = "SomeResourceKey" };
            var generator = ResourceNameGenerator.Instance;

            var expected = @"ErrorMessageResourceName = ""SomeResourceKey""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasErrorMessage()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName, typeof(ModelTestResource).FullName) 
            { 
                ErrorMessage = "SomeMessage",
                ErrorMessageResourceName = "SomeResourceKey" 
            };

            var generator = ResourceNameGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasNoResourceType()
        {
            var descriptor = new ValidationAttributeDescriptor();
            var generator = ResourceNameGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasResourceTypeHasNoErrorMessageResourceName()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var generator = ResourceNameGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
