﻿using FluentAssertions;
using SmartAnnotations.Attributes.DataType;
using SmartAnnotations.UnitTests.Fixture;
using SmartAnnotations.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.DataType
{
    public class DataTypePartialGeneratorProvider_GetGenerators
    {
        [Fact]
        public void ReturnsRequiredDataTypeGeneratorsInOrder()
        {
            var descriptor = new DataTypeAttributeDescriptor(DataTypeEnum.CreditCard);
            var provider = new DataTypePartialGeneratorProvider(descriptor);

            var generators = provider.GetGenerators().Select(x=>x.GetType());

            generators.Should().ContainInOrder(
                typeof(DataTypeGenerator),
                typeof(ValidationParametersGenerator));
        }
    }
}