using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class Annotator_Define
    {
        [Fact]
        public void ReturnsContextBuilderContainingTheAnnotationContext()
        {
            var annotator = new TestAnnotator() { ResourceType = typeof(ModelTestResource) };

            var builder = annotator.Define();

            builder.Context.Should().BeEquivalentTo(annotator);
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
