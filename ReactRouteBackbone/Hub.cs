using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReactRouteBackbone
{
    internal class Hub : BaseComponent, IComponent
    {
        internal IList<Component> Components { get; } = new List<Component>();
        internal IList<Hub> Hubs { get; } = new List<Hub>();

        static IEnumerable<string> SplitComponents(string componentList)
        {
            if (string.IsNullOrEmpty(componentList) || string.IsNullOrWhiteSpace(componentList))
            {
                return null;
            }
            return componentList.Split(',').Select(comp => comp.Trim()).ToList();
        }

        internal Hub(string name, string componentList, params Hub[] hubs):this(name, SplitComponents(componentList), hubs)
        {
        }

        internal Hub(string name, IEnumerable<string> components, params Hub[] hubs) : base(name)
        {
            foreach (var comp in components)
            {
                var component = new Component(comp) {Parent = this};
                Components.Add(component);
            }

            foreach (var hub in hubs)
            {
                hub.Parent = this;
                Hubs.Add(hub);
            }
        }

        private string RenderComponentImports()
        {
            var imports = "";
            foreach (var component in Components)
            {
                imports += $@"import {component.Name} from './{component.Name}.{Extension}';
";
            };
            return imports;
        }

        private string RenderHubImports()
        {
            var imports = "";
            foreach (var hub in Hubs)
            {
                imports += $@"import {hub.Name} from './{hub.Name}/{hub.Name}.{Extension}';
";
            };
            return imports;
        }

        private string RenderNavLinks()
        {
            var links = "";
            foreach (var component in Components)
            {
                links += component.RenderNavLink() + @"
";
            }
            foreach (var hub in Hubs)
            {
                links += hub.RenderNavLink() + @"
";
            }

            return links;
        }

        private string RenderRoutes()
        {
            var links = "";
            foreach (var component in Components)
            {
                links += component.RenderRoute() + @"
";
            }
            foreach (var hub in Hubs)
            {
                links += hub.RenderRoute() + @"
";
            }

            return links;
        }

        public string Render()
        {
            return $@"
import React, {{ Component }} from 'react';
import {{ Route, NavLink }} from 'react-router-dom';
{RenderComponentImports()}
{RenderHubImports()}

export default class {Name} extends Component {{
    render () {{
        return (
            <div>
                <h2 style={{{{color: 'blue'}}}}>{{{Name}}}</h2>
                <h3>Current route is: <span  style={{{{color: 'green'}}}}>{{'{GetRoute()}'}}</span></h3>

                <div>
                    <h4>Links:</h4> 

{RenderNavLinks()}
                </div>

                <div>
                    <h4>Components:</h4>

{RenderRoutes()}
                </div>
            </div>
        );
    }}
}}

";
        }

        public void Build(string parentDir)
        {
            var dirPath = $"{parentDir}/{Name}";
            var filePath = $"{dirPath}/{Name}.{Extension}";
            var contents = Render();

            Directory.CreateDirectory(dirPath);
            File.Create(filePath).Close();
            File.WriteAllText(filePath, contents);

            foreach (var component in Components)
            {
                component.Build(dirPath);
            }
            foreach (var hub in Hubs)
            {
                hub.Build(dirPath);
            }
        }
    }
}
