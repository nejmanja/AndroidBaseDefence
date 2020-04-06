using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifeTime;
    public float damage;
    void OnEnable()
    {
        StartCoroutine(DelayedDeactivate());
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);

    }

    IEnumerator DelayedDeactivate()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
        yield return null;
    }
}
