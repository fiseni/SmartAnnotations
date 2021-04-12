using SmartAnnotations.Attributes.Display;
using SmartAnnotations.Attributes.DisplayFormat;
using SmartAnnotations.Attributes.ReadOnly;
using SmartAnnotations.Attributes.Required;
using SmartAnnotations.Attributes.StringLength;
using SmartAnnotations.Attributes.MaxLength;
using SmartAnnotations.Attributes.MinLength;
using SmartAnnotations.Attributes.Compare;
using SmartAnnotations.Attributes.Range;
using FluentAssertions;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SmartAnnotations.Attributes.EmailAddress;

namespace SmartAnnotations.UnitTests.Internal
{
    public class AttributeGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredPartialGeneratorsInOrder()
        {
            var descriptor = new AnnotationDescriptor("PropertyName");
            var provider = AttributeGeneratorProvider.Instance;

            var generators = provider.Generators.Select(x => x.GetType());

            generators.Should().ContainInOrder(
                typeof(ReadOnlyAttributeGenerator),
                typeof(RequiredAttributeGenerator),
                typeof(DisplayAttributeGenerator),
                typeof(DisplayFormatAttributeGenerator),
                typeof(StringLengthAttributeGenerator),
                typeof(MaxLengthAttributeGenerator),
                typeof(MinLengthAttributeGenerator),
                typeof(CompareAttributeGenerator),
                typeof(RangeAttributeGenerator),
                typeof(EmailAddressAttributeGenerator)
            );
        }
    }
}
