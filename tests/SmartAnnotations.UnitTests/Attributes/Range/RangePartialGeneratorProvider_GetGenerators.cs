using FluentAssertions;
using SmartAnnotations.Attributes.Range;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Range
{
    public class RangePartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredRangeGeneratorsInOrder()
        {
            var descriptor = new RangeAttributeDescriptor(1, 10);
            var provider = RangePartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(OperandTypeGenerator),
                typeof(MinimumGenerator),
                typeof(MaximumGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
