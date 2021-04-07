using FluentAssertions;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class AnnotationBuilderExtensions_ReadOnly
    {
        [Fact]
        public void SetsReadOnlyDescriptor_GivenValue()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(string));
            var annotationBuilder = new AnnotationBuilder<string>(descriptor);

            annotationBuilder.ReadOnly(true);

            descriptor.ReadOnly.Should().NotBeNull();
            descriptor.ReadOnly!.IsReadOnly.Should().BeTrue();
        }
    }
}
