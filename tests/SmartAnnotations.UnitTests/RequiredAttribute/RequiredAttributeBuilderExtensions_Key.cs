using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAttribute
{
    public class RequiredAttributeBuilderExtensions_Key
    {
        [Fact]
        public void SetsErrorMessageKey_GivenKeyAndNotNullRequiredDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = new RequiredAttributeDescriptor() };
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            builder.Key("SomeKey");

            descriptor.Required.Should().NotBeNull();
            descriptor.Required!.ErrorMessageResourceName.Should().Be("SomeKey");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrEmptyKey()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = new RequiredAttributeDescriptor() };
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            Action action = () => builder.Key(string.Empty);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("resourceKey");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullRequiredDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            Action action = () => builder.Key("SomeKey");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Required");
        }
    }
}
