namespace ViewCreator.Test
{
    using ViewCreator.Components;
    using ViewCreator.UI;

    [Layout("")]
    public class Model
    {
        [Input(Name = "txtTest", Type = InputType.Button)]
        [Label(For = "testButton")]
        [Button(Name = "testButton", Class = "test")]
        public int Id { get; set; }
    }
}