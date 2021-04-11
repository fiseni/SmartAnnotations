using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public class RangeAttributeDescriptor : ValidationAttributeDescriptor
    {
        internal RangeAttributeDescriptor(int minimum, int maximum, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            this.MinimumAsString = minimum.ToString();
            this.MaximumAsString = maximum.ToString();
            this.OperandTypeFullName = null;
        }

        internal RangeAttributeDescriptor(double minimum, double maximum, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            this.MinimumAsString = minimum.ToString() + "d";
            this.MaximumAsString = maximum.ToString() + "d";
            this.OperandTypeFullName = null;
        }

        internal RangeAttributeDescriptor(string typeFullName, string minimum, string maximum, string? resourceTypeFullName = null, string? modelResourceTypeFullName = null)
            : base(resourceTypeFullName, modelResourceTypeFullName)
        {
            if (string.IsNullOrWhiteSpace(typeFullName)) throw new ArgumentNullException(nameof(typeFullName));
            if (string.IsNullOrWhiteSpace(minimum)) throw new ArgumentNullException(nameof(minimum));
            if (string.IsNullOrWhiteSpace(maximum)) throw new ArgumentNullException(nameof(maximum));

            this.MinimumAsString = $"\"{minimum}\"";
            this.MaximumAsString = $"\"{maximum}\"";
            this.OperandTypeFullName = typeFullName;
        }

        internal string MinimumAsString { get; }
        internal string MaximumAsString { get; }
        internal string? OperandTypeFullName { get; }
    }
}
