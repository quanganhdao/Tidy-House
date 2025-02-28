using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ConditionManager : MonoBehaviour
{
    [SerializeField] private Transform conditionContainer;
    private List<Condition> conditions;


    [SerializeField] private UnityEvent OnAllConditionsMatched;
    // Start is called before the first frame update
    void Start()
    {
        conditions = GetAllCondition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private List<Condition> GetAllCondition()
    {
        return conditionContainer.GetComponentsInChildren<Condition>().ToList();
    }
}
