using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class AnnotationDescriptorTests
    {
        [Fact]
        public void SetsInternalState_GivenPropertyNameAndModelResourceTypeFullName()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);

            descriptor.PropertyName.Should().Be("PropertyName");
            descriptor.ModelResourceTypeFullName.Should().NotBeNull();
            descriptor.ModelResourceTypeFullName!.Should().Be("SmartAnnotations.UnitTests.Fixture.ModelTestResource");
        }

        [Fact]
        public void SetsInternalState_GivenPropertyNameAndNullModelResourceTypeFullName()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", null);

            descriptor.PropertyName.Should().Be("PropertyName");
            descriptor.ModelResourceTypeFullName.Should().BeNull();
        }

        [Fact]
        public void SetsInternalState_GivenPropertyNameAndWhiteSpaceModelResourceTypeFullName()
        {
            var descriptor = new AnnotationDescriptor("PropertyName", " ");

            descriptor.PropertyName.Should().Be("PropertyName");
            descriptor.ModelResourceTypeFullName.Should().BeNull();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullPropertyName()
        {
            Action action = () => new AnnotationDescriptor(null!, null);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("propertyName");
        }
    }
}
