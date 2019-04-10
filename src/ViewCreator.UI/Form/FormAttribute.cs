namespace ViewCreator.UI
{
    using System;
    using ViewCreator.Components;

    public class FormAttribute : Component, IForm
    {
        public string Action
        {
            get { return GetFeature<String>(HtmlFeatures.ActionKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ActionKey, value)); }
        }

        public string Method
        {
            get { return GetFeature<String>(HtmlFeatures.MethodKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.MethodKey, value)); }
        }
    }
}