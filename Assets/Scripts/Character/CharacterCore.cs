using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Character
{
    public class CharacterCore : MonoBehaviour
    {
        private readonly List<object> _coreComponents = new List<object>();

        public void AddCoreComponent(object component)
        {
            if (_coreComponents.Contains(component))
            {
                // TODO: Use custom logger
                //Logger.Log($"{component.GetType()} is already a component in PlayerCore. Will not add this component to avoid duplication.");
                return;
            }
            
            _coreComponents.Add(component);
        }
        
        public T GetCoreComponent<T>()
        {
            T component = _coreComponents.OfType<T>().FirstOrDefault();
            
            if (component == null)
            {
                // TODO: Use custom logger
                //Logger.LogError($"{typeof(T)} not found on {transform.name}");
            }
            
            return component;
        }
    }
}