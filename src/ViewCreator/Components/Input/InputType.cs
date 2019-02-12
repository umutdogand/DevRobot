namespace ViewCreator.Components
{
    public class InputType
    {
        private string _value;

        public static readonly InputType Button = new InputType("button");
        public static readonly InputType Checkbox = new InputType("checkbox");
        public static readonly InputType Color = new InputType("color");
        public static readonly InputType Date = new InputType("date");
        public static readonly InputType DatetimeLocal = new InputType("datetime-local");
        public static readonly InputType Email = new InputType("email");
        public static readonly InputType File = new InputType("file");
        public static readonly InputType Hidden = new InputType("hidden");
        public static readonly InputType Image = new InputType("image");
        public static readonly InputType Month = new InputType("month");
        public static readonly InputType Number = new InputType("number");
        public static readonly InputType Password = new InputType("password");
        public static readonly InputType Radio = new InputType("radio");
        public static readonly InputType Range = new InputType("range");
        public static readonly InputType Reset = new InputType("reset");
        public static readonly InputType Search = new InputType("search");
        public static readonly InputType Submit = new InputType("submit");
        public static readonly InputType Tel = new InputType("tel");
        public static readonly InputType Text = new InputType("text");
        public static readonly InputType Time = new InputType("time");
        public static readonly InputType Url = new InputType("url");
        public static readonly InputType Week = new InputType("week");

        public string Value => _value;

        public InputType(string value)
        {
            this._value = value;
        }
    }
}
