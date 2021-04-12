using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class OrderGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenOrderHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { Order = 5 };
            var generator = OrderGenerator.Instance;

            var expected = @"Order = 5";

            generator.GetContent(descriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenOrderIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { Order = null };
            var generator = OrderGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(descriptor).Should().Be(expected);
        }
    }
}
