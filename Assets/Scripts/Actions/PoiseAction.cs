using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiseAction : BaseAction
{
    [SerializeField] private int _duration;
    public override bool PerformAction(GameObject unitFrom, GameObject unitTarget)
    {
        if (unitTarget.tag != _enemyTag) return false;
        unitTarget.GetComponent<HPController>().PoiseAction(-_actionPower, _duration);
        return true;
    }
}
