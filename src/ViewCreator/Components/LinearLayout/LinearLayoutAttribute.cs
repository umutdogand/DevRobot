namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class LinearLayoutAttribute : HtmlComponent, ILayout
    {
    }
}