using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class DisplayPartialGeneratorProvider_GetContent
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }

        [Fact]
        public void ReturnsRequiredDisplayGenerators()
        {
            var descriptor = new DisplayAttributeDescriptor(typeof(AttributeTestResource));
            var provider = new DisplayPartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().Contain(typeof(OrderGenerator));
            generators.Should().Contain(typeof(AutoGenerateFieldGenerator));
            generators.Should().Contain(typeof(AutoGenerateFilterGenerator));
            generators.Should().Contain(typeof(NameGenerator));
            generators.Should().Contain(typeof(ShortNameGenerator));
            generators.Should().Contain(typeof(PromptGenerator));
            generators.Should().Contain(typeof(DescriptionGenerator));
            generators.Should().Contain(typeof(GroupNameGenerator));
            generators.Should().Contain(typeof(ResourceTypeGenerator));
        }
    }
}
