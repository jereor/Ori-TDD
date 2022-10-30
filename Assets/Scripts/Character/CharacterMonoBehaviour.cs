using GameFramework.ComponentService;
using UnityEngine;

namespace Character
{
    public class CharacterMonoBehaviour : MonoBehaviour
    {
        public ComponentService ComponentService { get; set; }

        public void AddCoreComponent(object component)
        {
            ComponentService.AddComponent(component);
        }
        
        public T GetCoreComponent<T>()
        {
            return ComponentService.GetComponent<T>();
        }
        
    }
}