using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DisplayFormat
{
    public class DisplayFormatAttributeBuilderExtensions_ApplyFormatInEditMode
    {
        [Fact]
        public void SetsApplyFormatInEditMode_GivenNotNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new DisplayFormatAttributeDescriptor());
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            builder.ApplyFormatInEditMode(true);

            var descriptor = annotationDescriptor.Get<DisplayFormatAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.ApplyFormatInEditMode.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayFormatDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var builder = new DisplayFormatAttributeBuilder(annotationDescriptor);

            Action action = () => builder.ApplyFormatInEditMode(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayFormatAttributeDescriptor");
        }
    }
}
