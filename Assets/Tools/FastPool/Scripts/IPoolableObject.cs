namespace FastPool
{
    public interface IPoolable
    {
        IPoolable NextInactiveObject { get; set; }
        void ResetStateObject();
    }
}