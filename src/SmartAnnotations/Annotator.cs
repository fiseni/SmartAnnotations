﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SmartAnnotations
{
    public abstract class Annotator<T> : AnnotationContext
    {
        public Annotator() : base(typeof(T))
        {
        }

        public IContextBuilder Define()
        {
            return new ContextBuilder(this);
        }

        public IAnnotationBuilder<TProperty> DefineFor<TProperty>(Expression<Func<T, TProperty>> selector)
        {
            if (selector.Body is MemberExpression memberExpression)
            {
                var descriptor = new AnnotationDescriptor(memberExpression.Member.Name, typeof(TProperty), this.ResourceType);

                base.AddDescriptor(descriptor);

                return new AnnotationBuilder<TProperty>(descriptor);
            }

            throw new ArgumentException("The input should be a selector expression, in form: 'x => x.Property'!");
        }
    }
}