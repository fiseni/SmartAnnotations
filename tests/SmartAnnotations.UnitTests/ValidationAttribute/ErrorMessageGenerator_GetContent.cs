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
    public class ErrorMessageGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenErrorMessage()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource)) { ErrorMessage = "SomeErrorMessage" };
            var generator = new ErrorMessageGenerator(descriptor);

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullOrEmptyErrorMessage()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource));
            var generator = new ErrorMessageGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
