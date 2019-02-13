namespace ViewCreator.Components
{
    public partial class HtmlFeaturesFactory
    {
        public const string TypeKey = "type";
        public const string ValueKey = "value";
        public const string AutofocusKey = "autofocus";
        public const string DisabledKey = "disabled";
        public const string FormKey = "form";
        public const string FormActionKey = "formaction";

        public static IHtmlFeature Value(string value)
        {
            return new HtmlFeature(ValueKey, value);
        }

        public static IHtmlFeature Autofocus(string value)
        {
            return new HtmlFeature(AutofocusKey, value);
        }

        public static IHtmlFeature Disabled(string value)
        {
            return new HtmlFeature(DisabledKey, value);
        }

        public static IHtmlFeature Form(string value)
        {
            return new HtmlFeature(FormKey, value);
        }

        public static IHtmlFeature FormAction(string value)
        {
            return new HtmlFeature(FormActionKey, value);
        }
    }
}