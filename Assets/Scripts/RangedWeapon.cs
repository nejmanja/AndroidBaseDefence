using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public float fireRate;
    public float damage;
    public float range;
    float fireDelay;
    float lastShot;
    void Start()
    {
        fireDelay = 1 / fireRate;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Shoot()
    {
        if(Time.time - lastShot >= fireDelay)
        {
            lastShot = Time.time;

            //shoot
            while (true)
            {
                GameObject bullet = ObjectPooler.instance.SpawnFromPool(ObjectPooler.PoolType.Pellet, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 20;
                bullet.GetComponent<ProjectileController>().damage = damage;
                yield return new WaitForSeconds(fireDelay);

            }
        }
        yield return null;

    }
}
