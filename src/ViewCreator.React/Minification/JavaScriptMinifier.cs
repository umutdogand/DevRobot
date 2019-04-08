/* Originally written in 'C', this code has been converted to the C# language.
 * The author's copyright message is reproduced below.
 * All modifications from the original to C# are placed in the public domain.
 */

/* jsmin.c
   2007-05-22

Copyright (c) 2002 Douglas Crockford  (www.crockford.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

The Software shall be used for Good, not Evil.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.IO;

namespace ViewCreator.React.Minification
{
    public class JavaScriptMinifier
    {
        const int EOF = -1;

        StreamReader sr;
        StringWriter sw;
        int theA;
        int theB;
        int theLookahead = EOF;

        //static void Main(string[] args)
        //{
        //    if (args.Length != 2)
        //    {
        //        Console.WriteLine("invalid arguments, 2 required, 1 in, 1 out");
        //        return;
        //    }
        //    new JavaScriptMinifier().Minify(args[0], args[1]);
        //}

        public string Minify(string src) //removed the out file path
        {
            using (sr = new StreamReader(src))
            {
                using (sw = new StringWriter())  //used to be a StreamWriter
                {
                    Jsmin();
                    return sw.ToString(); // return the minified string
                }
            }
        }

        /* jsmin -- Copy the input to the output, deleting the characters which are
                insignificant to JavaScript. Comments will be removed. Tabs will be
                replaced with spaces. Carriage returns will be replaced with linefeeds.
                Most spaces and linefeeds will be removed.
        */
        private void Jsmin()
        {
            theA = '\n';
            Action(3);
            while (theA != EOF)
            {
                switch (theA)
                {
                    case ' ':
                        {
                            if (IsAlphanum(theB))
                            {
                                Action(1);
                            }
                            else
                            {
                                Action(2);
                            }
                            break;
                        }
                    case '\n':
                        {
                            switch (theB)
                            {
                                case '{':
                                case '[':
                                case '(':
                                case '+':
                                case '-':
                                    {
                                        Action(1);
                                        break;
                                    }
                                case ' ':
                                    {
                                        Action(3);
                                        break;
                                    }
                                default:
                                    {
                                        if (IsAlphanum(theB))
                                        {
                                            Action(1);
                                        }
                                        else
                                        {
                                            Action(2);
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            switch (theB)
                            {
                                case ' ':
                                    {
                                        if (IsAlphanum(theA))
                                        {
                                            Action(1);
                                            break;
                                        }
                                        Action(3);
                                        break;
                                    }
                                case '\n':
                                    {
                                        switch (theA)
                                        {
                                            case '}':
                                            case ']':
                                            case ')':
                                            case '+':
                                            case '-':
                                            case '"':
                                            case '\'':
                                                {
                                                    Action(1);
                                                    break;
                                                }
                                            default:
                                                {
                                                    if (IsAlphanum(theA))
                                                    {
                                                        Action(1);
                                                    }
                                                    else
                                                    {
                                                        Action(3);
                                                    }
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        Action(1);
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }

        /* action -- do something! What you do is determined by the argument:
                1   Output A. Copy B to A. Get the next B.
                2   Copy B to A. Get the next B. (Delete A).
                3   Get the next B. (Delete B).
           action treats a string as a single character. Wow!
           action recognizes a regular expression if it is preceded by ( or , or =.
        */
        private void Action(int d)
        {
            if (d <= 1)
            {
                Put(theA);
            }
            if (d <= 2)
            {
                theA = theB;
                if (theA == '\'' || theA == '"')
                {
                    for (; ; )
                    {
                        Put(theA);
                        theA = Get();
                        if (theA == theB)
                        {
                            break;
                        }
                        if (theA <= '\n')
                        {
                            throw new System.Exception(string.Format("Error: JSMIN unterminated string literal: {0}\n", theA));
                        }
                        if (theA == '\\')
                        {
                            Put(theA);
                            theA = Get();
                        }
                    }
                }
            }
            if (d <= 3)
            {
                theB = Next();
                if (theB == '/' && (theA == '(' || theA == ',' || theA == '=' ||
                                    theA == '[' || theA == '!' || theA == ':' ||
                                    theA == '&' || theA == '|' || theA == '?' ||
                                    theA == '{' || theA == '}' || theA == ';' ||
                                    theA == '\n'))
                {
                    Put(theA);
                    Put(theB);
                    for (; ; )
                    {
                        theA = Get();
                        if (theA == '/')
                        {
                            break;
                        }
                        else if (theA == '\\')
                        {
                            Put(theA);
                            theA = Get();
                        }
                        else if (theA <= '\n')
                        {
                            throw new System.Exception(string.Format("Error: JSMIN unterminated Regular Expression literal : {0}.\n", theA));
                        }
                        Put(theA);
                    }
                    theB = Next();
                }
            }
        }

        /* next -- get the next character, excluding comments. peek() is used to see
                if a '/' is followed by a '/' or '*'.
        */
        private int Next()
        {
            int c = Get();
            if (c == '/')
            {
                switch (Peek())
                {
                    case '/':
                        {
                            for (; ; )
                            {
                                c = Get();
                                if (c <= '\n')
                                {
                                    return c;
                                }
                            }
                        }
                    case '*':
                        {
                            Get();
                            for (; ; )
                            {
                                switch (Get())
                                {
                                    case '*':
                                        {
                                            if (Peek() == '/')
                                            {
                                                Get();
                                                return ' ';
                                            }
                                            break;
                                        }
                                    case EOF:
                                        {
                                            throw new System.Exception("Error: JSMIN Unterminated comment.\n");
                                        }
                                }
                            }
                        }
                    default:
                        {
                            return c;
                        }
                }
            }
            return c;
        }

        /* peek -- get the next character without getting it.
        */
        private int Peek()
        {
            theLookahead = Get();
            return theLookahead;
        }

        /* get -- return the next character from stdin. Watch out for lookahead. If
                the character is a control character, translate it to a space or
                linefeed.
        */
        private int Get()
        {
            int c = theLookahead;
            theLookahead = EOF;
            if (c == EOF)
            {
                c = sr.Read();
            }
            if (c >= ' ' || c == '\n' || c == EOF)
            {
                return c;
            }
            if (c == '\r')
            {
                return '\n';
            }
            return ' ';
        }

        private void Put(int c)
        {
            sw.Write((char)c);
        }

        /* isAlphanum -- return true if the character is a letter, digit, underscore,
                dollar sign, or non-ASCII character.
        */
        private bool IsAlphanum(int c)
        {
            return ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') ||
                (c >= 'A' && c <= 'Z') || c == '_' || c == '$' || c == '\\' ||
                c > 126);
        }
    }
}