using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.ValidationAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ValidationAnnotation
{
    public class ValidationParametersGenerator_GetContent
    {
        [Fact]
        public void ReturnsErrorMessageOnly_GivenAllParameters()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsErrorMessageOnly_GivenMessageAndResourceType()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
            };

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsErrorMessageOnly_GivenMessageAndKey()
        {
            var descriptor = new ValidationAttributeDescriptor()
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsKeyAndResourceType_GivenResourceAndKey()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource))
            {
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = @"ErrorMessageResourceName = ""SomeErrorKey"", ErrorMessageResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenResourceOnly()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource));

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenKeyOnly()
        {
            var descriptor = new ValidationAttributeDescriptor()
            {
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenEmptyDescriptor()
        {
            var descriptor = new ValidationAttributeDescriptor();

            var generator = new ValidationParametersGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
