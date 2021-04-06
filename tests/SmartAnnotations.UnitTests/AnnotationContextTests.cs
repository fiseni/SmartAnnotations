using FluentAssertions;
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
        public void ThrowsArgumentNullException_GivenNullInConstructor()
        {
            Action action = () => new TestAnnotator();

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("type");
        }

        private class TestAnnotator : AnnotationContext
        {
            public TestAnnotator() : base(null!)
            {
            }
        }
    }
}
