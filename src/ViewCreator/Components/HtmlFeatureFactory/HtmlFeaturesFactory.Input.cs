namespace ViewCreator.Components
{
    public partial class HtmlFeaturesFactory
    {
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

        public static IHtmlFeature Type(InputType type)
        {
            return new HtmlFeature(TypeKey, type.Value);
        }
        public static IHtmlFeature Accept(string value)
        {
            return new HtmlFeature(AcceptKey, value);
        }
        public static IHtmlFeature Alt(string value)
        {
            return new HtmlFeature(AltKey, value);
        }
        public static IHtmlFeature Autocomplete(string value)
        {
            return new HtmlFeature(AutocompleteKey, value);
        }
        public static IHtmlFeature Checked(string value)
        {
            return new HtmlFeature(CheckedKey, value);
        }
        public static IHtmlFeature Dirname(string value)
        {
            return new HtmlFeature(DirnameKey, value);
        }
        public static IHtmlFeature Height(string value)
        {
            return new HtmlFeature(HeightKey, value);
        }
        public static IHtmlFeature List(string value)
        {
            return new HtmlFeature(ListKey, value);
        }
        public static IHtmlFeature Max(string value)
        {
            return new HtmlFeature(MaxKey, value);
        }
        public static IHtmlFeature Maxlength(string value)
        {
            return new HtmlFeature(MaxlengthKey, value);
        }
        public static IHtmlFeature Min(string value)
        {
            return new HtmlFeature(MinKey, value);
        }
        public static IHtmlFeature Multiple(string value)
        {
            return new HtmlFeature(MultipleKey, value);
        }
        public static IHtmlFeature Pattern(string value)
        {
            return new HtmlFeature(PatternKey, value);
        }
        public static IHtmlFeature Placeholder(string value)
        {
            return new HtmlFeature(PlaceholderKey, value);
        }
        public static IHtmlFeature Readonly(string value)
        {
            return new HtmlFeature(ReadonlyKey, value);
        }
        public static IHtmlFeature Required(string value)
        {
            return new HtmlFeature(RequiredKey, value);
        }
        public static IHtmlFeature Size(string value)
        {
            return new HtmlFeature(SizeKey, value);
        }
        public static IHtmlFeature Src(string value)
        {
            return new HtmlFeature(SrcKey, value);
        }
        public static IHtmlFeature Width(string value)
        {
            return new HtmlFeature(WidthKey, value);
        }
    }
}