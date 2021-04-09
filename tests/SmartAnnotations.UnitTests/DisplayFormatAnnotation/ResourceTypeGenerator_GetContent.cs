using FluentAssertions;
using SmartAnnotations.DisplayFormatAnnotation;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayFormatAnnotation
{
    public class ResourceTypeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeAndModelResourceTypeAndNullDisplayTextHaveValue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(typeof(AttributeTestResource).FullName, typeof(ModelTestResource).FullName) { NullDisplayText = "SomeText" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithAttributeResource_GivenHasAttributeResourceTypeAndNullDisplayTextHaveValue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(typeof(AttributeTestResource).FullName) { NullDisplayText = "SomeText" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.AttributeTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithModelResource_GivenHasModelResourceTypeAndNullDisplayTextHaveValue()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(null, typeof(ModelTestResource).FullName) { NullDisplayText = "SomeText" };
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = @"NullDisplayTextResourceType = typeof(SmartAnnotations.UnitTests.Fixture.ModelTestResource)";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasNoResourceType()
        {
            var descriptor = new DisplayFormatAttributeDescriptor();
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenHasResourceTypeAndHasNoNullDisplayText()
        {
            var descriptor = new DisplayFormatAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var generator = new ResourceTypeGenerator(descriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
