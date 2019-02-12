namespace ViewCreator.Components
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class HtmlFeatureCollectionEnumerator : IEnumerator<IHtmlFeature>
    {
        private ConcurrentDictionary<String, IHtmlFeature> _collection = null;
        private IEnumerator<KeyValuePair<String, IHtmlFeature>> _enumerator = null;

        internal HtmlFeatureCollectionEnumerator(ConcurrentDictionary<String, IHtmlFeature> collection)
        {
            this._collection = collection;
            this._enumerator = collection.GetEnumerator();
            _collection.GetEnumerator();
        }

        public IHtmlFeature Current => _enumerator.Current.Value;

        object IEnumerator.Current => _enumerator.Current.Value;

        public void Dispose()
        {
            this._collection = null;
            this._enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }
}