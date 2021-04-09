using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayFormatAnnotation
{
    public class DisplayFormatAttributeBuilderExtensions_ConvertEmptyStringToNull
    {
        [Fact]
        public void SetsConvertEmptyStringToNull_GivenNotNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new DisplayFormatAttributeDescriptor());
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            builder.ConvertEmptyStringToNull(true);

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.ConvertEmptyStringToNull.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            Action action = () => builder.ConvertEmptyStringToNull(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayFormatAttributeDescriptor");
        }
    }
}
