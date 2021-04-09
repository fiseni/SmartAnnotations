using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Validation
{
    public class ValidationPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredValidationGenerators()
        {
            var descriptor = new ValidationAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var provider = new ValidationPartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(ErrorMessageGenerator),
                typeof(ResourceNameGenerator),
                typeof(ResourceTypeGenerator));
        }
    }
}
