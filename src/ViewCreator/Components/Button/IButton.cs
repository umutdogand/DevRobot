namespace ViewCreator.Components
{
    public interface IButton : IHtmlComponent
    {
        string Value { get; set; }

        string Type { get; set; }

        string Autofocus { get; set; }

        string Disabled { get; set; }

        string Form { get; set; }

        string FormAction { get; set; }
    }
}