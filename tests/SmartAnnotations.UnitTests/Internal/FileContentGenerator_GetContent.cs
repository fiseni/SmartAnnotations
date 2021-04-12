using FluentAssertions;
using SmartAnnotations.Attributes.Display;
using SmartAnnotations.Internal;
using SmartAnnotations.UnitTests.Fixture;
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
        public void ReturnsMetadataWithDisplayAndReadOnlyAttributes_GivenDisplayNameAndReadOnlyAnnotations()
        {
            var content = FileContentGenerator.Instance.GetContent(new TestAnnotatorWithDisplayNameAndReadOnly("SomeName"));

            content.Should().Be(GetContentForTestAnnotatorWithDisplayNameAndReadOnly());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAnnotation()
        {
            var content = FileContentGenerator.Instance.GetContent(new TestAnnotatorWithDisplayName("SomeName"));

            content.Should().Be(GetContentForTestAnnotatorWithDisplayName());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAnnotationAndAdditionalEmptyDescriptor()
        {
            var context = new TestAnnotatorWithDisplayName("SomeName");
            context.AddDescriptor(new AnnotationDescriptor("SomeProperty"));

            var content = FileContentGenerator.Instance.GetContent(context);

            content.Should().Be(GetContentForTestAnnotatorWithDisplayName());
        }

        [Fact]
        public void ReturnsEmptyLayout_GivenNoDescriptors()
        {
            var content = FileContentGenerator.Instance.GetContent(new TestAnnotatorEmpty());

            content.Should().Be(GetContentForTestAnnotatorEmpty());
        }


        private string GetContentForTestAnnotatorEmpty()
        {
            return
@"using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartAnnotations.UnitTests.Fixture
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

namespace SmartAnnotations.UnitTests.Fixture
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

namespace SmartAnnotations.UnitTests.Fixture
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
