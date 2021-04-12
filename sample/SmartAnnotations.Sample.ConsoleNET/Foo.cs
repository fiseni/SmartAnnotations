using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAnnotations.Sample.ConsoleNET
{
    // Run "dotnet clean | dotnet build" and you can check the generated files under "obj" folder.
    public partial class Foo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Weight { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string CreditCard { get; set; }
        public string Url { get; set; }
    }
}
