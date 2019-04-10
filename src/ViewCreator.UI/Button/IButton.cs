namespace ViewCreator.UI
{
    using ViewCreator.Components;

    public interface IButton : IComponent
    {
        string Value { get; set; }

        string Type { get; set; }

        string Autofocus { get; set; }

        string Disabled { get; set; }
    }
}