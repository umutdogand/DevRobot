namespace ViewCreator.Mvc
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using MvcTool.Helper;
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class ViewCreatorExtension
    {
        public static IHtmlContent Render<TModel, TViewModel>(this HtmlHelper<TModel> htmlHelper, TViewModel viewModel)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var creatorExtension = provider.GetService<IViewCreatorExtension>();
                return creatorExtension.Render(htmlHelper, viewModel);
            }
        }

        public static IHtmlContent RenderComponent<TModel, TViewModel, TProperty>(this HtmlHelper<TModel> htmlHelper, TViewModel viewModel, Func<TViewModel, TProperty> keySelector)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var creatorExtension = provider.GetService<IViewCreatorExtension>();
                return creatorExtension.RenderComponent(htmlHelper, viewModel, keySelector);
            }
        }
    }
}