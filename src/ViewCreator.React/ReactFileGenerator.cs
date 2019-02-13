namespace ViewCreator.React
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ReactFileGenerator
    {
        public String GetReactImport()
        {
            return @"
import React from 'react';
import ReactDOM from 'react-dom';";
        }

        public String ReactApp()
        {
            return @"
import React from 'react';
import ReactDOM from 'react-dom';";
        }

        public void CreateFooter()
        {

        }
    }
}