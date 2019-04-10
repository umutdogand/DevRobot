using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ViewCreator.React")]

namespace ViewCreator.Components
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Rendering;

    public abstract class ViewBuilder<T> : IViewBuilder<T> where T : IViewBuilder
    {
        private ConcurrentDictionary<Type, IRender> _cacheObjects;

        protected internal virtual ConcurrentDictionary<Type, Type> RegisteredComponents { get; set; }

        protected internal virtual ViewBuilderConfig ViewBuilderConfig { get; set; }

        protected internal virtual List<Type> RegisteredLayouts { get; set; }

        protected internal virtual List<IComponentRegister> ComponentRegisters { get; set; }

        public ViewBuilder()
        {
            _cacheObjects = new ConcurrentDictionary<Type, IRender>();

            RegisteredComponents = new ConcurrentDictionary<Type, Type>();
            ViewBuilderConfig = new ViewBuilderConfig();
            RegisteredLayouts = new List<Type>();
            ComponentRegisters = new List<IComponentRegister>();
        }

        /// <summary>
        /// Assembly içerisindeki tüm layoutları kaydeder.
        /// </summary>
        /// <param name="assembly">Kayıt edilecek olan assembly</param>
        /// <returns>ViewBuilder</returns>
        public virtual T AddLayoutModelsFromAssembly(Assembly assembly)
        {
            var registerTypes = assembly.GetTypes()
                 .Where(i => i.GetCustomAttributes().Any(a => a is ILayout));
            registerTypes = registerTypes.Except(RegisteredLayouts);
            RegisteredLayouts.AddRange(registerTypes);
            return (T)(object)this;
        }

        /// <summary>
        /// Sadece tek bir tip layout'u sisteme kayıt eder.
        /// </summary>
        /// <param name="type">Layout tip</param>
        /// <returns>ViewBuilder</returns>
        public virtual T AddLayoutModelType(Type type)
        {
            var registerTypes = new List<Type>() { type }.AsEnumerable();
            registerTypes = registerTypes.Except(RegisteredLayouts);
            RegisteredLayouts.AddRange(registerTypes);
            return (T)(object)this;
        }

        public virtual T AddOrUpdateComponent<T1, T2>()
            where T1 : FeatureBase
            where T2 : IRender
        {
            RegisteredComponents.AddOrUpdate(typeof(T1), typeof(T2), (x, y) => y);
            return (T)(object)this;
        }

        public virtual T SetConfig(Action<ViewBuilderConfig> action)
        {
            action(ViewBuilderConfig);
            return (T)(object)this;
        }

        public T AddComponentRegister(IComponentRegister componentRegister)
        {
            if (componentRegister != null && !ComponentRegisters.Contains(componentRegister))
            {
                ComponentRegisters.Add(componentRegister);
            }

            return (T)(object)this;
        }

        public IRender FindRender(IComponent component)
        {
            var type = component?.RenderType ?? component?.GetType();
            return FindRender(type);
        }

        public IRender FindRender(Type componentType)
        {
            var type = componentType;

            if (type != null && RegisteredComponents.ContainsKey(type) && RegisteredComponents[type] is Type renderType)
            {
                if (_cacheObjects.ContainsKey(type))
                {
                    return _cacheObjects[type];
                }

                return _cacheObjects.GetOrAdd(type, Activator.CreateInstance(renderType) as IRender);
            }

            return null;
        }
    }
}