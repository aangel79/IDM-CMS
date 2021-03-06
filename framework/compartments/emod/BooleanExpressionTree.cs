﻿/***************************************************************************************************

Copyright (c) 2018 Intellectual Ventures Property Holdings, LLC (IVPH) All rights reserved.

EMOD is licensed under the Creative Commons Attribution-Noncommercial-ShareAlike 4.0 License.
To view a copy of this license, visit https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode

***************************************************************************************************/

using System;
using System.Collections.Generic;
using compartments.emod.interfaces;

namespace compartments.emod
{
    public class BooleanExpressionTree : IBooleanOperator
    {
        private readonly String _name;
        private readonly IBooleanOperator _rootOperator;
        private IBoolean _value;

        public BooleanExpressionTree(IBooleanOperator rootOperator)
        {
            _name         = null;
            _rootOperator = rootOperator;
            _value        = null;
        }

        public BooleanExpressionTree(String name, IBooleanOperator rootOperator)
        {
            _name         = name;
            _rootOperator = rootOperator;
            _value        = null;
        }

        public String Name
        {
            get { return _name; }
        }

        public IBoolean ResolveReferences(IDictionary<string, IBoolean> bmap, IDictionary<string, IValue> nmap)
        {
            if (_value == null)
            {
                _value = _rootOperator.ResolveReferences(bmap, nmap);
                if (_name != null)
                    bmap.Add(_name, _value);
            }

            return _value;
        }

        public override string ToString()
        {
            return (Name != null) ? string.Format("(bool {0} {1})", Name, _rootOperator) : _rootOperator.ToString();
        }
    }
}
