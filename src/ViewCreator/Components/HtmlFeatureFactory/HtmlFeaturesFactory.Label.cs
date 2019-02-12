namespace ViewCreator.Components
{
    public partial class HtmlFeaturesFactory
    {
        public const string ForKey = "for";

        public static IHtmlFeature For(string @for)
        {
            return new HtmlFeature(ForKey, @for);
        }
    }
}