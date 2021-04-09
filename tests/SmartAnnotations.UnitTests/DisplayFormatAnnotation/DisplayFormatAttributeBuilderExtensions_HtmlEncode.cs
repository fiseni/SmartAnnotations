using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayFormatAnnotation
{
    public class DisplayFormatAttributeBuilderExtensions_HtmlEncode
    {
        [Fact]
        public void SetsHtmlEncode_GivenNotNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new DisplayFormatAttributeDescriptor());
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            builder.HtmlEncode(true);

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.HtmlEncode.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            Action action = () => builder.HtmlEncode(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayFormatAttributeDescriptor");
        }
    }
}
