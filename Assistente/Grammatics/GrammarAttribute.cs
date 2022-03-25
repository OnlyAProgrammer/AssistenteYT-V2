using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assistente.Grammatics
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class GrammarAttribute : Attribute
    {
        private readonly Type _objectType;

        internal GrammarAttribute(Type objectType)
        {
            if (objectType.BaseType != typeof(GrammarBase))
                throw new Exception("GrammarAttribute can only be assigned to GrammarBase");
            _objectType = objectType;
        }

        internal List<GrammarPoint> ExtractGrammarPoints()
        {
            var grammarPointList = new List<GrammarPoint>();
            var methods = _objectType.GetMethods();

            foreach(var method in methods)
            {
                var customAttrb = method.GetCustomAttribute(typeof(GrammarPointReturnableAttribute));

                if (customAttrb != null && IsDefined(method, customAttrb.GetType()))
                {
                    var target = _objectType.Assembly.CreateInstance(_objectType.FullName, true);
                    var gpoint = _objectType.InvokeMember(method.Name, BindingFlags.InvokeMethod, null,
                        target, null);

                    grammarPointList.Add((GrammarPoint)gpoint);
                }
            }

            return grammarPointList;
        }
    }
}