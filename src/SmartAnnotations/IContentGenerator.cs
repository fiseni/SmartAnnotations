﻿using SmartAnnotations.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartAnnotations
{
    public interface IContentGenerator<in T>
    {
        string GetContent(T descriptor);
    }
}
