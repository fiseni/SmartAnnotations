using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class DisplayPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredDisplayGeneratorsInOrder()
        {
            var descriptor = new DisplayAttributeDescriptor();
            var provider = DisplayPartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(OrderGenerator),
                typeof(AutoGenerateFieldGenerator),
                typeof(AutoGenerateFilterGenerator),
                typeof(NameGenerator),
                typeof(ShortNameGenerator),
                typeof(PromptGenerator),
                typeof(DescriptionGenerator),
                typeof(GroupNameGenerator),
                typeof(ResourceTypeGenerator));
        }
    }
}
