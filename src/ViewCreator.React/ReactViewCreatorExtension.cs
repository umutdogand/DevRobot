namespace ViewCreator.React
{
    using System;
    using global::React.AspNet;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using ViewCreator.Mvc;

    public class ReactViewCreatorExtension : IViewCreatorExtension
    {
        public IHtmlContent Render<TModel, TViewModel>(HtmlHelper<TModel> htmlHelper, TViewModel viewModel)
        {
            htmlHelper.React("", viewModel);

            throw new NotImplementedException();
        }

        public IHtmlContent RenderComponent<TModel, TViewModel, TProperty>(HtmlHelper<TModel> htmlHelper, TViewModel viewModel, Func<TViewModel, TProperty> keySelector)
        {
            throw new NotImplementedException();
        }
    }
}