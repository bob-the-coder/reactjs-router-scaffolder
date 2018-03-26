namespace ReactRouteBackbone
{
    internal class BaseComponent
    {
        public string Name { get; }
        public Hub Parent { get; internal set; }
        internal static string Extension { get; } = "js";

        internal BaseComponent(string name)
        {
            Name = $"{name.Substring(0, 1).ToUpperInvariant()}{name.Substring(1)}";
        }

        internal string GetRoute()
        {
            return Parent == null 
                ? string.Empty 
                : $"{Parent.GetRoute()}/{Name.ToLowerInvariant()}";
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
