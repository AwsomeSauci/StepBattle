using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : BaseAction
{
    public override bool PerformAction(GameObject unitFrom, GameObject unitTarget)
    {
        if (unitTarget.tag != _playerUnitTag) return false;
        unitTarget.GetComponent<HPController>().HealAction(_actionPower);
        return true;
    }    
}
