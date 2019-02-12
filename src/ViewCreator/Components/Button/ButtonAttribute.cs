namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class ButtonAttribute : HtmlComponent, IButton
    {
        public string Name
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.NameKey); }
            set { SetFeature(HtmlFeaturesFactory.Name(value)); }
        }

        public string Value
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.ValueKey); }
            set { SetFeature(HtmlFeaturesFactory.Value(value)); }
        }

        public ButtonType Type
        {
            get { return GetFeature<ButtonType>(HtmlFeaturesFactory.TypeKey); }
            set { SetFeature(HtmlFeaturesFactory.Type(value)); }
        }

        public string Autofocus
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.AutofocusKey); }
            set { SetFeature(HtmlFeaturesFactory.Autofocus(value)); }
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

        public ButtonAttribute()
        {

        }
    }
}