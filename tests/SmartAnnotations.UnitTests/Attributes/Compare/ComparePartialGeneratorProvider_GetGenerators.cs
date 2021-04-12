using FluentAssertions;
using SmartAnnotations.Attributes.Compare;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Compare
{
    public class ComparePartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredCompareGeneratorsInOrder()
        {
            var descriptor = new CompareAttributeDescriptor("OtherProperty");
            var provider = ComparePartialGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(OtherPropertyGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
