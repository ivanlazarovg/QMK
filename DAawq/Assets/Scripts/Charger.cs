using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Charger : MonoBehaviour
{
    public GameObject activeTower;
    public float waitTime;
    public float waitingTime;
    public GameObject timerUI;
    public bool isTimerRunning;
    float t = 0;

    private void Start()
    {
        waitingTime = waitTime;
        isTimerRunning = false;

    }

    private void Update()
    {

        if (isTimerRunning)
        {
            activeTower.GetComponent<Tower>().isDisabled = true;
            waitingTime -= Time.deltaTime;
            timerUI.GetComponent<TextMeshPro>().text = waitingTime.ToString();
            Charging(activeTower.GetComponent<Tower>().charge, activeTower.GetComponent<Tower>().maxCharge);
            if (waitingTime <= 0)
            {
                activeTower.GetComponent<Tower>().isDisabled = false;
                isTimerRunning = false;
                
                Reset();
            }
        }

    }

    private void Reset()
    {
        waitingTime = waitTime;
    }

    private float Charging(float currentCharge, int fullCharge)
    {
        t += Time.deltaTime;
        float charge = Mathf.Lerp(currentCharge, fullCharge, t);
        return charge; 
    }
}
