namespace ViewCreator.Components
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Rendering;

    public abstract class RenderBuilder : IViewBuilder
    {
        private ConcurrentDictionary<Type, Type> _renderTypes;

        private ConcurrentDictionary<IHtmlComponent, IRender> _cacheObjects;

        protected List<Type> RegisteredComponents { get; private set; }

        public RenderBuilder()
        {
            _renderTypes = new ConcurrentDictionary<Type, Type>();
            _cacheObjects = new ConcurrentDictionary<IHtmlComponent, IRender>();

            RegisteredComponents = new List<Type>();
        }

        public void AddAssembly(Assembly assembly)
        {
            RegisteredComponents.AddRange(
                assembly
                .GetTypes()
                .Where(i => i.GetCustomAttributes()
                .Any(a => a is ILayout)));
        }

        public void AddOrUpdateComponent<T1, T2>() where T1 : IHtmlComponent
                                  where T2 : IRender
        {
            _renderTypes.AddOrUpdate(typeof(T1), typeof(T2), (x, y) => y);
        }

        public IRender FindRender(IHtmlComponent component)
        {
            var type = component?.GetType();

            if (type != null && _renderTypes.ContainsKey(type) && _renderTypes[type] is Type renderType)
            {
                if (_cacheObjects.ContainsKey(component))
                {
                    return _cacheObjects[component];
                }

                return _cacheObjects.GetOrAdd(component, Activator.CreateInstance(renderType) as IRender);
            }

            return null;
        }

        public abstract StringBuilder Render(IServiceProvider provider);
    }
}