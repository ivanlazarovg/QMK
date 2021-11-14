using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIPickUpgrade : MonoBehaviour
{
    public Upgrader upgrader;
    public TowerUpgradeData towerUpgradeStats;


    private void Start()
    {
        upgrader = GetComponentInParent<Upgrader>();
        GetComponent<TextMeshPro>().enabled = false;
        
    }

    void OnMouseDown()
    {
        foreach(var item in transform.parent.gameObject.GetComponentsInChildren<UIPickUpgrade>())
        {
            item.GetComponent<TextMeshPro>().enabled = false;
        }
        upgrader.isTimerRunning = true;
        upgrader.activeTUD = towerUpgradeStats;
        
    }


    
}
