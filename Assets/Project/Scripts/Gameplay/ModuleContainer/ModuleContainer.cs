using System;
using System.Collections.Generic;
using UnityEngine;


namespace Project
{
    public class ModuleContainer : MonoBehaviour
    {
        
        private List<object> _objects = new();
        public static ModuleContainer Instance { get; private set; }
        public virtual void Awake()
        {
            Instance = this;
        }

        public T GetObject<T>()
        {
            foreach (var obj in _objects)
            {
                if (obj is T obj1)
                {
                    return obj1;
                }
            }
            throw new System.NullReferenceException($"No object of type {typeof(T).Name} in container");
        }

        public void AddObject(object obj)
        {
            _objects.Add(obj);
        }

        public void Initialize()
        {
            foreach (var obj in _objects)
            {
                if (obj is IInitializable initializable)
                {
                    initializable.Initialize();
                }
            }
        }

        public void Dispose()
        {
            foreach (var obj in _objects)
            {
                if (obj is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
        
    }
}