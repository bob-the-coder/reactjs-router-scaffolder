using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReactRouteBackbone
{
    internal class BaseComponent
    {
        public string Name { get; }
        public Hub Parent { get; internal set; }
        private IEnumerable<string> RouteParams;
        internal static string Extension { get; } = "js";

        internal BaseComponent(string name)
        {
            var uppedName = $"{name.Substring(0, 1).ToUpperInvariant()}{name.Substring(1)}";
            var chunks = uppedName.Split(':');

            Name = chunks.First();
            RouteParams = chunks.Skip(1);
        }

        internal string GetRoute()
        {
            var route = Parent == null 
                ? string.Empty 
                : $"{Parent.GetRoute()}/{Name.ToLowerInvariant()}";

            if (!RouteParams.Any()) return route;

            return $"{route}/:{string.Join("/:", RouteParams)}";
        }

        internal string RenderNavLink()
        {
            return $"<NavLink to='{GetRoute()}' activeClassName='active-page' style={{{{marginRight: '10px'}}}}>{Name}</NavLink>";
        }

        internal string RenderRoute()
        {
            return $"<Route path='{GetRoute()}' component={{{Name}}} />";
        }
    }
}
