using System.Collections.Generic;
using System;

namespace FastPool
{
    public class PoolManager<T> where T : IPoolable
    {
        private Func<T> objectGenerator;
        private List<T> poolObjects;
        private int countObjects;
        private T firstInactiveObject;

        public PoolManager(int countObjects, Func<T> objectGenerator)
        {
            this.countObjects = countObjects;
            this.objectGenerator = objectGenerator;

            poolObjects = new List<T>(countObjects);

            for (int i = 0; i < countObjects; i++)
                poolObjects.Add(objectGenerator.Invoke());

            for (int i = 0; i < countObjects - 1; i++)
                poolObjects[i].NextInactiveObject = poolObjects[i + 1];

            firstInactiveObject = poolObjects[0];
        }

        public T Pop()
        {
            if (firstInactiveObject != null)
            {
                T poolObject = (T)firstInactiveObject;
                firstInactiveObject = (T)poolObject.NextInactiveObject;
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
            poolObject.NextInactiveObject = firstInactiveObject;
            firstInactiveObject = poolObject;
        }
    }
}