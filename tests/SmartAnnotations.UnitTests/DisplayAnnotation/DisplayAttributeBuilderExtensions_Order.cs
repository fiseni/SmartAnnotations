using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class DisplayAttributeBuilderExtensions_Order
    {
        [Fact]
        public void SetsOrder_GivenNotNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new DisplayAttributeDescriptor());
            var builder = new DisplayAttributeBuilder<string>(annotationDescriptor);

            builder.Order(5);

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.Order.Should().Be(5);
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Order(5);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayAttributeDescriptor");
        }
    }
}
