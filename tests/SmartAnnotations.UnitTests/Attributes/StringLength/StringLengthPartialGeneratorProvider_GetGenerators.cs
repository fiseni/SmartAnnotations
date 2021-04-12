using FluentAssertions;
using SmartAnnotations.Attributes.StringLength;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.StringLength
{
    public class StringLengthPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredStringLengthGeneratorsInOrder()
        {
            var descriptor = new StringLengthAttributeDescriptor(10);
            var provider = StringLengthPartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(MaximumLengthGenerator),
                typeof(MinimumLengthGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
