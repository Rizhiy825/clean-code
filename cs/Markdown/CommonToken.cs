﻿namespace Markdown
{
    public class CommonToken : Token
    {
        public string text;

        public CommonToken(string text, int startIndex)
        {
            this.text = text;
            length = text.Length;
            this.startIndex = startIndex;
        }
    }
}