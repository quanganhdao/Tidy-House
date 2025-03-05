using System.Collections;
using System.Collections.Generic;
using DarkTonic.PoolBoss;
using UnityEngine;
using UnityEngine.Events;

public class ActionOnAwake : MonoBehaviour
{

    [SerializeField] private UnityEvent OnAwake;
    [SerializeField] private UnityEvent OnStart;
    [SerializeField] private UnityEvent OnEnable;

    void Awake()
    {
        OnAwake?.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnStart?.Invoke();
    }
}
