using FluentAssertions;
using SmartAnnotations.RequiredAnnotation;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.ValidationAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.RequiredAnnotation
{
    public class RequiredPartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredPartialGeneratorsInOrder()
        {
            var descriptor = new RequiredAttributeDescriptor(typeof(AttributeTestResource).FullName);
            var provider = new RequiredPartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(AllowEmptyStringsGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}
