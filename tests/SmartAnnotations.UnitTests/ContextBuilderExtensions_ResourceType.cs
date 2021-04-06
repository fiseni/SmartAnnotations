using FluentAssertions;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.DisplayAttribute
{
    public class ContextBuilderExtensions_ResourceType
    {
        [Fact]
        public void SetsModelResourceType_GivenNotNullValue()
        {
            var context = new TestAnnotator();

            var contextBuilder = new ContextBuilder(context);

            contextBuilder.ResourceType(typeof(ModelTestResource));

            contextBuilder.Context.Should().NotBeNull();
            contextBuilder.Context.ResourceType.Should().NotBeNull();
            contextBuilder.Context.ResourceType.Should().Be(typeof(ModelTestResource));
        }

        [Fact]
        public void ThrowsArgumentNullException_GivenNull()
        {
            var context = new TestAnnotator();

            var contextBuilder = new ContextBuilder(context);

            Func<IContextBuilder> func = () => contextBuilder.ResourceType(null!);

            func.Should().Throw<ArgumentException>().And.ParamName.Should().Be("resourceType");
        }


        private class ModelTestResource { }
        private partial class TestType
        {
            public string? TestProperty { get; set; } = null;
        }
        private class TestAnnotator : Annotator<TestType>
        {
        }
    }
}
