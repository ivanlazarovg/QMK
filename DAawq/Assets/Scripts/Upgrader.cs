using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Upgrader : MonoBehaviour
{
    public GameObject activeTower;
    public float waitTime;
    public float waitingTime;
    public GameObject timerUI;
    public bool isTimerRunning;
    public TowerUpgradeData activeTUD;

    private void Start()
    {
        waitingTime = waitTime;
        isTimerRunning = false;

    }

    private void Update()
    {

        if (isTimerRunning)
        {
            activeTower.SetActive(false);
            waitingTime -= Time.deltaTime;
            timerUI.GetComponent<TextMeshPro>().text = waitingTime.ToString();
            if (waitingTime <= 0)
            {
                activeTower.SetActive(true);
                isTimerRunning = false;
                activeTower.GetComponent<Tower>().Upgrade(activeTUD);
                Reset();
            }
        }

    }

    private void Reset()
    {
        waitingTime = waitTime;
    }


}
