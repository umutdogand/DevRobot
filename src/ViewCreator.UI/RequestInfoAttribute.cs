namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RequestInfoAttribute : Attribute
    {
        public string ForName { get; set; }

        public string Action { get; set; }

        public string Method { get; set; }

        public RequestInfoAttribute(string forName)
        {
            this.ForName = ForName;
        }
    }
}