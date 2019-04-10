﻿namespace ViewCreator.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;

    public interface ILabel : IComponent
    {
        string For { get; set; }
    }
}