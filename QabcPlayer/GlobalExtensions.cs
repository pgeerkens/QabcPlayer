////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Windows.Forms {
	/// <summary>Enumeration for buttons and modifiers in Windows Mouse messages.</summary>
	[Flags]
	public enum MouseKeys : short {
		/// <summary>None.</summary>
		None		= 0x00,
		/// <summary>Left mouse button.</summary>
		LButton	= 0x01,
		/// <summary>Right mouse button.</summary>
		RButton	= 0x02,
		/// <summary>Shift key.</summary>
		Shift		= 0x04,
		/// <summary>Control key.</summary>
		Control	= 0x08,
		/// <summary>Middle mouse button.</summary>
		MButton	= 0x10,
		/// <summary>First mouse X button.</summary>
		XButton1	= 0x20,
		/// <summary>Second mouse X button.</summary>
		XButton2	= 0x40
	}
    /// <summary>TODO</summary>
	public static class MouseInput {
    /// <summary>TODO</summary>
		public static MouseKeys GetKeyStateWParam(IntPtr wParam) {
			return (MouseKeys)(wParam.ToInt32() & 0x0000ffff);
		}
    /// <summary>TODO</summary>
		public static Int16 WheelDelta(IntPtr wParam) {
			return (Int16)(wParam.ToInt32() >> 16);
		}
    /// <summary>TODO</summary>
		public static IntPtr WParam (Int16 wheelDelta, MouseKeys mouseKeys) {
			return IntPtr.Zero + (wheelDelta << 16) + (Int16)mouseKeys;
		}
		/// <summary> Determine (sign-extended for multiple monitors) screen coordinates at m.LParam.</summary>
		/// <param name="lParam"></param>
		/// <returns></returns>
		public static Point GetPointLParam(IntPtr lParam) {
			return new Point(
					 (int)(short)(lParam.ToInt32() & 0x0000ffff), 
					 (int)(short)(lParam.ToInt32() >> 16)
				);
		}
    /// <summary>TODO</summary>
		public static IntPtr LParam(Point point) {
			if (point.X<Int16.MinValue || point.X > Int16.MaxValue)
				throw new ArgumentOutOfRangeException("point.X",point.X,
					"Must be a valid Int16 value.");
			if (point.Y<Int16.MinValue || point.Y > Int16.MaxValue)
				throw new ArgumentOutOfRangeException("point.Y",point.Y,
					"Must be a valid Int16 value.");
			return (IntPtr)((Int16)point.Y <<16 + (Int16)point.X);
		}
	}

}
namespace  PGSoftwareSolutions.Util {
    /// <summary>TODO</summary>
	public static class Utils {
		/// <summary>Returns all the extension methods for a type available to a specified assembly.</summary>
		/// <param name="assembly"></param>
		/// <param name="extType"></param>
		/// <returns></returns>
		public static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type extType) { 
			return from type in assembly.GetTypes() 
					 where type.IsSealed && !type.IsGenericType && !type.IsNested 
					 from method in type.GetMethods(BindingFlags.Static 
										| BindingFlags.Public | BindingFlags.NonPublic) 
					 where method.IsDefined(typeof(ExtensionAttribute), false) 
					 where method.GetParameters()[0].ParameterType == extType 
					 select method; 
		} 

		/// <summary>
		///  Construct a 'setter' for the specified class, from the provided 'getter'.
		/// </summary>
		/// <typeparam name="TClass"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="getter"></param>
		/// <returns></returns>
		public static Action<TClass,TValue> SetterFromGetter<TClass,TValue>(
			Expression<Func<TClass,TValue>> getter) 
		{
			var member	= (MemberExpression)getter.Body;
			var param	= Expression.Parameter(typeof(TValue), "value");
			var setter	= Expression.Lambda<Action<TClass,TValue>>(
								Expression.Assign(member, param), getter.Parameters[0], param);

			return setter.Compile();
		}
    /// <summary>TODO</summary>
		public static TimeSpan Minutes(this int numberOfMinutes)	{
			return new TimeSpan(0, numberOfMinutes, 0);
		}

    /// <summary>TODO</summary>
		public static DateTime Ago(this TimeSpan numberOfMinutes){
			return DateTime.Now.Subtract(numberOfMinutes);
		}
	}
}
