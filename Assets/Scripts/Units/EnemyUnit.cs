using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    private AtackAction _action;
    private WaitForSeconds _sleep = new WaitForSeconds(0.1f);

    void Start()
    {
        _action = GetComponentInChildren<AtackAction>();
        StartCoroutine(StartSleep());
    }    

    public void AtackUnit(GameObject target)
    {
        _action.PerformAction(this.gameObject , target);
    }

    private IEnumerator StartSleep()
    {
        yield return _sleep;
        _action.SetPower(Random.Range(1, 5));
    }
}
