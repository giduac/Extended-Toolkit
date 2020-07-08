﻿using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class Subset : ParseElement, ISubset, IElement
    {
        public Subset(ParseElementCollection parent, Backend backend, string text, MatchMode mode)
            : base(parent._rule)
        {
            char[] achTrimChars = Helpers._achTrimChars;
            foreach (char c in achTrimChars)
            {
                if (c != ' ' && text.IndexOf(c) >= 0)
                {
                    text = text.Replace(c, ' ');
                }
            }
            parent.AddArc(backend.SubsetTransition(text, mode));
        }

        void IElement.PostParse(IElement parentElement)
        {
        }
    }
}