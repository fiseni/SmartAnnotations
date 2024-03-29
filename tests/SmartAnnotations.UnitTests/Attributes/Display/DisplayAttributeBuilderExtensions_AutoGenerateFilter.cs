﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Attributes.Display
{
    public class DisplayAttributeBuilderExtensions_AutoGenerateFilter
    {
        [Fact]
        public void SetsAutogenerateFilter_GivenNotNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName").Add(new DisplayAttributeDescriptor());
            var builder = new DisplayAttributeBuilder(annotationDescriptor);

            builder.AutoGenerateFilter(true);

            var descriptor = annotationDescriptor.Get<DisplayAttributeDescriptor>();
            descriptor.Should().NotBeNull();
            descriptor!.AutoGenerateFilter.Should().BeTrue();
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullDisplayDescriptor()
        {
            var annotationDescriptor = new AnnotationDescriptor("PropertyName");
            var builder = new DisplayAttributeBuilder(annotationDescriptor);

            Action action = () => builder.AutoGenerateFilter(true);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("DisplayAttributeDescriptor");
        }
    }
}
