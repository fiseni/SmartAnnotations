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
        public string TestProperty { get; set; } = "SomeString";

        [Fact]
        public void SetsShortName_GivenNotNullParameter()
        {
            var descriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string)) { Display = new DisplayAttributeDescriptor() };
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            builder.ShortName("SomeShortName");

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.ShortName.Should().Be("SomeShortName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor(nameof(TestProperty), typeof(string));
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            Action action = () => builder.ShortName("SomeShortName");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Display");
        }
    }
}
