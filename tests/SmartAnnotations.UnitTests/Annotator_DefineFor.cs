using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests
{
    public class Annotator_DefineFor
    {
        [Fact]
        public void SetsAnnotationContextType_OnConstruction()
        {
            var annotator = new TestAnnotator();

            annotator.Type.Should().Be(typeof(TestType));
        }

        [Fact]
        public void ReturnsAnnotationBuilderAndSetsDescriptor_GivenValidSelectorExpression()
        {
            var annotator = new TestAnnotator() { ResourceType = typeof(ModelTestResource) };

            annotator.DefineFor(x => x.TestProperty);

            annotator.Descriptors.Should().HaveCount(1);
            annotator.Descriptors.First().PropertyName.Should().Be("TestProperty");
            annotator.Descriptors.First().PropertyType.Should().Be(typeof(string));
            annotator.Descriptors.First().ModelResourceType.Should().Be(typeof(ModelTestResource));
        }

        [Fact]
        public void ThrowsArgumentException_GivenInvalidExpression()
        {
            var annotator = new TestAnnotator() { ResourceType = typeof(ModelTestResource) };

            Func<IAnnotationBuilder<string?>> func = () => annotator.DefineFor<string>(x => "");

            func.Should().Throw<ArgumentException>().WithMessage("The input should be a selector expression, in form: 'x => x.Property'!");
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
