﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartAnnotations.Sample.ConsoleNET {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class FooResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FooResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SmartAnnotations.Sample.ConsoleNET.FooResource", typeof(FooResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-mail.
        /// </summary>
        internal static string EmailNameKey {
            get {
                return ResourceManager.GetString("EmailNameKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter your e-mail..
        /// </summary>
        internal static string EmailPromptKey {
            get {
                return ResourceManager.GetString("EmailPromptKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First Name.
        /// </summary>
        internal static string FirstNameKey {
            get {
                return ResourceManager.GetString("FirstNameKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter your first name..
        /// </summary>
        internal static string FirstNamePromptKey {
            get {
                return ResourceManager.GetString("FirstNamePromptKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First Name is required..
        /// </summary>
        internal static string FirstNameRequired {
            get {
                return ResourceManager.GetString("FirstNameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last Name.
        /// </summary>
        internal static string LastNameKey {
            get {
                return ResourceManager.GetString("LastNameKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter your last name..
        /// </summary>
        internal static string LastNamePromptKey {
            get {
                return ResourceManager.GetString("LastNamePromptKey", resourceCulture);
            }
        }
    }
}