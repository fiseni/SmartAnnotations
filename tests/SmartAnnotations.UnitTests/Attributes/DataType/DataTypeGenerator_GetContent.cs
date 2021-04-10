using FluentAssertions;
using SmartAnnotations.Attributes.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DataType
{
    public class DataTypeGenerator_GetContent
    {
        [Fact]
        public void ReturnsContentWithDataTypeEnum_GivenConstructorWithDataTypeEnum()
        {
            var descriptor = new DataTypeAttributeDescriptor(DataTypeEnum.CreditCard);
            var generator = new DataTypeGenerator(descriptor);

            var expected = @"DataType.CreditCard";

            generator.GetContent().Should().Be(expected);
        }

        [Fact]
        public void ReturnsContentWithCustomDataType_GivenConstructorWithCustomDataType()
        {
            var descriptor = new DataTypeAttributeDescriptor("CustomDataType");
            var generator = new DataTypeGenerator(descriptor);

            var expected = @"""CustomDataType""";

            generator.GetContent().Should().Be(expected);
        }
    }
}
