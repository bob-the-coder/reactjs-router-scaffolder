using System.IO;

namespace ReactRouteBackbone
{
    internal class Component : BaseComponent, IComponent
    {
        internal Component(string name) : base(name) { }

        public string Render()
        {
            return $@"
import React, {{ Component }} from 'react';

export default class {Name} extends Component {{
    render () {{
        return (
            <div>
                <h2 style={{{{color: 'blue'}}}}>{{{Name}}}</h2>
                <h3>Current route is: <span  style={{{{color: 'green'}}}}>{{'{GetRoute()}'}}</span></h3>
            </div>
        );
    }}
}}

";
        }

        public void Build(string parentDir)
        {
            var filePath = $"{parentDir}/{Name}.{Extension}";
            var contents = Render();

            File.Create(filePath).Close();
            File.WriteAllText(filePath, contents);
        }
    }
}
