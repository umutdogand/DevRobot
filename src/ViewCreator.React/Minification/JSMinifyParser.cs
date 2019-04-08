namespace ViewCreator.React.Minification
{
    internal class JSMinifyParser : IFileParser
    {
        #region IFileParser Members

        public string Parse(string s)
        {
            JavaScriptMinifier mini = new JavaScriptMinifier();
            string outs = mini.Minify(s);
            return outs;
        }

        #endregion
    }
}