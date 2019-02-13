namespace ViewCreator.Components
{
    public partial class HtmlFeaturesFactory
    {
        #region Fields

        public const string NameKey = "name";
        public const string ClassKey = "class";
        public const string StyleKey = "style";
        public const string OnMouseDownKey = "onmousedown";
        public const string OnMouseMoveKey = "onmousemove";
        public const string OnmouseOutKey = "onmouseout";
        public const string OnMouseOverKey = "onmouseover";
        public const string OnMouseUpKey = "onmouseup";
        public const string OnMouseWheelKey = "onmousewheel";

        #endregion

        public static IHtmlFeature Type(string type)
        {
            return new HtmlFeature(TypeKey, type);
        }

        public static IHtmlFeature Name(string name)
        {
            return new HtmlFeature(NameKey, name);
        }

        public static IHtmlFeature Class(string @class)
        {
            return new HtmlFeature(ClassKey, @class);
        }

        public static IHtmlFeature Style(string style)
        {
            return new HtmlFeature(StyleKey, style);
        }

        public static IHtmlFeature OnMouseDown(string val)
        {
            return new HtmlFeature(OnMouseDownKey, val);
        }

        public static IHtmlFeature OnMouseMove(string val)
        {
            return new HtmlFeature(OnMouseMoveKey, val);
        }

        public static IHtmlFeature OnmouseOut(string val)
        {
            return new HtmlFeature(OnmouseOutKey, val);
        }

        public static IHtmlFeature OnMouseOver(string val)
        {
            return new HtmlFeature(OnMouseOverKey, val);
        }

        public static IHtmlFeature OnMouseUp(string val)
        {
            return new HtmlFeature(OnMouseUpKey, val);
        }

        public static IHtmlFeature OnMouseWheel(string val)
        {
            return new HtmlFeature(OnMouseWheelKey, val);
        }
    }
}