using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DisplayFormat
{
    public class DisplayFormatAttributeBuilderExtensions_DataFormatString
    {
        [Fact]
        public void SetsDataFormatString_GivenNotNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new DisplayFormatAttributeDescriptor());
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            builder.DataFormatString("{0:n2} Kg");

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.DataFormatString.Should().Be("{0:n2} Kg");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            Action action = () => builder.DataFormatString("{0:n2} Kg");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayFormatAttributeDescriptor");
        }
    }
}
