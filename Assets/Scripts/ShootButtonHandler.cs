using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RangedWeapon currentWeapon;
    Coroutine lastRoutine = null;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("yes");
        lastRoutine = currentWeapon.StartCoroutine(currentWeapon.Shoot());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("no");
        currentWeapon.StopCoroutine(lastRoutine);
    }
}
