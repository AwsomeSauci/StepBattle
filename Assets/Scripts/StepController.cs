using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StepController : MonoBehaviour
{

    private void Start()
    {
        EventController.EnemyQueneEnd += PassOneStep;
        EventController.PlayerStepEnded += EndPlayerStep;
    }

    public void PassOneStep()
    {
        EventController.OnStepPassed();
    }

    public void EndPlayerStep()
    {
        EventController.OnActionSelected(null);
        EventController.OnEnemyQuene();
    }
}
