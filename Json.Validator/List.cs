﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Optional(
                new Sequence(
                    element,
                    new Many(
                        new Sequence(
                            separator,
                            element))));
        }

        public IMatch Match(StringView text)
        {
            return pattern.Match(text);
        }
    }
}
