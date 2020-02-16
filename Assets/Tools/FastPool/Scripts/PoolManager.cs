using System.Collections.Generic;
using System;

namespace Tools.FastPool
{
    public class PoolManager<T> where T : IPoolableObject
    {
        private Func<T> objectGenerator;
        private List<T> poolObjects;
        private int countObjects;
        private T firstNoActiveObject;

        public PoolManager(int countObjects, Func<T> objectGenerator)
        {
            this.countObjects = countObjects;
            this.objectGenerator = objectGenerator;
        }

        public void Initialize()
        {
            poolObjects = new List<T>(countObjects);

            for (int i = 0; i < countObjects; i++)
                poolObjects.Add(objectGenerator.Invoke());

            for (int i = 0; i < countObjects - 1; i++)
                poolObjects[i].nextNoActiveObject = poolObjects[i + 1];

            firstNoActiveObject = poolObjects[0];
        }

        public T Pop()
        {
            if (firstNoActiveObject != null)
            {
                T poolObject = (T)firstNoActiveObject;
                firstNoActiveObject = (T)poolObject.nextNoActiveObject;
                return poolObject;
            }
            else
            {
                T newPoolObject = objectGenerator.Invoke();
                poolObjects.Add(newPoolObject);
                countObjects++;
                return newPoolObject;
            }
        }

        public void Push(T poolObject)
        {
            poolObject.ResetStateObject();
            poolObject.nextNoActiveObject = firstNoActiveObject;
            firstNoActiveObject = poolObject;
        }
    }
}