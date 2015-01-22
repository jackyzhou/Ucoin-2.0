﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ucoin.Framework.CompareObjects
{
    public static class TypeHelper
    {
        public static bool IsSimpleType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return type.IsPrimitive 
                || type == typeof(DateTime)
                || type == typeof(decimal)
                //|| type == typeof(string)
                || type == typeof(Guid);
        }

        public static bool IsString(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type == typeof(string);
        }

        public static bool IsTimespan(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type == typeof(TimeSpan);
        }

        public static bool IsClass(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type.IsClass;
        }

        public static bool IsInterface(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type.IsInterface;
        }

        public static bool IsEnum(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type.IsEnum;
        }

        public static bool IsIList(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return (typeof(IList).IsAssignableFrom(type));
        }

        public static bool IsIDictionary(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return (typeof(IDictionary).IsAssignableFrom(type));
        }

        public static bool IsEnumerable(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type.ReflectedType != null && type.ReflectedType == typeof(Enumerable);
        }

        public static bool IsHashSet(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(HashSet<>));
        }
    }
}
