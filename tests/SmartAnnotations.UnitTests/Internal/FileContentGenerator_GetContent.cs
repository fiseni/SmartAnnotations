using FluentAssertions;
using SmartAnnotations.DisplayAttribute;
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
            var generator = new FileContentGenerator(new TestAnnotatorWithDisplayNameAndReadOnly("SomeName"));

            generator.GetContent().Should().Be(GetContentForTestAnnotatorWithDisplayNameAndReadOnly());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAnnotation()
        {
            var generator = new FileContentGenerator(new TestAnnotatorWithDisplayName("SomeName"));

            generator.GetContent().Should().Be(GetContentForTestAnnotatorWithDisplayName());
        }

        [Fact]
        public void ReturnsMetadataWithDisplayAttribute_GivenDisplayNameAnnotationAndAdditionalInvalidDescriptor()
        {
            var context = new TestAnnotatorWithDisplayName("SomeName");
            context.AddDescriptor(new AnnotationDescriptor("SomeProperty", typeof(string)));

            var generator = new FileContentGenerator(context);

            generator.GetContent().Should().Be(GetContentForTestAnnotatorWithDisplayName());
        }

        [Fact]
        public void ReturnsEmptyLayout_GivenNoDescriptors()
        {
            var generator = new FileContentGenerator(new TestAnnotatorEmpty());

            generator.GetContent().Should().Be(GetContentForTestAnnotatorEmpty());
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
