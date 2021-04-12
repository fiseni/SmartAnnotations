using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.Sample.ConsoleNET
{
    // Run "dotnet clean | dotnet build" and you can check the generated files under "obj" folder.
    public class FooAnnotator : Annotator<Foo>
    {
        public FooAnnotator()
        {
            Define().ResourceType(typeof(FooResource));

            DefineFor(x => x.Id).ReadOnly();

            DefineFor(x => x.FirstName)
                .Required().Key("FirstNameRequired") // If you ommit the key or message, the default error message is used.
                .Display().Name("FirstNameKey").Prompt("FirstNamePromptKey");

            DefineFor(x => x.LastName)
                .Required().AllowEmptyStrings().Message("This is the message itself, not a key to resource file.")
                .Display().Name("LastNameKey").Prompt(nameof(FooResource.LastNamePromptKey)); // You can use it this way to avoid magic strings.

            DefineFor(x => x.Quantity)
                .Range(1, 10);

            DefineFor(x => x.Weight)
                .DisplayFormat().DataFormatString("{0:n2} Kg.");

            DefineFor(x => x.Email)
                .Display().Name(nameof(FooResource.EmailNameKey)).Prompt(nameof(FooResource.EmailPromptKey)) 
                .Email();

            DefineFor(x => x.Password)
                .DataType(DataTypeEnum.Password)
                .Min(6)
                .Max(150);

            DefineFor(x => x.ConfirmPassword)
                .DataType(DataTypeEnum.Password)
                .Compare(nameof(Foo.Password))
                .Min(6)
                .Max(150);

            DefineFor(x => x.Phone)
                .Phone();

            DefineFor(x => x.CreditCard)
                .CreditCard();

            DefineFor(x => x.Url)
                .Url();
        }
    }
}
