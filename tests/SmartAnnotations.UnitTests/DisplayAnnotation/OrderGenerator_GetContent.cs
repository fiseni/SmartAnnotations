using FluentAssertions;
using SmartAnnotations.DisplayAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class OrderGenerator_GetContent
    {
        [Fact]
        public void ReturnsContent_GivenOrderHasValue()
        {
            var descriptor = new DisplayAttributeDescriptor() { Order = 5 };
            var generator = new OrderGenerator(descriptor);

            var expected = @"Order = 5";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenOrderIsNull()
        {
            var descriptor = new DisplayAttributeDescriptor() { Order = null };
            var generator = new OrderGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
