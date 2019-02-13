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

    public abstract class RenderBuilder : IViewBuilder
    {
        private ConcurrentDictionary<Type, Type> _renderTypes;

        private ConcurrentDictionary<IHtmlComponent, IRender> _cacheObjects;

        protected List<Type> RegisteredComponents { get; private set; }

        public bool MinifyEnabled { get; set; } = false;

        public RenderBuilder()
        {
            _renderTypes = new ConcurrentDictionary<Type, Type>();
            _cacheObjects = new ConcurrentDictionary<IHtmlComponent, IRender>();

            RegisteredComponents = new List<Type>();
        }

        public IViewBuilder AddAssembly(Assembly assembly)
        {
            RegisteredComponents.AddRange(
                assembly
                .GetTypes()
                .Where(i => i.GetCustomAttributes()
                .Any(a => a is ILayout)));
            return this;
        }

        public IViewBuilder AddOrUpdateComponent<T1, T2>() where T1 : IHtmlComponent
                                  where T2 : IRender
        {
            _renderTypes.AddOrUpdate(typeof(T1), typeof(T2), (x, y) => y);
            return this;
        }

        public IViewBuilder SetMinify(bool minify)
        {
            this.MinifyEnabled = minify;
            return this;
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

        public StringBuilder Render(IServiceProvider provider)
        {
            StringBuilder stringBuilder = Rendering(provider);

            if (MinifyEnabled)
            {
                NetPack.JsMin.JsMin jsMin = new NetPack.JsMin.JsMin(new NetPack.JsMin.JsMinOptions());

                Stream input = GenerateStreamFromString(stringBuilder);
                //jsMin.ProcessAsync(input, )

            }

            return stringBuilder;
        }

        public abstract StringBuilder Rendering(IServiceProvider provider);

        public static Stream GenerateStreamFromString(StringBuilder s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s.ToString());
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}