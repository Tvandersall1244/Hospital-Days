using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverElement : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public static bool mouseOverItemDropLocation;
    public int slotNumber;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOverItemDropLocation = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOverItemDropLocation = false;
    }
}