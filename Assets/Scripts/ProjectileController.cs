using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifeTime;
    void OnEnable()
    {
        StartCoroutine(DelayedDeactivate());
    }


    IEnumerator DelayedDeactivate()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
        yield return null;
    }
}
