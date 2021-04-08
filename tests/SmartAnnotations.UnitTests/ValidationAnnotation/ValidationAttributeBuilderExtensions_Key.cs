using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ValidationAnnotation
{
    public class ValidationAttributeBuilderExtensions_Key
    {
        // Choose one descedant of IValidationAttributeBuilder
        [Fact]
        public void SetsErrorMessageKey_GivenKeyAndNotNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new RequiredAttributeDescriptor());
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            builder.Key("SomeKey");

            var descriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.ErrorMessageResourceName.Should().Be("SomeKey");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullOrEmptyKey()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new RequiredAttributeDescriptor());
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Key(string.Empty);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("resourceKey");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Key("SomeKey");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("ValidationAttributeDescriptor");
        }
    }
}
