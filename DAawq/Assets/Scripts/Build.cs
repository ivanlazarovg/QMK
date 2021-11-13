using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Build : MonoBehaviour, IPointerClickHandler
{
    public GameObject tower;
    public Transform place;
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Instantiate(tower, new Vector2(place.position.x, place.position.y), Quaternion.identity);
        tower.GetComponent<DragDrop>().isDragging = true;

    }
}
