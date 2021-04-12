using FluentAssertions;
using SmartAnnotations.Attributes.MaxLength;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.MaxLength
{
    public class MaxLengthPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredMaxLengthGeneratorsInOrder()
        {
            var descriptor = new MaxLengthAttributeDescriptor(10);
            var provider = MaxLengthPartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(LengthGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
