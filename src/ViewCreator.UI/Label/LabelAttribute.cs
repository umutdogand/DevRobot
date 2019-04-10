namespace ViewCreator.UI
{
    using System;
    using ViewCreator.Components;

    public class LabelAttribute : Component, ILabel
    {
        public string For
        {
            get { return GetFeature<String>(HtmlFeatures.ForKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ForKey, value)); }
        }

        public string ElementContent
        {
            get { return GetFeature<String>(HtmlFeatures.ElementContentTypeKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ElementContentTypeKey, value)); }
        }
    }
}