using FluentAssertions;
using SmartAnnotations.DisplayFormatAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayFormatAnnotation
{
    public class DisplayFormatPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredDisplayFormatGeneratorsInOrder()
        {
            var descriptor = new DisplayFormatAttributeDescriptor();
            var provider = new DisplayFormatPartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(ApplyFormatInEditModeGenerator),
                typeof(ConvertEmptyStringToNullGenerator),
                typeof(HtmlEncodeGenerator),
                typeof(DataFormatStringGenerator),
                typeof(NullDisplayTextGenerator),
                typeof(ResourceTypeGenerator));
        }
    }
}
