namespace ViewCreator.Components
{
    /// <summary>
    /// 
    /// </summary>
    public struct HtmlFeature : IHtmlFeature
    {
        /*
         *  Fields 
         */

        #region Fields

        private string _name;
        private object _value;

        #endregion

        #region Properties

        /// <summary>
        /// Html elemanın özellik adı
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Html elemanın özellik değeri
        /// </summary>
        public object Value => _value;

        #endregion

        #region Methods

        /// <summary>
        /// Verilen isim ve özellik değerine göre html elemanı için özellik oluşturur
        /// </summary>
        /// <param name="name">Html elemanın özellik adı</param>
        /// <param name="value">Html elemanın özellik değeri</param>
        public HtmlFeature(string name, string value)
        {
            this._name = name;
            this._value = value;
        }

        #endregion
    }
}
