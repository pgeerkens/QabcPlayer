////////////////////////////////////////////////////////////////////////
//                  Q - A B C   S O U N D   P L A Y E R
//
//                   Copyright (C) Pieter Geerkens 2012-2016
////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PGSoftwareSolutions.Util {
    /// <summary>TODO</summary>
	internal static class Utils {
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
