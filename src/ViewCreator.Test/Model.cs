namespace ViewCreator.Test
{
    using ViewCreator.Components;

    [LinearLayout]
    public class Model
    {
        [Label(For = "testButton")]
        [Button(Name = "testButton")]
        public int Id { get; set; }
    }
}