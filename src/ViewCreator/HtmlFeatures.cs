namespace ViewCreator
{
    using ViewCreator.Components;

    public static class HtmlFeatures
    {
        /// <summary>
        /// Elementin tagları arasındaki değeri tanımlar
        /// </summary>
        public const string ElementContentType = "elementcontent";

        public const string NameKey = "name";
        public const string ClassKey = "class";
        public const string StyleKey = "style";
        public const string OnMouseDownKey = "onmousedown";
        public const string OnMouseMoveKey = "onmousemove";
        public const string OnmouseOutKey = "onmouseout";
        public const string OnMouseOverKey = "onmouseover";
        public const string OnMouseUpKey = "onmouseup";
        public const string OnMouseWheelKey = "onmousewheel";

        public const string TypeKey = "type";
        public const string ValueKey = "value";
        public const string AutofocusKey = "autofocus";
        public const string DisabledKey = "disabled";
        public const string FormKey = "form";
        public const string FormActionKey = "formaction";

        public const string ForKey = "for";

        public const string AcceptKey = "accept";
        public const string AltKey = "alt";
        public const string AutocompleteKey = "autocomplete";
        public const string CheckedKey = "checked";
        public const string DirnameKey = "dirname";
        public const string HeightKey = "height";
        public const string ListKey = "list";
        public const string MaxKey = "max";
        public const string MaxlengthKey = "maxlength";
        public const string MinKey = "min";
        public const string MultipleKey = "multiple";
        public const string PatternKey = "pattern";
        public const string PlaceholderKey = "placeholderr";
        public const string ReadonlyKey = "readonly";
        public const string RequiredKey = "required";
        public const string SizeKey = "size";
        public const string SrcKey = "src";
        public const string WidthKey = "width";

        public static HtmlFeature Create(string key, string value)
        {
            return new HtmlFeature(key, value);
        }
    }
}