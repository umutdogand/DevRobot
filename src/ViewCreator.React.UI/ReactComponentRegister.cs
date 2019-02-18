namespace ViewCreator.React
{
    using ViewCreator.Components;
    using ViewCreator.React.Rendering;
    using ViewCreator.Rendering;

    // TODO : Pattern uyumlu olsun

    public class ReactComponentRegister : IComponentRegister
    {
        public void Register(IViewBuilder viewBuilder)
        {
            var reactViewBuilder = viewBuilder as IReactViewBuilder;

            reactViewBuilder.AddOrUpdateComponent<ButtonAttribute, ButtonReactRender>();
            reactViewBuilder.AddOrUpdateComponent<LinearLayoutAttribute, LinearLayoutReactRender>();
            reactViewBuilder.AddOrUpdateComponent<LabelAttribute, LabelReactRender>();
            reactViewBuilder.AddOrUpdateComponent<InputAttribute, InputReactRender>();
        }
    }
}
