namespace ViewCreator.React.Rendering
{
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.React.Beautifier;
    using ViewCreator.React.Minification;

    public class ReactViewBuilder : ViewBuilder<IReactViewBuilder>, IReactViewBuilder
    {
        private const string GENERATE_BUILDER_FILE_KEY = "GenerateBuilderFileKey";
        private readonly IList<IReactFileFounder> reactFileFounderList = new List<IReactFileFounder>();
        private readonly Lazy<IMemoryCache> Cache = new Lazy<IMemoryCache>(() => { return new MemoryCache(new MemoryCacheOptions()); });

        public ReadOnlyCollection<IReactFileFounder> ReactFileFounderList => new ReadOnlyCollection<IReactFileFounder>(reactFileFounderList);

        public StringBuilder GeneratedBuilderFile
        {
            get
            {
                if (Cache.Value.TryGetValue(GENERATE_BUILDER_FILE_KEY, out StringBuilder stringBuilder))
                {
                    return stringBuilder;
                }

                return default;
            }
        }

        public ReactViewBuilderConfig ReactViewBuilderConfig => ViewBuilderConfig as ReactViewBuilderConfig;

        public ReactViewBuilder()
        {
            this.ViewBuilderConfig = new ReactViewBuilderConfig();
        }

        public IReactViewBuilder SetConfig(Action<ReactViewBuilderConfig> action)
        {
            action(this.ViewBuilderConfig as ReactViewBuilderConfig);

            return this;
        }

        public StringBuilder GenerateBuilderFile(IServiceProvider provider, bool force = false)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            var generated = GeneratedBuilderFile;

            if (!force && generated != default(StringBuilder))
            {
                return generated;
            }

            ReactFileGenerator reactFileGenerator = new ReactFileGenerator();

            var generatedFile = reactFileGenerator.Generate(RegisteredComponents.Keys, RegisteredLayouts);

            if (this.ReactViewBuilderConfig.MinifyEnabled)
            {
                generatedFile = Minify(provider, generatedFile);
            }

            if (this.ReactViewBuilderConfig.BeautifyEnabled)
            {
                generatedFile = Beautify(provider, generatedFile);
            }

            Cache.Value.Set(GENERATE_BUILDER_FILE_KEY, generatedFile);

            return generatedFile;
        }

        protected StringBuilder Minify(IServiceProvider provider, StringBuilder stringBuilder)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            JSMinifyParser parser = new JSMinifyParser();

            return new StringBuilder(parser.Parse(stringBuilder.ToString()));
        }

        protected StringBuilder Beautify(IServiceProvider provider, StringBuilder stringBuilder)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            var beautyfier = new JSBeautify(stringBuilder.ToString(), this.ReactViewBuilderConfig.BeautifyOptions);

            return new StringBuilder(beautyfier.GetResult());
        }

        public IReactViewBuilder AddFileFounder(IReactFileFounder reactFileFounder)
        {
            reactFileFounderList.Add(reactFileFounder);
            return this;
        }
    }
}