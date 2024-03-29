﻿using FluentAssertions;
using SmartAnnotations.Internal;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class AnnotationBuilderExtensions_DataType
    {
        [Fact]
        public void SetsDataTypeDescriptorWithDataTypeEnum_GivenDataTypeEnum()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DataType(DataTypeEnum.CreditCard);

            var attributeDescriptor = annotationDescriptor.Get<DataTypeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.DataType.Should().Be(DataTypeEnum.CreditCard);
        }

        [Fact]
        public void SetsDataTypeDescriptorWithCustomDataType_GivenValidCustomDataType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DataType("CustomDataType");

            var attributeDescriptor = annotationDescriptor.Get<DataTypeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.CustomDataType.Should().Be("CustomDataType");
        }

        [Fact]
        public void ThrowsArgumentException_GivenNullOrEmptyCustomDataType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            Action action = () => annotationBuilder.DataType(string.Empty);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("customDataType");
        }

        [Fact]
        public void SetsDataTypeDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DataType(DataTypeEnum.CreditCard);

            var attributeDescriptor = annotationDescriptor.Get<DataTypeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().BeNull();
            attributeDescriptor!.ModelResourceType.Should().BeNull();
            attributeDescriptor!.HasResourceType.Should().BeFalse();
            attributeDescriptor!.GetResourceTypeFullName().Should().BeNull();
        }

        [Fact]
        public void SetsDataTypeDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DataType(DataTypeEnum.CreditCard, typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<DataTypeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsDataTypeDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DataType("CustomDataType", typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<DataTypeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsDataTypeDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.DataType(DataTypeEnum.CreditCard);

            var attributeDescriptor = annotationDescriptor.Get<DataTypeAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
