namespace ViewCreator.Components
{
    using System;
    
    public class InputAttribute : Component, IInput
    {
        public string Accept
        {
            get { return GetFeature<String>(HtmlFeatures.AcceptKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.AcceptKey, value)); }
        }

        public string Alt
        {
            get { return GetFeature<String>(HtmlFeatures.AltKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.AltKey, value)); }
        }

        public string Autocomplete
        {
            get { return GetFeature<String>(HtmlFeatures.AutocompleteKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.AutocompleteKey, value)); }
        }

        public string Autofocus
        {
            get { return GetFeature<String>(HtmlFeatures.AutofocusKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.AutofocusKey, value)); }
        }

        public string Checked
        {
            get { return GetFeature<String>(HtmlFeatures.CheckedKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.CheckedKey, value)); }
        }

        public string Dirname
        {
            get { return GetFeature<String>(HtmlFeatures.DirnameKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.DirnameKey, value)); }
        }

        public string Disabled
        {
            get { return GetFeature<String>(HtmlFeatures.DisabledKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.DisabledKey, value)); }
        }

        public string Form
        {
            get { return GetFeature<String>(HtmlFeatures.FormKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.FormKey, value)); }
        }

        public string FormAction
        {
            get { return GetFeature<String>(HtmlFeatures.FormActionKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.FormActionKey, value)); }
        }

        public string Height
        {
            get { return GetFeature<String>(HtmlFeatures.HeightKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.HeightKey, value)); }
        }

        public string List
        {
            get { return GetFeature<String>(HtmlFeatures.ListKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ListKey, value)); }
        }

        public string Max
        {
            get { return GetFeature<String>(HtmlFeatures.MaxKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.MaxKey, value)); }
        }

        public string Maxlength
        {
            get { return GetFeature<String>(HtmlFeatures.MaxlengthKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.MaxlengthKey, value)); }
        }

        public string Min
        {
            get { return GetFeature<String>(HtmlFeatures.MinKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.MinKey, value)); }
        }

        public string Multiple
        {
            get { return GetFeature<String>(HtmlFeatures.MultipleKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.MultipleKey, value)); }
        }

        public string Pattern
        {
            get { return GetFeature<String>(HtmlFeatures.PatternKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.PatternKey, value)); }
        }

        public string Placeholder
        {
            get { return GetFeature<String>(HtmlFeatures.PlaceholderKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.PlaceholderKey, value)); }
        }

        public string Readonly
        {
            get { return GetFeature<String>(HtmlFeatures.ReadonlyKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ReadonlyKey, value)); }
        }

        public string Required
        {
            get { return GetFeature<String>(HtmlFeatures.RequiredKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.RequiredKey, value)); }
        }

        public string Size
        {
            get { return GetFeature<String>(HtmlFeatures.SizeKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.SizeKey, value)); }
        }

        public string Src
        {
            get { return GetFeature<String>(HtmlFeatures.SrcKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.SrcKey, value)); }
        }

        public string Width
        {
            get { return GetFeature<String>(HtmlFeatures.WidthKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.WidthKey, value)); }
        }

        public string Type
        {
            get { return GetFeature<String>(HtmlFeatures.TypeKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.TypeKey, value)); }
        }
    }
}