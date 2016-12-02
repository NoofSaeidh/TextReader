using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextReader;
using TextReader.Core.Common;

namespace TextReader.Core.Script
{
    public class ScriptReflection
    {
        public Assembly Assembly { get; set; }

        public class ScriptHandler
        {
            public string ActualName { get; internal set; }
            public string UserName { get; internal set; }
            public string UserDescription { get; internal set; }
            public Type Type { get; internal set; }
            public bool Default { get; internal set; }
            public MethodInfo Method { get; internal set; }
            //public Type ParrentType { get; internal set; }
        }

        private Dictionary<string, ScriptHandler> scripts;

        #region Init

        public void Load()
        {
            scripts = new Dictionary<string, ScriptHandler>();
            var nameCheck = new List<string>();
            foreach (var type in Assembly.GetTypes())
            {

                ScriptHandler _default = null;
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(x => x.IsDefined(typeof(ScriptAttribute))))
                {
                    if (nameCheck.Contains(method.Name)) throw new TextException("Assambly contains more than one script with the same names.");
                    nameCheck.Add(method.Name);

                    var _params = method.GetParameters();
                    if (_params.Count() != 1) throw new TextException("Method pararmeters does not represent delegate. It has more than one input parameter.");
                    //TODO verify that parameter inherit from Settings interface
                    //if (_params.First().GetType() ) throw new TextException("Method pararmeters does not represent delegate. It has more than one input parameter.");

                    var _attribute = method.GetCustomAttribute<ScriptAttribute>();
                    var _script = new ScriptHandler()
                    {
                        Method = method,
                        UserName = _attribute.UserName,
                        UserDescription = _attribute.UserDescription,
                        ActualName = method.Name,
                        Default = _attribute.Default,
                        Type = _params.First().ParameterType
                    };
                    if (_attribute.Default) _default = _script;
                    scripts.Add(_script.ActualName, _script);
                }
            }
        }
        public void Load(Assembly assembly)
        {
            Assembly = assembly;
            Load();
        }
        public ScriptReflection()
        {
        }

        public ScriptReflection(Assembly assembly)
        {
            Load(assembly);
        }

        #endregion

        #region Basic Gets

        public List<ScriptHandler> GetHandlers<T>() where T : Settings.ISettings
        {
            return scripts.Where(s => s.Value.Type == typeof(T)).Select(x => x.Value as ScriptHandler).ToList();
        }

        public ScriptHandler GetDefaultHandler<T>() where T : Settings.ISettings
        {
            return scripts.Where(s => s.Value.Type == typeof(T)).First(x => x.Value.Default).Value;
        }

        public Script<T> GetDefaultScript<T>() where T : Settings.ISettings
        {
            return GetScript<T>(GetDefaultHandler<T>());
        }

        public Script<T> GetScript<T>(ScriptHandler script) where T : Settings.ISettings
        {
            return (Script<T>)Delegate.CreateDelegate(typeof(Script<T>), script.Method);
        }

        #endregion

        #region Additional gets

        public Script<T> GetScriptByActualName<T>(string actualName) where T : Settings.ISettings
        {
            return GetScript<T>(this[actualName]);
        }

        public Script<T> GetScriptByUserName<T>(string userName) where T : Settings.ISettings
        {
            return GetScript<T>(GetHandlerByUserName(userName));
        }

        public ScriptHandler GetHandlerByActualName(string actualName)
        {
            return this[actualName];
        }

        public ScriptHandler GetHandlerByUserName(string userName)
        {
            return scripts.First(s => s.Value.UserName == userName).Value;
        }

        ScriptHandler this[string scriptName]
        {
            get
            {
                return scripts[scriptName];
            }
        }

        IEnumerable<Script<T>> ScriptCollection<T>() where T : Settings.ISettings
        {
            foreach (var script in scripts)
            {
                yield return GetScript<T>(script.Value);
            }
        }

        IEnumerable<ScriptHandler> HandlerCollection()
        {
            foreach (var script in scripts)
            {
                yield return script.Value;
            }
        }

        #endregion


        //public static List<string> GetNames<T>()
        //{
        //	var names = new List<string>();
        //	var mList = GetCollection<T>();
        //	foreach (var m in mList)
        //		names.Add(m.Name);
        //	return names;
        //}

        //public Default<T>()
        //{
        //	var mList = GetCollection<T>();
        //	var name = mList.FirstOrDefault(method => method.GetCustomAttributes().Contains(new DefaultAttribute { Type = typeof(T) })||
        //		method.GetCustomAttributes().Contains(new DefaultAttribute { Type = null })).Name;
        //	return GetSearchScript(name);
        //}


        //public SearchScript DefaultSearch
        //{
        //	get
        //	{
        //		var mList = GetSearchScriptCollection();
        //		var name = mList.FirstOrDefault(method => method.GetCustomAttributes().Contains(new SearchMethod() { Default = true })).Name;
        //		return GetSearchScript(name);
        //	}
        //}

        //public T GetScript<T>(string Name)
        //{
        //	try
        //	{
        //		var M = typeof(T).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public).
        //			Single(x => x.Name == Name);
        //		return Delegate.CreateDelegate(typeof(T), M);
        //	}
        //	catch (Exception e)
        //	{
        //		if (e.Message == "Sequence contains no matching element")
        //			throw new System.Exception(string.Format("Script with name {0} does not exist", Name));
        //		else
        //			throw e;
        //	}
        //}


    }
}

