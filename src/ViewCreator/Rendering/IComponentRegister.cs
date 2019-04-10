namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IComponentRegister
    {
        /// <summary>
        /// Default render dışındaki render kullanılmak istenen veya
        /// custom olarak oluşturulmuş HtmlComponent leri siteme kayıt eder.
        /// Kayıtlı olmayan HtmlComponentler çalışmaz.
        /// </summary>
        /// <param name="viewBuilder"></param>
        void Register(IViewBuilder viewBuilder);
    }
}