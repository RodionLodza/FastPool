using Tools.FastPool;
using UnityEngine;

public class SomePoolObject : MonoBehaviour, IPoolableObject
{
    public IPoolableObject nextNoActiveObject { get; set; }

    public void ResetStateObject()
    {
        // some action for reset state of pool object
    }
}