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
    public class ValidationParametersGenerator_GetContent
    {
        [Fact]
        public void ReturnsErrorMessageOnly_GivenAllParameters()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = ValidationParametersGenerator.Instance;

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsErrorMessageOnly_GivenMessageAndResourceType()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
            };

            var generator = ValidationParametersGenerator.Instance;

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsErrorMessageOnly_GivenMessageAndKey()
        {
            var descriptor = new ValidationAttributeDescriptor()
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = ValidationParametersGenerator.Instance;

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsKeyAndResourceType_GivenResourceAndKey()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = ValidationParametersGenerator.Instance;

            var expected = @"ErrorMessageResourceName = ""SomeErrorKey"", ErrorMessageResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource)";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenResourceOnly()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName);

            var generator = ValidationParametersGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenKeyOnly()
        {
            var descriptor = new ValidationAttributeDescriptor()
            {
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = ValidationParametersGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenEmptyDescriptor()
        {
            var descriptor = new ValidationAttributeDescriptor();

            var generator = ValidationParametersGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
