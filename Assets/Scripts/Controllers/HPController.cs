using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField] private float _healPoints = 30;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _protectText;
    [SerializeField] private GameObject _poiseIcon;

    private Unit _thisUnit;
    private int _poiseSteps = 0;
    private int _protectSteps = 0;
    private int _protectCnt = 0;
    private int _poisePower = 0;
    private const string _plusSymbol = "+";

    void Start()
    {
        _thisUnit = GetComponent<Unit>();
        EventController.StepPassed += StepHandler;
    }

    private void StepHandler()
    {
        if (_poiseSteps > 0)
        {
            ChangeHP(_poisePower);
            _poiseSteps--;
        }
        else
        {
            _poiseIcon.SetActive(false);
        }
        if (_protectSteps > 0)
        {
            _protectSteps--;
        }
        else
        {
            _protectCnt = 0;
        }
        CheckHealth();
    }

    public void AtackAction(int damage)
    {
        ChangeHP(damage);
    }
    public void HealAction(int count)
    {
        ChangeHP(count);
    }
    public void PoiseAction(int damage, int time)
    {
        _poiseIcon.SetActive(true);
        _poisePower = damage;
        _poiseSteps = time-1;
        ChangeHP(_poisePower);
    }
    public void ProtectAction(int count, int time)
    {
        _protectSteps = time;
        _protectCnt = count;
        CheckHealth();
    }

    private void ChangeHP(int count)
    {
        if (count > 0)
        {
            _healPoints += count;
        }
        else
        {
            _protectCnt += count;
            if (_protectCnt < 0)
            {
                _healPoints += _protectCnt;
                _protectCnt = 0;
            }
        }
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_healPoints <= 0)
        {
            EventController.OnUnitDied(_thisUnit);
            Destroy(this.gameObject);
        }
        else
        {
            UpdateText();
        }
    }

    private void UpdateText()
    {
        _hpText.text = _healPoints.ToString();
        if (_protectCnt > 0)
        {
            _protectText.text = _plusSymbol + _protectCnt.ToString();
        }
        else
        {
            _protectText.text = "";
        }
    }
}
