namespace ViewCreator.Components
{
    using System;

    public abstract class HtmlComponent : Attribute, IHtmlComponent
    {
        public HtmlFeatureCollection Features { get; set; }

        public string Class
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.ClassKey); }
            set { SetFeature(HtmlFeaturesFactory.Class(value)); }
        }

        public string Style
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.StyleKey); }
            set { SetFeature(HtmlFeaturesFactory.Style(value)); }
        }

        public string OnMouseDown
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.OnMouseDownKey); }
            set { SetFeature(HtmlFeaturesFactory.OnMouseDown(value)); }
        }

        public string OnMouseMove
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.OnMouseMoveKey); }
            set { SetFeature(HtmlFeaturesFactory.OnMouseMove(value)); }
        }

        public string OnmouseOut
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.OnmouseOutKey); }
            set { SetFeature(HtmlFeaturesFactory.OnmouseOut(value)); }
        }

        public string OnMouseOver
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.OnMouseOverKey); }
            set { SetFeature(HtmlFeaturesFactory.OnMouseOver(value)); }
        }

        public string OnMouseUp
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.OnMouseUpKey); }
            set { SetFeature(HtmlFeaturesFactory.OnMouseUp(value)); }
        }

        public string OnMouseWheel
        {
            get { return GetFeature<String>(HtmlFeaturesFactory.OnMouseWheelKey); }
            set { SetFeature(HtmlFeaturesFactory.OnMouseWheel(value)); }
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

        public T GetFeature<T>(string name) where T : class
        {
            return GetFeature(name) as T;
        }
    }
}