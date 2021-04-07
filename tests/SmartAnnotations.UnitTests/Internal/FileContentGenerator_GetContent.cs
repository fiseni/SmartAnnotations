using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartAnnotations.UnitTests.Internal
{
    public class FileContentGenerator_GetContent
    {
        [Fact]
        public void ReturnsEmptyLayout_GivenNoDescriptors()
        {
            var generator = new FileContentGenerator(new TestAnnotatorEmpty());

            generator.GetContent().Should().Be(GetContentForTestAnnotatorEmpty());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAnnotation()
        {
            var generator = new FileContentGenerator(new TestAnnotatorWithDisplayName());

            generator.GetContent().Should().Be(GetContentForTestAnnotatorWithDisplayName());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAndReadOnlyAnnotations()
        {
            var generator = new FileContentGenerator(new TestAnnotatorWithDisplayNameAndReadOnly());

            generator.GetContent().Should().Be(GetContentForTestAnnotatorWithDisplayNameAndReadOnly());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAnnotationAndAdditionalInvalidDescriptor()
        {
            var context = new TestAnnotatorWithDisplayName();
            context.AddDescriptor(new AnnotationDescriptor("someProperty", typeof(string)));

            var generator = new FileContentGenerator(context);

            generator.GetContent().Should().Be(GetContentForTestAnnotatorWithDisplayName());
        }

        private partial class TestType
        {
            public string? TestProperty { get; set; } = null;
            public string? TestProperty2 { get; set; } = null;
        }
        private class TestAnnotatorEmpty : Annotator<TestType>
        {
        }
        private class TestAnnotatorWithDisplayName : Annotator<TestType>
        {
            public TestAnnotatorWithDisplayName()
            {
                DefineFor(x => x.TestProperty).Display().Name("SomeName");
            }
        }
        private class TestAnnotatorWithDisplayNameAndReadOnly : Annotator<TestType>
        {
            public TestAnnotatorWithDisplayNameAndReadOnly()
            {
                DefineFor(x => x.TestProperty).Display().Name("SomeName");
                DefineFor(x => x.TestProperty2).ReadOnly(true);
            }
        }

        private string GetContentForTestAnnotatorEmpty()
        {
            return
@"using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartAnnotations.UnitTests.Internal
{
    [MetadataType(typeof(TestTypeMetaData))]
    public partial class TestType 
    {
    }

    public class TestTypeMetaData 
    {

    }
}
";
        }
        private string GetContentForTestAnnotatorWithDisplayName()
        {
            return
@"using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartAnnotations.UnitTests.Internal
{
    [MetadataType(typeof(TestTypeMetaData))]
    public partial class TestType 
    {
    }

    public class TestTypeMetaData 
    {
        [Display(Name = ""SomeName"")]
        public object TestProperty;

    }
}
";
        }

        private string GetContentForTestAnnotatorWithDisplayNameAndReadOnly()
        {
            return
@"using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartAnnotations.UnitTests.Internal
{
    [MetadataType(typeof(TestTypeMetaData))]
    public partial class TestType 
    {
    }

    public class TestTypeMetaData 
    {
        [Display(Name = ""SomeName"")]
        public object TestProperty;

        [ReadOnly(true)]
        public object TestProperty2;

    }
}
";
        }
    }
}
