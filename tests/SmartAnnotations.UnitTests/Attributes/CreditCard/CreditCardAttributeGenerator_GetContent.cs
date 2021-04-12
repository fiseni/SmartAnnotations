using FluentAssertions;
using SmartAnnotations.Attributes.CreditCard;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.CreditCard
{
    public class CreditCardAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsCreditCardAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new CreditCardAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = CreditCardAttributeGenerator.Instance;

            var expected = @"[CreditCard(ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessCreditCardAttribute_GivenEmptyCreditCardDescriptor()
        {
            var descriptor = new CreditCardAttributeDescriptor();

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = CreditCardAttributeGenerator.Instance;

            var expected = @"[CreditCard()]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullCreditCardDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = CreditCardAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
