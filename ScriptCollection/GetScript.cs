using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextAttributes;

namespace ScriptCollection
{
    public static class GetScript
    {
        public static List<string> GetSearchNames()
        {
            var names = new List<string>();
            var mList = GetSearchScripts();
            foreach (var m in mList)
                names.Add(m.Name);
            return names;
        }

        public static SearchScript DefaultSearch
        {
            get
            {
                var mList = GetSearchScripts();
                var name = mList.FirstOrDefault(method => method.GetCustomAttributes().Contains(new SearchMethod() { Default = true })).Name;
                return GetSearchScript(name);
            }
        }

        public static ChangeScript DefaultChange
        {
            get
            {
                var mList = GetChangeScripts();
                var name = mList.FirstOrDefault(method => method.GetCustomAttributes().Contains(new ChangeMethod() { Default = true })).Name;
                return GetChangeScript(name);
            }
        }

        public static List<string> GetChangeNames()
        {
            var names = new List<string>();
            var mList = GetChangeScripts();
            foreach (var m in mList)
                names.Add(m.Name);
            return names;
        }

        public static SearchScript GetSearchScript(string Name)
        {
            try
            {
                var M = typeof(Search).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public).
                    Single(x => x.Name == Name);
                return System.Delegate.CreateDelegate(typeof(SearchScript), M) as SearchScript;
            }
            catch (Exception e)
            {
                if (e.Message == "Sequence contains no matching element")
                    throw new System.Exception(string.Format("Script with name {0} does not exist", Name));
                else
                    throw e;
            }
        }

        public static ChangeScript GetChangeScript(string Name)
        {
            try
            {
                var M = typeof(Change).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public).
                    Single(x => x.Name == Name);
                return System.Delegate.CreateDelegate(typeof(ChangeScript), M) as ChangeScript;
            }
            catch (Exception e)
            {
                if (e.Message == "Sequence contains no matching element")
                    throw new System.Exception(string.Format("Script with name {0} does not exist", Name));
                else
                    throw e;
            }
        }

        private static List<MethodInfo> GetSearchScripts()
        {
            var methodList = new List<MethodInfo>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetCustomAttributes().Contains(new SearchCollection()))
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (method.GetCustomAttributes().Contains(new SearchMethod() { Default = true }))
                            methodList.Add(method);
                        else if(method.GetCustomAttributes().Contains(new SearchMethod() { Default = false }))
                            methodList.Add(method);
                    }
                }
            }
            return methodList;
        }

        private static List<MethodInfo> GetChangeScripts()
        {
            var methodList = new List<MethodInfo>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetCustomAttributes().Contains(new ChangeCollection()))
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (method.GetCustomAttributes().Contains(new ChangeMethod() { Default = true }))
                            methodList.Add(method);
                        else if (method.GetCustomAttributes().Contains(new ChangeMethod() { Default = false }))
                            methodList.Add(method);
                    }
                }
            }
            return methodList;
        }
    }
}

