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
    public class AnnotationBuilderExtensions_Email
    {
        [Fact]
        public void SetsEmailAddressDescriptorWithNoResourceType_GivenNoAttributeOrModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Email();

            var attributeDescriptor = annotationDescriptor.Get<EmailAddressAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().BeNull();
            attributeDescriptor!.ModelResourceType.Should().BeNull();
            attributeDescriptor!.HasResourceType.Should().BeFalse();
            attributeDescriptor!.GetResourceTypeFullName().Should().BeNull();
        }

        [Fact]
        public void SetsEmailAddressDescriptorWithAttributeResourceType_GivenResourceTypeParameter()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Email(typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<EmailAddressAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsEmailAddressDescriptorWithAttributeResourceType_GivenResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Email(typeof(AttributeTestResource));

            var attributeDescriptor = annotationDescriptor.Get<EmailAddressAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.AttributeResourceType.Should().Be(typeof(AttributeTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(AttributeTestResource).FullName);
        }

        [Fact]
        public void SetsEmailAddressDescriptorWithModelResourceType_GivenNoResourceTypeParameterAndHasModelResourceType()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName", typeof(ModelTestResource).FullName);
            var annotationBuilder = new AnnotationBuilder(annotationDescriptor);

            annotationBuilder.Email();

            var attributeDescriptor = annotationDescriptor.Get<EmailAddressAttributeDescriptor>();
            attributeDescriptor.Should().NotBeNull();
            attributeDescriptor!.ModelResourceType.Should().Be(typeof(ModelTestResource).FullName);
            attributeDescriptor!.HasResourceType.Should().BeTrue();
            attributeDescriptor!.GetResourceTypeFullName().Should().Be(typeof(ModelTestResource).FullName);
        }
    }
}
