using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FactoryPrototype<T> : MonoSingleton<FactoryPrototype<T>> where T : ScriptableObject
{
    private Dictionary<int, T> _prototypes = new Dictionary<int, T>(); 

    public T GetInstance(int id)
    {
        if (_prototypes.ContainsKey(id))
            return _prototypes[id];
        return null;
    }

    protected void Register(T instance, int id)
    {
        if(_prototypes.ContainsKey(id))
        {
            Debug.LogError($"{id} has Already Registered by {_prototypes[id].name}");
        }
        else
        {
            _prototypes.Add(id, instance);
        }
    }

    public virtual void Initialize()
    {

    }
}
