﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class ConcatContainer
        : Pattern
    {
        private readonly object _content;

        public ConcatContainer(object content)
        {
            _content = content ?? throw new ArgumentNullException(nameof(content));
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            if (_content is object[] values)
            {
                for (int i = 0; i < values.Length; i++)
                    builder.Append(values[i]);
            }
            else if (_content is IEnumerable items)
            {
                foreach (object item in items)
                    builder.Append(item);
            }
        }
    }
}
