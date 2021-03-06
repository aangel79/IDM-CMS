#region License
/* Copyright (c) 2007,2008,2009,2010,2011 Llewellyn Pritchard 
 * All rights reserved.
 * This source code is subject to terms and conditions of the BSD License.
 * See docs/license.txt. */
#endregion

using System;

namespace IronScheme.Compiler
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public sealed class GeneratorAttribute : Attribute
  {
    string name;

    public string Name
    {
      get { return name; }
    }

    public GeneratorAttribute(string name)
    {
      this.name = name;
    }
  }
}
