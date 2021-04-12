using FluentAssertions;
using SmartAnnotations.Attributes.DisplayFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DisplayFormat
{
    public class DisplayFormatPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredDisplayFormatGeneratorsInOrder()
        {
            var descriptor = new DisplayFormatAttributeDescriptor();
            var provider = DisplayFormatPartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

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
