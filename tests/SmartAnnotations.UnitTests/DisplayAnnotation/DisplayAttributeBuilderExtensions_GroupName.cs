using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class DisplayAttributeBuilderExtensions_GroupName
    {
        [Fact]
        public void SetsGroupName_GivenNotNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(new DisplayAttributeDescriptor());
            var builder = new DisplayAttributeBuilder(annotationDescriptor);

            builder.GroupName("SomeGroupName");

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.GroupName.Should().Be("SomeGroupName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var builder = new DisplayAttributeBuilder(annotationDescriptor);

            Action action = () => builder.GroupName("SomeGroupName");

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayAttributeDescriptor");
        }
    }
}
