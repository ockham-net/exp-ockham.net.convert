using System;
using System.Linq;
using System.Reflection;

namespace Ockham.Test
{
    /// <summary>
    /// A utility for generating strongly-typed delegate wrappers for private or protected methods
    /// </summary>
    /// <remarks>Intended for enabling unit testing of protected and private methods</remarks>
    internal static class MethodReflection
    {

        private static Type[] GetParamTypes(MethodInfo method)
        {
            return method.GetParameters().Select(p => p.ParameterType).ToArray();
        }
         
        private static bool ArraysEqual<T>(T[] a, T[] b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (!Object.ReferenceEquals(a[i], b[i]) && !Object.Equals(a[i], b[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// Build a strongly typed delegate for calling a static method of the declaring type. Use
        /// this to call non-public methods in unit tests.
        /// </summary>
        /// <typeparam name="TDelegate"></typeparam>
        /// <param name="declaringType"></param>
        /// <param name="methodName"></param> 
        /// <param name="ignoreCase"></param>
        public static TDelegate GetMethodCaller<TDelegate>(Type declaringType, string methodName, bool ignoreCase = false) where TDelegate : class
        {
            return GetMethodCaller<TDelegate>(null, declaringType, methodName, ignoreCase, true);
        }

        private static MethodInfo GetMethodInfo<TDelegate>(object instance, Type declaringType, string methodName, bool ignoreCase, bool @static) where TDelegate : class
        {
            Type ltDelegate = typeof(TDelegate);
            if (!typeof(System.Delegate).GetTypeInfo().IsAssignableFrom(ltDelegate.GetTypeInfo())) throw new ArgumentException(ltDelegate.Name + " is not a delegate type");

            methodName = methodName ?? ltDelegate.Name;

            MethodInfo lmInvoke = ltDelegate.GetMethod("Invoke");
            Type[] paramTypes = GetParamTypes(lmInvoke);

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | (@static ? BindingFlags.Static : BindingFlags.Instance);
            var methodsFiltered = declaringType.GetMethods(flags).Where(
                m => m.ReturnType == lmInvoke.ReturnType && MethodReflection.ArraysEqual(paramTypes, GetParamTypes(m))
            ).ToList();
            MethodInfo method = methodsFiltered.FirstOrDefault(m => m.Name == methodName);
            if (method == null && ignoreCase)
            {
                method = methodsFiltered.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));
            }

            if (method == null)
            {
                throw new MissingMethodException("No matching method found on target type");
            }

            if (paramTypes.Any(t => t.IsByRef))
            {
                var lmInvokeParams = lmInvoke.GetParameters();
                var targetParams = method.GetParameters();
                for (int i = 0; i < lmInvokeParams.Length; i++)
                {
                    if (!paramTypes[i].IsByRef) continue;
                    var delegateParam = lmInvokeParams[i];
                    var targetParam = targetParams[i];
                    if (delegateParam.IsOut != targetParam.IsOut)
                    {
                        throw new MissingMethodException(
                            $"Target method parameter {targetParam.Name} at position {i} is {(targetParam.IsOut ? "out" : "ref")} " +
                            $"but delegate method parameter {delegateParam.Name} at position {i} is {(delegateParam.IsOut ? "out" : "ref")}"
                        );
                    }
                }
            }

            return method;
        }

        private static TDelegate GetMethodCaller<TDelegate>(object instance, Type declaringType, string methodName, bool ignoreCase, bool @static) where TDelegate : class
        {
            MethodInfo method = GetMethodInfo<TDelegate>(instance, declaringType, methodName, ignoreCase, @static);

            if (@static)
            {
                return (TDelegate)(object)method.CreateDelegate(typeof(TDelegate));
            }
            else
            {
                return (TDelegate)(object)method.CreateDelegate(typeof(TDelegate), instance);
            }
        }
    }
}
