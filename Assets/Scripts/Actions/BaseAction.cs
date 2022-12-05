using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    [SerializeField] protected int _actionPower;
    protected const string _enemyTag = "enemy";
    protected const string _playerUnitTag = "unit";

    public abstract bool PerformAction(GameObject unitFrom, GameObject unitTarget);

    public void SetPower(int value)
    {
        _actionPower= value;
    }

    private void Start()
    {
        EventController.ActionSelected += Deactivate;
    }

    private void Deactivate(BaseAction _crntAction)
    {
        if (_crntAction != this)
        {
            this.gameObject.SetActive(false);
        }
    }
}
