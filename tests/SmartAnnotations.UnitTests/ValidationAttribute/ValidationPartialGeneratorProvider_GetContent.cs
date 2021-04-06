using FluentAssertions;
using SmartAnnotations.ValidationAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.ValidationAttribute
{
    public class ValidationPartialGeneratorProvider_GetGenerators
    {
        private class AttributeTestResource { }
        private class ModelTestResource { }

        [Fact]
        public void ReturnsRequiredValidationGenerators()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource));
            var provider = new ValidationPartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators();

            generators.Should().Contain(x => x.GetType().Equals(typeof(ErrorMessageGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(ResourceNameGenerator)));
            generators.Should().Contain(x => x.GetType().Equals(typeof(ResourceTypeGenerator)));
        }
    }
}
