using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayAttributeBuilderExtensions_AutogenerateField
    {
        [Fact]
        public void SetsAutogenerateField_GivenNotNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = new DisplayAttributeDescriptor() };
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            builder.AutoGenerateField(true);

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.AutoGenerateField.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            Action action = () => builder.AutoGenerateField(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Display");
        }
    }
}
