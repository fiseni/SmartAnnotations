using SmartAnnotations.Attributes.Compare;
using SmartAnnotations.Attributes.CreditCard;
using SmartAnnotations.Attributes.Display;
using SmartAnnotations.Attributes.DisplayFormat;
using SmartAnnotations.Attributes.EmailAddress;
using SmartAnnotations.Attributes.MaxLength;
using SmartAnnotations.Attributes.MinLength;
using SmartAnnotations.Attributes.Phone;
using SmartAnnotations.Attributes.Range;
using SmartAnnotations.Attributes.ReadOnly;
using SmartAnnotations.Attributes.Required;
using SmartAnnotations.Attributes.StringLength;
using SmartAnnotations.Attributes.Url;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations.Internal
{
    internal class AttributeGeneratorProvider
    {
        private AttributeGeneratorProvider() { }
        internal static AttributeGeneratorProvider Instance { get; } = new();

        internal IAttributeGenerator[] Generators { get; }
            = new IAttributeGenerator[]
        {
            ReadOnlyAttributeGenerator.Instance,
            RequiredAttributeGenerator.Instance,
            DisplayAttributeGenerator.Instance,
            DisplayFormatAttributeGenerator.Instance,
            StringLengthAttributeGenerator.Instance,
            MaxLengthAttributeGenerator.Instance,
            MinLengthAttributeGenerator.Instance,
            CompareAttributeGenerator.Instance,
            RangeAttributeGenerator.Instance,
            EmailAddressAttributeGenerator.Instance,
            CreditCardAttributeGenerator.Instance,
            PhoneAttributeGenerator.Instance,
            UrlAttributeGenerator.Instance
        };
    }
}
