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

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(ErrorMessageGenerator),
                typeof(ResourceNameGenerator),
                typeof(ResourceTypeGenerator));
        }
    }
}
