using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ValidationAttribute
{
    public class ValidationAttributeBuilderExtensions_Message
    {
        // Choose one descedant of IValidationAttributeBuilder
        [Fact]
        public void SetsErrorMessage_GivenMessageAndNotNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new RequiredAttributeDescriptor());
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            builder.Message("SomeMessage");

            var descriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.ErrorMessage.Should().Be("SomeMessage");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrEmptyMessage()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new RequiredAttributeDescriptor());
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Message(string.Empty);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("message");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Message("SomeMessage");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("ValidationAttributeDescriptor");
        }
    }
}
