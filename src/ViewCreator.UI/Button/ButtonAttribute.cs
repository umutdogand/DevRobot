namespace ViewCreator.UI
{
    using System;
    using ViewCreator.Components;

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

        public string ElementContent
        {
            get { return GetFeature<String>(HtmlFeatures.ElementContentTypeKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ElementContentTypeKey, value)); }
        }
    }
}