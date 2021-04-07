using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayAttributeBuilderExtensions_ShortName
    {
        [Fact]
        public void SetsShortName_GivenNotNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = new DisplayAttributeDescriptor() };
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            builder.ShortName("SomeShortName");

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.ShortName.Should().Be("SomeShortName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            Action action = () => builder.ShortName("SomeShortName");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Display");
        }
    }
}
