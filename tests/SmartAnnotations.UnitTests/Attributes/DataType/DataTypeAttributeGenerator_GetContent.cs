using FluentAssertions;
using SmartAnnotations.Attributes.DataType;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DataType
{
    public class DataTypeAttributeGenerator_GetContent
    {
        [Fact]
        public void ReturnsDataTypeAttributeWithMessageOnly_GivenDataTypeConstructorAndAllParameters()
        {
            var descriptor = new DataTypeAttributeDescriptor(DataTypeEnum.CreditCard, typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DataTypeAttributeGenerator.Instance;

            var expected = @"[DataType(DataType.CreditCard, ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsDataTypeAttributeWithMessageOnly_GivenCustomDataTypeConstructorAndAllParameters()
        {
            var descriptor = new DataTypeAttributeDescriptor("CustomDataType", typeof(AttributeTestResource).FullName)
            {
                ErrorMessage = "SomeErrorMessage",
                ErrorMessageResourceName = "SomeErrorKey"
            };

            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(descriptor);

            var generator = DataTypeAttributeGenerator.Instance;

            var expected = @"[DataType(""CustomDataType"", ErrorMessage = ""SomeErrorMessage"")]";

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }

        [Fact]
        public void ReturnsEmptyContent_GivenNullDataTypeDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");

            var generator = DataTypeAttributeGenerator.Instance;

            var expected = string.Empty;

            generator.GetContent(annotationDescriptor).Should().Be(expected);
        }
    }
}
