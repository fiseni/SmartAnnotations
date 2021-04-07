using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAttribute
{
    public class RequiredAttributeBuilderExtensions_AllowEmptyStrings
    {
        [Fact]
        public void SetsAllowEmptyStrings_GivenNotNullRequiredDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string)) { Required = new RequiredAttributeDescriptor() };
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            builder.AllowEmptyStrings(true);

            descriptor.Required.Should().NotBeNull();
            descriptor.Required!.AllowEmptyStrings.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullRequiredDescriptor()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new RequiredAttributeBuilder<string>(descriptor);

            Action action = () => builder.AllowEmptyStrings(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("Required");
        }
    }
}
