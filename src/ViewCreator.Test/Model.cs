namespace ViewCreator.Test
{
    using ViewCreator.Components;

    [LinearLayout]
    public class Model
    {
        [Input(Name = "txtTest")]
        [Label(For = "testButton")]
        [Button(Name = "testButton", Class = "test")]
        public int Id { get; set; }
    }
}