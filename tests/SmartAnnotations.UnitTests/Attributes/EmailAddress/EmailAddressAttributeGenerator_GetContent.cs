using FluentAssertions;
using SmartAnnotations.Attributes.EmailAddress;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.EmailAddress
{
    public class EmailAddressAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsEmailAddressAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new EmailAddressAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = EmailAddressAttributeGenerator.Instance;

            var expected = @"[EmailAddress(ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmailAddressAttributeWithMessageOnly_GivenEmptyEmailAddressDescriptor()
        {
            var descriptor = new EmailAddressAttributeDescriptor();

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = EmailAddressAttributeGenerator.Instance;

            var expected = @"[EmailAddress()]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullEmailAddressDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = EmailAddressAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
