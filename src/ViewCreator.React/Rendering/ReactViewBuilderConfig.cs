namespace ViewCreator.React.Rendering
{
    using ViewCreator.React.Beautifier;
    using ViewCreator.Rendering;

    public class ReactViewBuilderConfig : ViewBuilderConfig
    {
        public bool MinifyEnabled { get; set; } = true;

        public bool BeautifyEnabled { get; set; } = true;

        public string ReactFilePath { get; set; } = "react-builder.jsx";

        public string ReactFolderPath { get; set; } = "ViewBuilder.React";

        public JSBeautifyOptions BeautifyOptions { get; set; }
    }
}