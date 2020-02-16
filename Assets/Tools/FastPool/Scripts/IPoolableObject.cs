namespace Tools.FastPool
{
    public interface IPoolableObject
    {
        IPoolableObject nextNoActiveObject { get; set; }

        void ResetStateObject();
    }
}