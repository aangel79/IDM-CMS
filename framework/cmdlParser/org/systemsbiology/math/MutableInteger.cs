using System;
namespace org.systemsbiology.math
{
	/*
	* Copyright (C) 2003 by Institute for Systems Biology,
	* Seattle, Washington, USA.  All rights reserved.
	*
	* This source code is distributed under the GNU Lesser
	* General Public License, the text of which is available at:
	*   http://www.gnu.org/copyleft/lesser.html
	*/

	/// <summary> A container class for a [code]integer[/code] native data type.
	/// This class allows you to alter the [code]integer[/code] variable
	/// that it contains; it is a fully mutable object.  The purpose
	/// of this class is to provide a mechanism to use [code]integer[/code]
	/// values as values of a [code]HashMap[/code], while allowing those
	/// values to be mutable as well; this cannot be done with the standard
	/// Java class [code]Integer[/code], which is immutable.
	///
	/// </summary>
	/// <seealso cref="MutableBoolean">
	/// </seealso>
	/// <seealso cref="MutableDouble">
	///
	/// </seealso>
	/// <author>  Stephen Ramsey
	/// </author>
	public sealed class MutableInteger : System.ICloneable
	{
		public int Value
		{
			get
			{
				return (mInteger);
			}

			set
			{
				mInteger = value;
			}

		}
		private int mInteger;

		public int integerValue()
		{
			return (mInteger);
		}

		public MutableInteger(int pInteger)
		{
			Value = pInteger;
		}

		public System.Object Clone()
		{
			MutableInteger md = new MutableInteger(mInteger);
			return (md);
		}

		public override System.String ToString()
		{
			return (System.Convert.ToString(mInteger));
		}
	}
}