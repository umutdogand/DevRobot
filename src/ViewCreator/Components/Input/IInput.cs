namespace ViewCreator.Components
{
    public interface IInput : IHtmlComponent
    {
        string Accept { get; set; }
        string Alt { get; set; }
        string Autocomplete { get; set; }
        string Autofocus { get; set; }
        string Checked { get; set; }
        string Dirname { get; set; }
        string Disabled { get; set; }
        string Form { get; set; }
        string FormAction { get; set; }
        string Height { get; set; }
        string List { get; set; }
        string Max { get; set; }
        string Maxlength { get; set; }
        string Min { get; set; }
        string Multiple { get; set; }
        string Name { get; set; }
        string Pattern { get; set; }
        string Placeholder { get; set; }
        string Readonly { get; set; }
        string Required { get; set; }
        string Size { get; set; }
        string Src { get; set; }
        string Width { get; set; }
        InputType Type { get; set; }
    }
}
