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
        public void ReturnsAnnotationBuilderAndSetsDescriptor_GivenValidSelectorExpression()
        {
            var annotator = new TestAnnotatorEmpty() { ResourceTypeFullName = typeof(ModelTestResource).FullName };

            annotator.DefineFor(x => x.TestProperty);

            annotator.Descriptors.Should().HaveCount(1);
            annotator.Descriptors.First().Value.PropertyName.Should().Be("TestProperty");
            annotator.Descriptors.First().Value.ModelResourceTypeFullName.Should().Be(typeof(ModelTestResource).FullName);
        }

        [Fact]
        public void ThrowsArgumentException_GivenInvalidExpression()
        {
            var annotator = new TestAnnotatorEmpty() { ResourceTypeFullName = typeof(ModelTestResource).FullName };

            Func<IAnnotationBuilder> func = () => annotator.DefineFor<string>(x => "");

            func.Should().Throw<ArgumentException>().WithMessage("The input should be a selector expression, in form: 'x => x.Property'!");
        }
    }
}
