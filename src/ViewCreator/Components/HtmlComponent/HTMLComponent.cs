namespace ViewCreator.Components
{
    using System;

    public abstract class HtmlComponent : Attribute, IHtmlComponent
    {
        public HtmlFeatureCollection Features { get; set; }

        public Type RenderType { get; set; }

        public string Place { get; set; }

        public string Name
        {
            get { return GetFeature<String>(HtmlFeatures.NameKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.NameKey, value)); }
        }

        public string Class
        {
            get { return GetFeature<String>(HtmlFeatures.ClassKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.ClassKey, value)); }
        }

        public string Style
        {
            get { return GetFeature<String>(HtmlFeatures.StyleKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.StyleKey, value)); }
        }

        public string Name
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.NameKey); }
            set { SetFeature(HtmlFeaturesFactory.Name(value)); }
        }

        public string OnMouseDown
        {
            get { return GetFeature<String>(HtmlFeatures.OnMouseDownKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.OnMouseDownKey, value)); }
        }

        public string OnMouseMove
        {
            get { return GetFeature<String>(HtmlFeatures.OnMouseMoveKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.OnMouseMoveKey, value)); }
        }

        public string OnmouseOut
        {
            get { return GetFeature<String>(HtmlFeatures.OnmouseOutKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.OnmouseOutKey, value)); }
        }

        public string OnMouseOver
        {
            get { return GetFeature<String>(HtmlFeatures.OnMouseOverKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.OnMouseOverKey, value)); }
        }

        public string OnMouseUp
        {
            get { return GetFeature<String>(HtmlFeatures.OnMouseUpKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.OnMouseUpKey, value)); }
        }

        public string OnMouseWheel
        {
            get { return GetFeature<String>(HtmlFeatures.OnMouseWheelKey); }
            set { SetFeature(HtmlFeatures.Create(HtmlFeatures.OnMouseWheelKey, value)); }
        }

        public HtmlComponent()
        {
            Features = new HtmlFeatureCollection();
        }

        public void SetFeature(IHtmlFeature feature)
        {
            Features.Add(feature);
        }

        public object GetFeature(string name)
        {
            return Features.GetValue(name);
        }

        public T GetFeature<T>(string name)
        {
            return (T)GetFeature(name);
        }
    }
}