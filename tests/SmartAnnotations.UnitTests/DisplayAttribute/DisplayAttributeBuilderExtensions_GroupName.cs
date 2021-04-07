using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayAttributeBuilderExtensions_GroupName
    {
        [Fact]
        public void SetsGroupName_GivenNotNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Display = new DisplayAttributeDescriptor() };
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            builder.GroupName("SomeGroupName");

            descriptor.Display.Should().NotBeNull();
            descriptor.Display!.GroupName.Should().Be("SomeGroupName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(descriptor);

            Action action = () => builder.GroupName("SomeGroupName");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Display");
        }
    }
}
