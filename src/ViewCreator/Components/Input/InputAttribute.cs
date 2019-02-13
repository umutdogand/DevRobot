namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property , AllowMultiple = true, Inherited = true)]
    public class InputAttribute : HtmlComponent, IInput
    {
        public InputAttribute() { }

        public string Accept
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.AcceptKey); }
            set { SetFeature(HtmlFeaturesFactory.Accept(value)); }
        }
        public string Alt
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.AltKey); }
            set { SetFeature(HtmlFeaturesFactory.Alt(value)); }
        }
        public string Autocomplete
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.AutocompleteKey); }
            set { SetFeature(HtmlFeaturesFactory.Autocomplete(value)); }
        }
        public string Autofocus
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.AutofocusKey); }
            set { SetFeature(HtmlFeaturesFactory.Autofocus(value)); }
        }
        public string Checked
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.CheckedKey); }
            set { SetFeature(HtmlFeaturesFactory.Checked(value)); }
        }
        public string Dirname
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.DirnameKey); }
            set { SetFeature(HtmlFeaturesFactory.Dirname(value)); }
        }
        public string Disabled
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.DisabledKey); }
            set { SetFeature(HtmlFeaturesFactory.Disabled(value)); }
        }
        public string Form
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.FormKey); }
            set { SetFeature(HtmlFeaturesFactory.Form(value)); }
        }
        public string FormAction
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.FormActionKey); }
            set { SetFeature(HtmlFeaturesFactory.FormAction(value)); }
        }
        public string Height
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.HeightKey); }
            set { SetFeature(HtmlFeaturesFactory.Height(value)); }
        }
        public string List
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.ListKey); }
            set { SetFeature(HtmlFeaturesFactory.List(value)); }
        }
        public string Max
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.MaxKey); }
            set { SetFeature(HtmlFeaturesFactory.Max(value)); }
        }
        public string Maxlength
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.MaxlengthKey); }
            set { SetFeature(HtmlFeaturesFactory.Maxlength(value)); }
        }
        public string Min
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.MinKey); }
            set { SetFeature(HtmlFeaturesFactory.Min(value)); }
        }
        public string Multiple
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.MultipleKey); }
            set { SetFeature(HtmlFeaturesFactory.Multiple(value)); }
        }
        public string Name
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.NameKey); }
            set { SetFeature(HtmlFeaturesFactory.Name(value)); }
        }
        public string Pattern
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.PatternKey); }
            set { SetFeature(HtmlFeaturesFactory.Pattern(value)); }
        }
        public string Placeholder
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.PlaceholderKey); }
            set { SetFeature(HtmlFeaturesFactory.Placeholder(value)); }
        }
        public string Readonly
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.ReadonlyKey); }
            set { SetFeature(HtmlFeaturesFactory.Readonly(value)); }
        }
        public string Required
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.RequiredKey); }
            set { SetFeature(HtmlFeaturesFactory.Required(value)); }
        }
        public string Size
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.SizeKey); }
            set { SetFeature(HtmlFeaturesFactory.Size(value)); }
        }
        public string Src
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.SrcKey); }
            set { SetFeature(HtmlFeaturesFactory.Src(value)); }
        }
        public string Width
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.WidthKey); }
            set { SetFeature(HtmlFeaturesFactory.Width(value)); }
        }
        public string Type
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.TypeKey); }
            set { SetFeature(HtmlFeaturesFactory.Type(value)); }
        }
    }
}
