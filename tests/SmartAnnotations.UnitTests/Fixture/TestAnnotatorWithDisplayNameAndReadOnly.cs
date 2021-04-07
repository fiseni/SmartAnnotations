using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.UnitTests.Fixture
{
    public class TestAnnotatorWithDisplayNameAndReadOnly : Annotator<TestType>
    {
        public TestAnnotatorWithDisplayNameAndReadOnly(string displayName)
        {
            DefineFor(x => x.TestProperty).Display().Name(displayName);
            DefineFor(x => x.TestProperty2).ReadOnly(true);
        }
    }
}
