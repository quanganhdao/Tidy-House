using UnityEngine;

public class GenericDisabler<T> : MonoBehaviour where T : Behaviour
{
    [SerializeField] private bool isDisableOnAwake;
    private T[] components;

    private void Awake()
    {
        components = GetComponents<T>();
        if (isDisableOnAwake)
        {
            DisableComponents();
        }
    }

    public void DisableComponents()
    {
        foreach (var component in components)
        {
            component.enabled = false;
        }
    }

    public void EnableComponents()
    {
        foreach (var component in components)
        {
            component.enabled = true;
        }
    }
}
