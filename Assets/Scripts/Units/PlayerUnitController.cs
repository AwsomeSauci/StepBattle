using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : Unit
{
    [SerializeField] private BaseAction[] _actions;

    private BaseAction _crntAction;
    private int _tmp;
    private WaitForSeconds _sleep = new WaitForSeconds(0.1f);
    private bool _actionUsed = false;

    void Start()
    {
        StartCoroutine(StartSleep());        
        EventController.StepPassed += SelectAction;
    }

    private void SelectAction()
    {
        _actionUsed = false;
        _tmp = Random.Range(0, _actions.Length);
        _crntAction = _actions[_tmp];
    }
    
    public BaseAction GetCrntAction()
    {
        if (!_actionUsed)
        {
            EventController.OnActionSelected(_crntAction);
            return _crntAction;
        }
        return null;
    }

    public void SetActionUsed()
    {
        _actionUsed = true;
    }

    public bool CheckAction()
    {
        return _actionUsed;
    }

    private IEnumerator StartSleep()
    {
        yield return _sleep;
        SelectAction();
    }
}
