using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Range
{
    public class RangeAttributeDescriptorTests
    {
        [Fact]
        public void SetsInternalState_GivenMinMaxAsIntegers()
        {
            var descriptor = new RangeAttributeDescriptor(1, 10);

            descriptor.MinimumAsString.Should().Be("1");
            descriptor.MaximumAsString.Should().Be("10");
            descriptor.OperandTypeFullName.Should().BeNull();
        }

        [Fact]
        public void SetsInternalState_GivenMinMaxAsDouble()
        {
            var descriptor = new RangeAttributeDescriptor(1.5, 10.333);

            descriptor.MinimumAsString.Should().Be("1.5d");
            descriptor.MaximumAsString.Should().Be("10.333d");
            descriptor.OperandTypeFullName.Should().BeNull();
        }

        [Fact]
        public void SetsInternalState_GivenOperandTypeFullNameAndMinMaxAsString()
        {
            var descriptor = new RangeAttributeDescriptor("SomeTypeFullName", "1", "10");

            descriptor.MinimumAsString.Should().Be("\"1\"");
            descriptor.MaximumAsString.Should().Be("\"10\"");
            descriptor.OperandTypeFullName.Should().Be("SomeTypeFullName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrWhiteSpaceTypeFullName()
        {
            Action action = () => new RangeAttributeDescriptor(" ", "1", "10");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("typeFullName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrWhiteSpaceMinimum()
        {
            Action action = () => new RangeAttributeDescriptor("SomeTypeFullName", " ", "10");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("minimum");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrWhiteSpaceMaximum()
        {
            Action action = () => new RangeAttributeDescriptor("SomeTypeFullName", "1", " ");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("maximum");
        }
    }
}
