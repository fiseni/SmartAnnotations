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
    public class Annotator_DefineFor
    {
        [Fact]
        public void SetsAnnotationContextType_OnConstruction()
        {
            var annotator = new TestAnnotatorEmpty();

            annotator.Type.Should().Be(typeof(TestType));
        }

        [Fact]
        public void ReturnsAnnotationBuilderAndSetsDescriptor_GivenValidSelectorExpression()
        {
            var annotator = new TestAnnotatorEmpty() { ResourceType = typeof(ModelTestResource) };

            annotator.DefineFor(x => x.TestProperty);

            annotator.Descriptors.Should().HaveCount(1);
            annotator.Descriptors.First().PropertyName.Should().Be("TestProperty");
            annotator.Descriptors.First().PropertyType.Should().Be(typeof(string));
            annotator.Descriptors.First().ModelResourceType.Should().Be(typeof(ModelTestResource));
        }

        [Fact]
        public void ThrowsArgumentException_GivenInvalidExpression()
        {
            var annotator = new TestAnnotatorEmpty() { ResourceType = typeof(ModelTestResource) };

            Func<IAnnotationBuilder> func = () => annotator.DefineFor<string>(x => "");

            func.Should().Throw<ArgumentException>().WithMessage("The input should be a selector expression, in form: 'x => x.Property'!");
        }
    }
}
