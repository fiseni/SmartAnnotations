using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAttribute
{
    public class RequiredAttributeBuilderExtensions_Message
    {
        [Fact]
        public void SetsErrorMessage_GivenMessageAndNotNullRequiredDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = new RequiredAttributeDescriptor() };
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            builder.Message("SomeMessage");

            descriptor.Required.Should().NotBeNull();
            descriptor.Required!.ErrorMessage.Should().Be("SomeMessage");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrEmptyMessage()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = new RequiredAttributeDescriptor() };
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            Action action = () => builder.Message(string.Empty);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("message");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullRequiredDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            Action action = () => builder.Message("SomeMessage");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Required");
        }
    }
}
