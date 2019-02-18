namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class LabelAttribute : HtmlComponent, ILabel
    {
        public string For
        {
            get { return GetFeature<String>(HtmlFeatures.ForKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ForKey, value)); }
        }

        public string ElementContent
        {
            get { return GetFeature<String>(HtmlFeatures.ElementContentType); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ElementContentType, value)); }
        }
    }
}