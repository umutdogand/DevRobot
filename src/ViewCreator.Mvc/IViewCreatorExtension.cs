namespace ViewCreator.Mvc
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IViewCreatorExtension
    {
        IHtmlContent Render<TModel, TViewModel>(HtmlHelper<TModel> htmlHelper, TViewModel viewModel);

        IHtmlContent RenderComponent<TModel, TViewModel, TProperty>(HtmlHelper<TModel> htmlHelper, TViewModel viewModel, Func<TViewModel, TProperty> keySelector);
    }
}
