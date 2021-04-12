using FluentAssertions;
using SmartAnnotations.Attributes.Phone;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Phone
{
    public class PhoneAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsPhoneAttributeWithMessageOnly_GivenAllParameters()
        {
            var descriptor = new PhoneAttributeDescriptor(typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = PhoneAttributeGenerator.Instance;

            var expected = @"[Phone(ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsParameterlessPhoneAttribute_GivenEmptyPhoneDescriptor()
        {
            var descriptor = new PhoneAttributeDescriptor();

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = PhoneAttributeGenerator.Instance;

            var expected = @"[Phone()]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullPhoneDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = PhoneAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
