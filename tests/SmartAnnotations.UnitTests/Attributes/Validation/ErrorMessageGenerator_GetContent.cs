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
    public class ErrorMessageGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenErrorMessage()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName) { ErrorMessage = "SomeErrorMessage" };
            var generator = ErrorMessageGenerator.Instance;

            var expected = @"ErrorMessage = ""SomeErrorMessage""";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullOrEmptyErrorMessage()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var generator = ErrorMessageGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
