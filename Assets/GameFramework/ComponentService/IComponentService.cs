namespace GameFramework.ComponentService
{
    public interface IComponentService
    {
        void AddComponent<T>(T component);
        T GetComponent<T>();
    }
}