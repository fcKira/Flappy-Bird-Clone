using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGO : MonoBehaviour, IScreen
{
    Dictionary<Behaviour, bool> _beforeGameObjects;

    Transform _root;

    private void Awake()
    {
        _root = transform;

        _beforeGameObjects = new Dictionary<Behaviour, bool>();
    }

    public void Activate()
    {
        foreach (var keyValue in _beforeGameObjects)
        {
            keyValue.Key.enabled = keyValue.Value;
        }
    }

    public void Deactivate()
    {
        foreach (var b in _root.GetComponentsInChildren<Behaviour>())
        {
            _beforeGameObjects[b] = b.enabled;

            b.enabled = false;
        }
    }

    public void Free()
    {
        GameObject.Destroy(_root.gameObject);
    }

    
}
