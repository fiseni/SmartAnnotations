using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.Sample.ConsoleNETFX
{
    // Re-build the project and you can check the generated files under "obj" folder.
    public class FooAnnotator : Annotator<Foo>
    {
        public FooAnnotator()
        {
            DefineFor(x => x.Id).ReadOnly();

            DefineFor(x => x.FirstName)
                .Required().Message("First Name is required.")
                .Display().Name("First Name").Prompt("Please enter your first name.");

            DefineFor(x => x.LastName)
                .Required().AllowEmptyStrings().Message("Last Name is required.")
                .Display().Name("Last Name").Prompt("Please enter your last name.");

            DefineFor(x => x.Email)
                .Required().AllowEmptyStrings(); // If you ommit the message, the default error message is used.
                // Email and other validation attributes will be added soon.
        }
    }
}
