namespace ViewCreator.Components
{
    using System;
    using ViewCreator.Components;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LinearLayoutAttribute : HtmlComponent, ILayout
    {
    }
}