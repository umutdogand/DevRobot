using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ViewCreator.React")]

namespace ViewCreator.Components
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Rendering;

    public abstract class ViewBuilder<T> : IViewBuilder<T> where T : IViewBuilder
    {
        private ConcurrentDictionary<Type, Type> _renderTypes;

        private ConcurrentDictionary<Type, IHtmlComponentRender> _cacheObjects;

        protected internal virtual ViewBuilderConfig ViewBuilderConfig { get; set; }

        protected internal virtual List<Type> RegisteredComponents { get; set; }

        protected internal virtual List<IComponentRegister> ComponentRegisters { get; set; }

        public ViewBuilder()
        {
            _renderTypes = new ConcurrentDictionary<Type, Type>();
            _cacheObjects = new ConcurrentDictionary<Type, IHtmlComponentRender>();

            ViewBuilderConfig = new ViewBuilderConfig();
            RegisteredComponents = new List<Type>();
            ComponentRegisters = new List<IComponentRegister>();
        }

        public virtual T AddAssembly(Assembly assembly)
        {
            var registerTypes = assembly.GetTypes()
                 .Where(i => i.GetCustomAttributes().Any(a => a is ILayout));
            registerTypes = registerTypes.Except(RegisteredComponents);
            RegisteredComponents.AddRange(registerTypes);
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public virtual T AddType(Type type)
        {
            var registerTypes = new List<Type>() { type }.AsEnumerable();
            registerTypes = registerTypes.Except(RegisteredComponents);
            RegisteredComponents.AddRange(registerTypes);
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public virtual T AddOrUpdateComponent<T1, T2>()
            where T1 : IHtmlComponent
            where T2 : IHtmlComponentRender
        {
            _renderTypes.AddOrUpdate(typeof(T1), typeof(T2), (x, y) => y);
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public virtual T SetConfig(Action<ViewBuilderConfig> action)
        {
            action(ViewBuilderConfig);
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public T AddComponentRegister(IComponentRegister componentRegister)
        {
            if (componentRegister != null && !ComponentRegisters.Contains(componentRegister))
            {
                ComponentRegisters.Add(componentRegister);
            }

            return (T)Convert.ChangeType(this, typeof(T));
        }

        public IHtmlComponentRender FindRender(IHtmlComponent component)
        {
            var type = component?.RenderType ?? component?.GetType();

            if (type != null && _renderTypes.ContainsKey(type) && _renderTypes[type] is Type renderType)
            {
                if (_cacheObjects.ContainsKey(type))
                {
                    return _cacheObjects[type];
                }

                return _cacheObjects.GetOrAdd(type, Activator.CreateInstance(renderType) as IHtmlComponentRender);
            }

            return null;
        }

        public StringBuilder Render(IServiceProvider provider)
        {
            StringBuilder stringBuilder = Rendering(provider);

            if (ViewBuilderConfig.MinifyEnabled)
            {
                var stream = new MemoryStream();
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(stringBuilder.ToString());
                    writer.Flush();
                    stream.Position = 0;

                    // TODO: minimize işlemi yapılacak
                }
            }

            return stringBuilder;
        }

        protected abstract StringBuilder Rendering(IServiceProvider provider);
    }
}