using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAutoAtack : MonoBehaviour
{
    private List<Unit> _enemyUnits;
    private List<Unit> _playerUnitsList;
    private WaitForSeconds _sleep = new WaitForSeconds(1f);
    private int _temp;

    private void Start()
    {
        EventController.EnemyQuene += StartAtackQueue;
        EventController.UnitDied += UpdateUnitsList;
        _playerUnitsList = FindObjectsOfType<PlayerUnitController>().ToList<Unit>();
        _enemyUnits = gameObject.GetComponentsInChildren<EnemyUnit>().ToList<Unit>();
    }

    private void StartAtackQueue()
    {
        StartCoroutine(AtackQueue());
    }

    private IEnumerator AtackQueue()
    {
        foreach(EnemyUnit unit in _enemyUnits)
        {
            _temp = Random.Range(0, _playerUnitsList.Count);    
            unit.AtackUnit(_playerUnitsList[_temp].gameObject);
            yield return _sleep;
        }
        EventController.OnEnemyQueneEnd();
    }

    private void UpdateUnitsList(Unit unit)
    {
        _playerUnitsList.Remove(unit);
        _enemyUnits.Remove(unit);
    }
}
