using FluentAssertions;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class AnnotationContextTests
    {
        [Fact]
        public void SetsTypeInfo_GivenNotNullOrWhiteSpaceNamespace()
        {
            var context = new TestAnnotationContext(typeof(TestType).Name, typeof(TestType).Namespace);

            context.TypeNamespace.Should().Be("SmartAnnotations.UnitTests.Fixture");
            context.TypeName.Should().Be("TestType");
            context.TypeFullName.Should().Be("SmartAnnotations.UnitTests.Fixture.TestType");
        }

        [Fact]
        public void SetsTypeInfo_GivenNullNamespace()
        {
            var context = new TestAnnotationContext(typeof(TestType).Name, null);

            context.TypeNamespace.Should().BeNull();
            context.TypeName.Should().Be("TestType");
            context.TypeFullName.Should().Be("TestType");
        }

        [Fact]
        public void SetsTypeInfo_GivenWhiteSpaceNamespace()
        {
            var context = new TestAnnotationContext(typeof(TestType).Name, " ");

            context.TypeNamespace.Should().BeNull();
            context.TypeName.Should().Be("TestType");
            context.TypeFullName.Should().Be("TestType");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNullTypeName()
        {
            Action action = () => new TestAnnotationContext(null!, null);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("typeName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenEmptyStringTypeName()
        {
            Action action = () => new TestAnnotationContext(string.Empty, null);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("typeName");
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenWhiteSpaceStringTypeName()
        {
            Action action = () => new TestAnnotationContext(" ", null);

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("typeName");
        }
    }
}
