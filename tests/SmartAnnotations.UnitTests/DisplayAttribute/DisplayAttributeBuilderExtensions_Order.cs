using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayAttributeBuilderExtensions_Order
    {
        public string TestProperty { get; set; } = "SomeString";

        [Fact]
        public void SetsOrder_GivenNotNullParameter()
        {
            var descriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { Display = new DisplayAttributeDescriptor() };
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            builder.Order(5);

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.Order.Should().Be(5);
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string));
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            Action action = () => builder.Order(5);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Display");
        }
    }
}
