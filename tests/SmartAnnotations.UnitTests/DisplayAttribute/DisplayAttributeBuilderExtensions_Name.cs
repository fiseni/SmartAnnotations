using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayAttributeBuilderExtensions_Name
    {
        [Fact]
        public void SetsName_GivenNotNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = new DisplayAttributeDescriptor() };
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            builder.Name("SomeName");

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.Name.Should().Be("SomeName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            Action action = () => builder.Name("SomeName");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Display");
        }
    }
}
