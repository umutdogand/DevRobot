namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILayout
    {
        /// <summary>
        /// Layout için tanımlı benzersiz isim
        /// </summary>
        string LayoutName { get; set; }
    }
}