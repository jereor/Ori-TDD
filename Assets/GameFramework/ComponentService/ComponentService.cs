using System.Collections.Generic;
using System.Linq;

namespace GameFramework.ComponentService
{
    public class ComponentService : IComponentService
    {
        public List<object> ComponentList { get; private set; }

        public static ComponentService Create()
        {
            ComponentService componentService = new ComponentService
            {
                ComponentList = new List<object>()
            };
            return componentService;
        }

        public void AddComponent<T>(T component)
        {
            if (ComponentList.OfType<T>().FirstOrDefault() != null)
            {
                // TODO: Use custom logger
                //Logger.Log($"{T} is already a component in PlayerCore. Will not add this component to avoid duplication.");
                return;
            }
            
            ComponentList.Add(component);
        }

        public T GetComponent<T>()
        {
            T component = ComponentList.OfType<T>().FirstOrDefault();
            
            if (component == null)
            {
                // TODO: Use custom logger
                //Logger.LogError($"{typeof(T)} not found on {transform.name}");
            }
            
            return component;
        }
    }
}