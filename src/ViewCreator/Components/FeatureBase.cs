namespace ViewCreator.Components
{
    using System;

    public abstract class FeatureBase : Attribute
    {
        public FeatureCollection Features { get; set; }

        public Type RenderType { get; set; }

        public string Place { get; set; }

        public FeatureBase()
        {
            Features = new FeatureCollection();
        }

        public void SetFeature(IFeature feature)
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