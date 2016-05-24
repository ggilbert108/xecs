using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Xecs
{
    public class Entity
    {
        public event EventHandler ComponentsChanged;

        public int Id;
        private Dictionary<Type, IComponent> components;  

        public Entity(int id)
        {
            Id = id;
            components = new Dictionary<Type, IComponent>();
        }

        public void AddComponent(IComponent component)
        {
            components[component.GetType()] = component;
            ComponentsChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveComponent<T>() where T : IComponent
        {
            components.Remove(typeof (T));
            ComponentsChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool HasComponent<T>() where T : IComponent
        {
            return components.ContainsKey(typeof (T));
        }

        public T GetComponent<T>() where T : IComponent
        {
            return (T) components[typeof (T)];
        }
    }
}