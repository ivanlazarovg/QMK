using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragDrop : MonoBehaviour
{
    public bool isDragging;
    Upgrader[] upgradestuffs;
    Charger[] chargestuffs;
    [SerializeField]
    float radiusUpgrader;

    private void Start()
    {
        upgradestuffs = FindObjectsOfType<Upgrader>();
        chargestuffs = FindObjectsOfType<Charger>();
        
    }

    private void OnMouseDown()
    {
        
        isDragging = true;
    }

    private void OnMouseUp()
    {
        ActivateChargeBuilding();
        ActivateUpgradeBuilding();
        
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePostion);
        }
    }

    public void ActivateUpgradeBuilding()
    {
        float minDistance = 100;
        GameObject pain = null;
        foreach (var item in upgradestuffs)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                pain = item.gameObject;
            }
        }
        if (minDistance < radiusUpgrader)
        {
            transform.position = pain.transform.position;
            pain.GetComponent<Upgrader>().activeTower = this.gameObject;

            foreach (var item in pain.GetComponentsInChildren<TextMeshPro>())
            {
                item.enabled = true;
            }

        }
        isDragging = false;
    }
    public void ActivateChargeBuilding()
    {
        float minDistance = 100;
        GameObject pain = null;
        foreach (var item in chargestuffs)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                pain = item.gameObject;
            }
        }
        if (minDistance < radiusUpgrader)
        {
            transform.position = pain.transform.position;
            pain.GetComponent<Charger>().activeTower = this.gameObject;

            pain.GetComponent<Charger>().isTimerRunning = true;

        }
        isDragging = false;
    }
}

