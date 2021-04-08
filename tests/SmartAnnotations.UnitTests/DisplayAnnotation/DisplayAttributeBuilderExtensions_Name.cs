using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class DisplayAttributeBuilderExtensions_Name
    {
        [Fact]
        public void SetsName_GivenNotNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new DisplayAttributeDescriptor());
            var builder = new DisplayAttributeBuilder<string>(annotationDescriptor);

            builder.Name("SomeName");

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.Name.Should().Be("SomeName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder<string>(annotationDescriptor);

            Action action = () => builder.Name("SomeName");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayAttributeDescriptor");
        }
    }
}
