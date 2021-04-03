<img align="left" src="docs/pozitronlogo.png" width="120" height="120">

&nbsp;

# SmartAnnotations

A library for .NET that uses source generators to automatically generate data annotations for your models. It provides a strongly-typed mechanism to define your annotation rules.

## Motivation

Data Annotations are attributes that are applied to the class or members that specify validation rules and how the data is displayed. They've been around for a long time, and there is great support across various frameworks in the .NET ecosystem. There is built-in support in Winform/WPF controls (e.g., grid controls, edit forms), ASP.NET MVC/Razor Pages, EntityFramework, Blazor (support for validation attributes was added recently), and many other frameworks. If you're applying localization in your applications, annotations are a great mechanism to localize the labels for your properties and define how the data will be formatted and displayed (e.g., date formats, numeric formats). Keeping these concerns bundled with your models might simplify the usage significantly and you'll avoid duplication throughout your code. Having said all that, I'm a fan of annotations and tend to use them wherever possible. But, there is a "huge" downside of utilizing them. Your models become cluttered with these extra attributes. For example, let's take this very simple model.

```c#
public class Login
{
    [Display(Order = 1, Name = "Username", Prompt = "Enter your username", ResourceType = typeof(AppResources))]
    [Required(ErrorMessageResourceName = "UsernameRequired", ErrorMessageResourceType = typeof(AppResources))]
    [StringLength(150, MinimumLength = 6, ErrorMessageResourceName ="UsernameLength", ErrorMessageResourceType =typeof(AppResources))]
    public string Username { get; set; }

    [Display(Order = 2, Name = "Password", Prompt = "Password", ResourceType = typeof(AppResources))]
    [Required(ErrorMessageResourceName ="PasswordRequired", ErrorMessageResourceType =typeof(AppResources))]
    [StringLength(100, MinimumLength = 8, ErrorMessageResourceName = "Password", ErrorMessageResourceType = typeof(AppResources))]
    [DataType(DataType.Password, ErrorMessageResourceName = "PasswordDataType", ErrorMessageResourceType = typeof(AppResources))]
    public string Password { get; set; }

    [Display(Name = "RememberMe", ResourceType = typeof(AppResources))]
    public bool RememberMe { get; set; } = false;
}
```

There is way too much noise in this code. In real-world applications where your models may contain several properties, it gets a challenge to work and maintain these constructs. That's exactly what this library tries to address. You can keep your models clean, and define the annotations in a strongly typed manner in separate constructs. The library will analyze your definitions and produce adequate metadata constructs for your models. <strong>Practically, you'll get the best of both approaches, data annotations, and fluent-like configurations.</strong>

### Why should I use this library instead of manually creating the metadata classes?

You indeed can manually create the metadata for your models. But, maintaining them is really hard and keeping these constructs in sync is a tedious task. By using this library you'll get the following advantages:
- All annotations are defined in a strongly typed manner. Therefore, it's much easier to refactor your models (e.g., renaming properties), and you'll get compile-time exceptions if anything is misconfigured or gets out of sync.
- One of the biggest issues with annotations is that you have to provide the `ResourceType = typeof(YourResourceFileType)` for each and single attribute for all your properties in your model. It's even worse for the validation attributes, you have to provide `ErrorMessageResourceType = typeof(YourResourceFileType))` and `ErrorMessageResourceType = "ResourceKey"`. These definitions create a huge mess in your models. Now, you'll be able to define your resource file once, and it will be added for all the attributes automatically (wherever it is required).
- We do plan to add global definitions in the next versions. For example, you'll be able to define your resource file for all your models in the application.
- In future releases, we might add a feature for convention-based global definitions. For example, define annotations for a property called "Name" in any of your models (list of models might be configured explicitly, or just annotate them with class attribute).
- Once you have defined your annotations, we may also provide an API to manually validate your models if required. We don't see this as a replacement for any other validation libraries. FluentValidation is an awesome and fully featured library. You may want to utilize those alternatives for validation concerns.


## Getting started

The library has support for `NET Framework` and `.NET`, and can be installed on both platforms. You can find the Nuget package as `SmartAnnotation` and you may install it through the Visual Studio package manager or the dotnet CLI.

- Add the Nuget package to each of your projects that contain the models and the annotators. Source generators are project scoped, and the generation will occur for each project containing the package.
- Add the required references for data annotations (`System.ComponentModel` and `System.ComponentModel.DataAnnotations` namespaces). This is no different from adding the attributes manually. For `.NET Framework` projects you may reference the required assembly or add the `System.ComponentModel.Annotations` Nuget package. Same for the `.NET` projects. This library just generates the content and does not constrain you with specific references. This is a deliberate decision, not to interfere with your configuration, so you can configure your dependencies based on your TFM.
- If you want to see the generated content, edit your project file and add the following section. The generated files will be written under `obj` directory.
```c#
<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
<CompilerGeneratedFilesOutputPath>$(BaseIntermediateOutputPath)\GeneratedFiles</CompilerGeneratedFilesOutputPath>
```

### Important notice!

Sadly, there are few caveats, mostly related to the environment and the runtime support.

- There are no limitations for `.NET Framework` projects. You can build your application through Visual Studio or CLI without issues.
- If you're using the library in `.NET` projects, you will be able to successfully build with `dotnet build` (I suggest you use `dotnet clean | dotnet build`). But, the source generation won't work if you're building the project through Visual Studio. The issue is not related to msbuild, but the fact that VS is running on `.NET Framework` and won't be able to load the `.NET` assembly.
- Unfortunately, there is no support for `.NET Standard 2.0` projects. The data annotations are not part of `.NET Standard`, and the corresponding Nuget package does not contain `MetadataType` attribute for this TFM. There are few active issues on `dotnet/runtime`, and it's unclear if this attribute will be added.

The source generation feature is still in its infancy, and I do believe there will be much better support in the future.


## Usage

The usage is quite straightforward, and we tried to provide a nice API for building the annotations.
- Define your models as `partial`
- Create annotators for your models by inheriting from `Annotator<>` base class. We suggest you keep the models and the annotators in the same assembly.

Sample model:

```c#
public partial class Foo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
}
```

Sample annotator for the given model:

```c#
public class FooAnnotator : Annotator<Foo>
{
    public FooAnnotator()
    {
        Define().ResourceType(typeof(AppResources));

        DefineFor(x => x.Id).ReadOnly(true);

        DefineFor(x => x.Name).Required().Key("NameRequired")
                                .Display().Order(1).Name("NameKey")
                                .StringLenth(6, 150).Key("NameLength");

        // You can define your resource file per attribute too.
        DefineFor(x => x.Weight).Required().Message("This is my message, not a key to my resourceFile")
                                .Display(typeof(AppResources)).Order(2).Name("PriceX")
                                .DisplayFormat().FormatString("{0:n2} Kg").ApplyFormatInEditMode();
    }
}
```

Once you build the project, the following content will be autogenereted for the given model.

```c#
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartAnnotations.Sample
{
    [MetadataType(typeof(FooMetaData))]
    public partial class Foo
    {
    }

    public class FooMetaData
    {
        [ReadOnly(true)]
        public object Id;

        [Display(Order = 1, Name = "NameKey", ResourceType = typeof(AppResources))]
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(AppResources))]
        [StringLength(150, MinimumLength = 6, ErrorMessageResourceName = "NameLength", ErrorMessageResourceType = typeof(AppResources))]
        public object Name;

        [Display(Order = 2, Name = "PriceX", ResourceType = typeof(AppResources))]
        [Required(ErrorMessage = "This is my message, not a key to my resourceFile")]
        [DisplayFormat(DataFormatString = "{0:n2} Kg", ApplyFormatInEditMode = false)]
        public object Weight;
    }
}
```

You can find more samples under `sample` folder in this repository.


## Features

In the preview version, initially, there is support for the following features.
- Ability to specify a single resource file per model.
- Display attribute support (Order, Name, ShortName, Description, Prompt, GroupName, AutogeneratedField, AutogeneratedFilter, ResourceType).
- Required attribute support (ErrorMessage, ResourceType, and ResourceKey).
- ReadOnly attribute support.

We do plan to add the following features for `v1.0`.
- DisplayFormat attribute support.
- StringLength attribute support.
- Max attribute support.
- Min attribute support.
- Email attribute support.
- DataType attribute support.
- Compare attribute support.
- Range attribute support.
- NotDefault support through a custom attribute.


## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!

