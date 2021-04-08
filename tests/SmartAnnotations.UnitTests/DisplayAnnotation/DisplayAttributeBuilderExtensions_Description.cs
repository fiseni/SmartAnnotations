using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class DisplayAttributeBuilderExtensions_Description
    {
        [Fact]
        public void SetsDescription_GivenNotNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new DisplayAttributeDescriptor());
            var builder = new DisplayAttributeBuilder<string>(annotationDescriptor);

            builder.Description("SomeDescription");

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.Description.Should().Be("SomeDescription");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Description("SomeDescription");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayAttributeDescriptor");
        }
    }
}
