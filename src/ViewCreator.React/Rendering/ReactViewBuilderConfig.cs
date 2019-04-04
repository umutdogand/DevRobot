namespace ViewCreator.React.Rendering
{
    using ViewCreator.Rendering;

    public class ReactViewBuilderConfig : ViewBuilderConfig
    {
        public string ReactFilePath { get; set; } = "react-builder.jsx";

        public string ReactFolderPath { get; set; } = "ViewBuilder.React";
    }
}