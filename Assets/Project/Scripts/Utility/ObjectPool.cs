using System.Collections.Generic;
using UnityEngine;


namespace Project
{
    public class ObjectPool<T> where T : Component
    {
        
        private readonly Transform _parentTransform;
        private readonly T _prefab;

        public ObjectPool(T prefab, int initialSize, Transform parentTransform)
        {
            _prefab = prefab;
            _parentTransform = parentTransform;
            Pool = new List<T>();

            // Pre-instantiate objects in the pool
            for (var i = 0; i < initialSize; i++)
            {
                var obj = CreateNewObject();
                obj.gameObject.SetActive(false);
                Pool.Add(obj);
            }
        }

        public List<T> Pool { get; }

        private T CreateNewObject()
        {
            // Instantiate a new object and set its parent to the provided parentTransform
            var obj = Object.Instantiate(_prefab.gameObject, _parentTransform);
            return obj.GetComponent<T>();
        }

        public T GetObject()
        {
            // Find an inactive object in the pool
            foreach (var obj in Pool)
                if (!obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }

            // If no inactive object is found, instantiate a new one
            var newObj = CreateNewObject();
            newObj.gameObject.SetActive(true);
            Pool.Add(newObj);
            return newObj;
        }

        public void ReturnObject(T obj)
        {
            // Deactivate the object to return it to the pool
            obj.gameObject.SetActive(false);
        }
    }
}