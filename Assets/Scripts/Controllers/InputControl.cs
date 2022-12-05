using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputControl : MonoBehaviour
{
    private RaycastHit _hit;
    private BaseAction _selectedAction;
    private bool _select = false;
    private Vector3 _shift = new Vector3(0, 100, 0);
    private Vector3 _shift2 = new Vector3(0, 30, 0);
    private PlayerUnitController _lastSelectedUnit;
    private const string _enemyTag = "enemy";
    private const string _playerUnitTag = "unit";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventController.OnPlayerStepEnded();
        }

        if (_select)
        {
            _selectedAction.transform.position = Input.mousePosition + _shift2;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
            {
                if (_hit.transform.tag == _enemyTag && _select)
                {
                    PerformAction();
                }
                if (_hit.transform.tag == _playerUnitTag)
                {
                    if (_select)
                    {
                        PerformAction();
                    }
                    else if (_hit.transform.GetComponent<PlayerUnitController>().GetCrntAction() != null)
                    {
                        _lastSelectedUnit = _hit.transform.gameObject.GetComponent<PlayerUnitController>();
                        _selectedAction = _lastSelectedUnit.GetCrntAction();
                        _selectedAction.transform.gameObject.SetActive(true);
                        _selectedAction.transform.position = Input.mousePosition + _shift;
                    }
                }

            }
        }

    }

    private void PerformAction()
    {
        if (_selectedAction.PerformAction(_lastSelectedUnit.gameObject, _hit.transform.gameObject))
        {
            _lastSelectedUnit.SetActionUsed();
            EventController.OnActionUsed();
            _selectedAction.transform.gameObject.SetActive(false);
            _selectedAction = null;
            _select = false;
        }
    }

    public void IconSelect()
    {
        _select = true;
    }
}
