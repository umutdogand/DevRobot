namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ButtonAttribute : Component, IButton
    {
        public string Value
        {
            get { return GetFeature<String>(HtmlFeatures.ValueKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ValueKey, value)); }
        }

        public string Type
        {
            get { return GetFeature<String>(HtmlFeatures.TypeKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.TypeKey, value)); }
        }

        public string Autofocus
        {
            get { return GetFeature<String>(HtmlFeatures.AutofocusKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.AutofocusKey, value)); }
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

        public string ElementContent
        {
            get { return GetFeature<String>(HtmlFeatures.ElementContentTypeKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ElementContentTypeKey, value)); }
        }
    }
}