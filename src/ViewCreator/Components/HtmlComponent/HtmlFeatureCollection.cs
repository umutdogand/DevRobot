namespace ViewCreator.Components
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class HtmlFeatureCollection : ICollection<IHtmlFeature>
    {
        #region Fields

        private readonly ConcurrentDictionary<String, IHtmlFeature> _hashSet =
            new ConcurrentDictionary<string, IHtmlFeature>();

        #endregion

        #region Properties

        public int Count => _hashSet.Count;

        public bool IsReadOnly => false;

        #endregion

        #region Methods

        public void Add(IHtmlFeature item)
        {
            _hashSet.AddOrUpdate(item.Name, item, (i, j) => { return j; });
        }

        public object GetValue(string name)
        {
            if (_hashSet.TryGetValue(name, out IHtmlFeature attribute))
            {
                return attribute.Value;
            }

            return null;
        }

        public void Clear()
        {
            _hashSet.Clear();
        }

        public bool Contains(IHtmlFeature item)
        {
            return _hashSet.ContainsKey(item.Name);
        }

        public void CopyTo(IHtmlFeature[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IHtmlFeature> GetEnumerator()
        {
            return new HtmlFeatureCollectionEnumerator(_hashSet);
        }

        public bool Remove(IHtmlFeature item)
        {
            return _hashSet.TryRemove(item.Name, out IHtmlFeature val);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _hashSet.GetEnumerator();
        }

        #endregion
    }
}