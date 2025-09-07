using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    public class MapCreator<TType, T> : MonoBehaviour, IInitializable where TType : Enum
    {
        [field: SerializeField] private List<Pair> PairList;
        protected List<T> Values => Dictionary.Values.ToList();
        protected Dictionary<TType, T> Dictionary { get; } = new();

        public void Initialize()
        {
            foreach (var pair in PairList) Dictionary.Add(pair.Type, pair.Object);
        }

        public T GetObject(TType type)
        {
            return Dictionary[type];
        }

        [Serializable]
        private class Pair
        {
            [field: SerializeField] public T Object { get; private set; }
            [field: SerializeField] public TType Type { get; private set; }
        }
    }
}