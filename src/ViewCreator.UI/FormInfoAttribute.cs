namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FormInfoAttribute : Attribute
    {
        public string ForName { get; set; }

        public string Action { get; set; }

        public string Method { get; set; }

        public FormInfoAttribute(string forName)
        {
            this.ForName = ForName;
        }
    }
}