using FluentAssertions;
using SmartAnnotations.Attributes.Required;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Required
{
    public class RequiredPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredPartialGeneratorsInOrder()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var provider = RequiredPartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(AllowEmptyStringsGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
