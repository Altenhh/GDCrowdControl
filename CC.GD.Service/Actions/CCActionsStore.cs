// Copyright (c) Alten. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CC.GD.Service.Actions
{
    public class CCActionsStore : IDisposable
    {
        private const string cc_library_prefix = "cc.plugin";

        private readonly Dictionary<Assembly, Type> loadedAssemblies = new Dictionary<Assembly, Type>();

        public CCActionsStore()
        {
            loadFromDisk();
            addMissingActions();
        }

        public IEnumerable<CCPlugin> AvailablePlugins { get; private set; }
        public IEnumerable<CCAction> AvailableActions { get; private set; }

        private void addMissingActions()
        {
            var instances = loadedAssemblies.Values.Select(p => (CCPlugin)Activator.CreateInstance(p)).ToList();
            int index = 0;

            // set ids
            foreach (var plugin in instances)
                plugin.Id = index++;

            AvailablePlugins = instances;

            // reset.
            index = 0;
            List<CCAction> actions = new List<CCAction>();

            foreach (var plugin in AvailablePlugins)
            foreach (var action in plugin.GetActions())
            {
                action.Id = index++;
                actions.Add(action);
            }

            AvailableActions = actions;
        }

        private void loadFromDisk()
        {
            try
            {
                string[] files = Directory.GetFiles(Environment.CurrentDirectory, $"{cc_library_prefix}.*.dll");

                foreach (string file in files)
                    loadPluginFromFile(file);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not load plugins from directory {Environment.CurrentDirectory}");
                Console.WriteLine(e);
            }
        }

        private void loadPluginFromFile(string file)
        {
            var filename = Path.GetFileNameWithoutExtension(file);

            if (loadedAssemblies.Values.Any(t => t.Namespace == filename))
                return;

            try
            {
                addPlugin(Assembly.LoadFrom(file));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to load plugin {filename}");
                Console.WriteLine(e);
            }
        }

        private void addPlugin(Assembly assembly)
        {
            if (loadedAssemblies.ContainsKey(assembly))
                return;

            try
            {
                loadedAssemblies[assembly] = assembly.GetTypes().First(t => t.IsPublic && t.IsSubclassOf(typeof(CCPlugin)));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to add plugin {assembly}");
                Console.WriteLine(e);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
