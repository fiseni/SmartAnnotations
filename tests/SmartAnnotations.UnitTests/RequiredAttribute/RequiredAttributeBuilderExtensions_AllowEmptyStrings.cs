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
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new RequiredAttributeDescriptor());
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            builder.AllowEmptyStrings(true);

            var descriptor = annotationDescriptor.Get<RequiredAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AllowEmptyStrings.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullRequiredDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new RequiredAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.AllowEmptyStrings(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("RequiredAttributeDescriptor");
        }
    }
}
