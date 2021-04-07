using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.UnitTests.Fixture
{
    public class TestAnnotatorWithDisplayName : Annotator<TestType>
    {
        public TestAnnotatorWithDisplayName(string displayName)
        {
            DefineFor(x => x.TestProperty).Display().Name(displayName);
        }
    }
}
