using FluentAssertions;
using SmartAnnotations.Attributes.MinLength;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.MinLength
{
    public class MinLengthPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredMinLengthGeneratorsInOrder()
        {
            var descriptor = new MinLengthAttributeDescriptor(10);
            var provider = new MinLengthPartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(LengthGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
