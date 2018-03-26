namespace ReactRouteBackbone
{
    internal interface IComponent
    {
        string Name { get; }
        string Render();
        void Build(string parentDir);
    }
}
