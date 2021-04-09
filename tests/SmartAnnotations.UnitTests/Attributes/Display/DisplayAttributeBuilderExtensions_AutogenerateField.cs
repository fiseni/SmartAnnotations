using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class DisplayAttributeBuilderExtensions_AutogenerateField
    {
        [Fact]
        public void SetsAutogenerateField_GivenNotNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new DisplayAttributeDescriptor());
            var builder = new DisplayAttributeBuilder(annotationDescriptor);

            builder.AutoGenerateField(true);

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AutoGenerateField.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var builder = new DisplayAttributeBuilder(annotationDescriptor);

            Action action = () => builder.AutoGenerateField(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayAttributeDescriptor");
        }
    }
}
