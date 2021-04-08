using FluentAssertions;
using SmartAnnotations.DataTypeAnnotation;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DataTypeAnnotation
{
    public class DataTypeAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsDataTypeAttributeWithMessageOnly_GivenDataTypeConstructorAndAllParameters()
        {
            var descriptor = new DataTypeAttributeDescriptor(DataTypeEnum.CreditCard, typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(descriptor);

            var generator = new DataTypeAttributeGenerator(annotationDescriptor);

            var expected = @"[DataType(DataType.CreditCard, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsDataTypeAttributeWithMessageOnly_GivenCustomDataTypeConstructorAndAllParameters()
        {
            var descriptor = new DataTypeAttributeDescriptor("CustomDataType", typeof(AttributeTestResource))
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string)).Add(descriptor);

            var generator = new DataTypeAttributeGenerator(annotationDescriptor);

            var expected = @"[DataType(""CustomDataType"", ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDataTypeDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(string));

            var generator = new DataTypeAttributeGenerator(annotationDescriptor);

            var expected = string.Empty;

            generator.GetContent().Should().Be(expected);
        }
    }
}
