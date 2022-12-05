using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    private List<Unit> _enemyUnits;
    private List<Unit> _playerUnitsList;

    private void Start()
    {
        EventController.UnitDied += UpdateUnitsList;
        _playerUnitsList = FindObjectsOfType<PlayerUnitController>().ToList<Unit>();
        _enemyUnits = FindObjectsOfType<EnemyUnit>().ToList<Unit>();
    }

    private void UpdateUnitsList(Unit unit)
    {
        _playerUnitsList.Remove(unit);
        _enemyUnits.Remove(unit);
        CheckLists();
    }

    private void CheckLists()
    {
        if(_playerUnitsList.Count==0) _loseScreen.SetActive(true);
        if(_enemyUnits.Count==0) _winScreen.SetActive(true);
    }
}
