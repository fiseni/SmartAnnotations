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
    public class Annotator_Define
    {
        [Fact]
        public void ReturnsContextBuilderContainingTheAnnotationContext()
        {
            var annotator = new TestAnnotatorEmpty() { ResourceTypeFullName = typeof(ModelTestResource).FullName };

            var builder = annotator.Define();

            builder.Context.Should().BeEquivalentTo(annotator);
        }
    }
}
