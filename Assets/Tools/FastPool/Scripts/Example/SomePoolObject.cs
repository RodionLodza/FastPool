using UnityEngine;
using FastPool;

public class SomePoolObject : MonoBehaviour, IPoolable
{
    public IPoolable NextInactiveObject { get; set; }

    public void ResetStateObject()
    {
        // some action for reset state of pool object
    }
}