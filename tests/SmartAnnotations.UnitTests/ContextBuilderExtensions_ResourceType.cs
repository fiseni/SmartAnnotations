using FluentAssertions;
using SmartAnnotations.Internal;
using SmartAnnotations.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAnnotation
{
    public class ContextBuilderExtensions_ResourceType
    {
        [Fact]
        public void SetsModelResourceType_GivenNotNullValue()
        {
            var context = new TestAnnotatorEmpty();

            var contextBuilder = new ContextBuilder(context);

            contextBuilder.ResourceType(typeof(ModelTestResource));

            contextBuilder.Context.Should().NotBeNull();
            contextBuilder.Context.ResourceTypeFullName.Should().NotBeNull();
            contextBuilder.Context.ResourceTypeFullName.Should().Be(typeof(ModelTestResource).FullName);
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNull()
        {
            var context = new TestAnnotatorEmpty();

            var contextBuilder = new ContextBuilder(context);

            Func<IContextBuilder> func = () => contextBuilder.ResourceType(null!);

            func.Should().Throw<ArgumentException>().And.ParamName.Should().Be("resourceType");
        }
    }
}
