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

            var generators = provider.GetGenerators();

            generators.Should().Contain(x => x.GetType().Equals(typeof(OrderGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(AutoGenerateFieldGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(AutoGenerateFilterGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(NameGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(ShortNameGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(PromptGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(DescriptionGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(GroupNameGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(ResourceTypeGenerator)));
        }
    }
}
