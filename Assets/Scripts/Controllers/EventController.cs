using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : MonoBehaviour
{
    public static event Action StepPassed;//ивент пройденного хода
    public static event Action PlayerStepEnded;//шаг игрока завершен
    public static event Action<BaseAction> ActionSelected;//отображен навык юнита игрока
    public static event Action<Unit> UnitDied;//смерть юнита
    public static event Action ActionUsed;//применено действие
    public static event Action EnemyQuene;//начало очереди врага
    public static event Action EnemyQueneEnd;//противник сделал все атаки

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
