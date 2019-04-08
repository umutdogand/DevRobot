namespace ViewCreator.Components
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class FeatureCollectionEnumerator : IEnumerator<IFeature>
    {
        private ConcurrentDictionary<String, IFeature> _collection = null;
        private IEnumerator<KeyValuePair<String, IFeature>> _enumerator = null;

        internal FeatureCollectionEnumerator(ConcurrentDictionary<String, IFeature> collection)
        {
            this._collection = collection;
            this._enumerator = collection.GetEnumerator();
            _collection.GetEnumerator();
        }

        public IFeature Current => _enumerator.Current.Value;

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