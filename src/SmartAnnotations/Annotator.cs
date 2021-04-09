using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SmartAnnotations
{
    public abstract class Annotator<T> : AnnotationContext
    {
        public Annotator() : base(typeof(T).Name, typeof(T).Namespace)
        {
        }

        public IContextBuilder Define()
        {
            return new ContextBuilder(this);
        }

        public IAnnotationBuilder DefineFor<TProperty>(Expression<Func<T, TProperty>> selector)
        {
            if (selector.Body is MemberExpression memberExpression)
            {
                var annotationDescriptor = new AnnotationDescriptor(memberExpression.Member.Name, this.ResourceTypeFullName);

                base.AddDescriptor(annotationDescriptor);

                return new AnnotationBuilder(annotationDescriptor);
            }

            throw new ArgumentException("The input should be a selector expression, in form: 'x => x.Property'!");
        }
    }
}
