using Tools.FastPool;
using UnityEngine;

public class SomePoolManager : MonoBehaviour
{
    [SerializeField] private SomePoolObject poolObjectPrefab;
    [SerializeField] private int objectsCount;

    private PoolManager<SomePoolObject> poolManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        poolManager = new PoolManager<SomePoolObject>(objectsCount, ObjectGenerator);
        poolManager.Initialize();
    }

    private SomePoolObject ObjectGenerator()
    {
        return Instantiate(poolObjectPrefab);
    }

    public void PopObjectsTest()
    {
        poolManager.Pop();
    }

    public void PushObjectsTest(SomePoolObject unnecessaryPoolObject)
    {
        poolManager.Push(unnecessaryPoolObject);
    }
}