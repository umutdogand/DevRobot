namespace ViewCreator.Components
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class FeatureCollection : ICollection<IFeature>
    {
        #region Fields

        private readonly ConcurrentDictionary<String, IFeature> _hashSet =
            new ConcurrentDictionary<string, IFeature>();

        #endregion

        #region Properties

        public int Count => _hashSet.Count;

        public bool IsReadOnly => false;

        #endregion

        #region Methods

        public void Add(IFeature item)
        {
            _hashSet.AddOrUpdate(item.Name, item, (i, j) => { return j; });
        }

        public object GetValue(string name)
        {
            if (_hashSet.TryGetValue(name, out IFeature attribute))
            {
                return attribute.Value;
            }

            return null;
        }

        public void Clear()
        {
            _hashSet.Clear();
        }

        public bool Contains(IFeature item)
        {
            return _hashSet.ContainsKey(item.Name);
        }

        public void CopyTo(IFeature[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IFeature> GetEnumerator()
        {
            return new FeatureCollectionEnumerator(_hashSet);
        }

        public bool Remove(IFeature item)
        {
            return _hashSet.TryRemove(item.Name, out IFeature val);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _hashSet.GetEnumerator();
        }

        #endregion
    }
}