using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : MonoBehaviour
{
    public static event Action StepPassed;
    public static event Action PlayerStepEnded;
    public static event Action<BaseAction> ActionSelected;
    public static event Action<Unit> UnitDied;
    public static event Action<EnemyUnit> EnemyUnitDied;
    public static event Action ActionUsed;
    public static event Action EnemyQuene;
    public static event Action EnemyQueneEnd;

    public static void OnPlayerStepEnded()
    {
        PlayerStepEnded?.Invoke();
    }

    public static void OnEnemyQueneEnd()
    {
        EnemyQueneEnd?.Invoke();
    }

    public static void OnEnemyQuene()
    {
        EnemyQuene?.Invoke();
    }

    public static void OnActionUsed()
    {
        ActionUsed?.Invoke();
    }

    public static void OnUnitDied(Unit unit)
    {
        UnitDied?.Invoke(unit);
    }

    

    public static void OnStepPassed()
    {
        StepPassed?.Invoke();
    }

    public static void OnActionSelected(BaseAction crntAction)
    {
        ActionSelected?.Invoke(crntAction);
    }
}
