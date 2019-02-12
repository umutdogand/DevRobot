namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class LabelAttribute : HtmlComponent, ILabel
    {
        public string For
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.ForKey); }
            set { SetFeature(HtmlFeaturesFactory.For(value)); }
        }

        public LabelAttribute()
        {

        }
    }
}