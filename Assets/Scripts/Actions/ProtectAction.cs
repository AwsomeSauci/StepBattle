using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectAction : BaseAction
{
    [SerializeField] private int _duration;
    public override bool PerformAction(GameObject unitFrom, GameObject unitTarget)
    {
        if (unitTarget.tag != _playerUnitTag) return false;
        unitTarget.GetComponent<HPController>().ProtectAction(_actionPower, _duration);
        return true;
    }
}
