﻿namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHtmlComponent
    {
        Type RenderType { get; set; }

        string Name { get; set; }

        string Class { get; set; }

        string Style { get; set; }

        string Name { get; set; }

        string OnMouseDown { get; set; }

        string OnMouseMove { get; set; }

        string OnmouseOut { get; set; }

        string OnMouseOver { get; set; }

        string OnMouseUp { get; set; }

        string OnMouseWheel { get; set; }
    }
}