namespace ViewCreator.Components
{
    public class ButtonType
    {
        private string _value;

        public static ButtonType Button = new ButtonType("button");

        public static readonly ButtonType Reset = new ButtonType("reset");

        public static readonly ButtonType Submit = new ButtonType("submit");

        public string Value => _value;

        public ButtonType(string value)
        {
            this._value = value;
        }
    }
}