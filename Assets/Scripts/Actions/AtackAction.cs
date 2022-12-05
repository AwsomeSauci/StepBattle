using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackAction : BaseAction
{
    public override bool PerformAction(GameObject unitFrom, GameObject unitTarget)
    {
        if (unitFrom.tag == _enemyTag)
        {
            unitTarget.GetComponent<HPController>().AtackAction(-_actionPower);
        }
        else if(unitTarget.tag!=_enemyTag) return false;
        unitTarget.GetComponent<HPController>().AtackAction(-_actionPower);
        return true;
    }
}
