using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool isDragging;
    Upgrader[] upgradestuffs;
    [SerializeField]
    float radiusUpgrader;

    private void Start()
    {
        upgradestuffs = FindObjectsOfType<Upgrader>();
        
    }

    private void OnMouseDown()
    {
        
        isDragging = true;
    }

    private void OnMouseUp()
    {

        float minDistance = 100;
        GameObject pain = null;
        foreach (var item in upgradestuffs)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                pain = item.gameObject;
            }
        }
        if(minDistance < radiusUpgrader)
        {
            transform.position = pain.transform.position;
        }
        isDragging = false;
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePostion);
        }
    }
}
