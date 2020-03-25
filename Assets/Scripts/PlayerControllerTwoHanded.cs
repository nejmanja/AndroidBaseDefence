using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwoHanded : MonoBehaviour
{
    public FixedJoystick movementJoystick, shootJoystick;
    public Vector3 shootDir;
    public float shootRate;
    public GameObject bulletPrefab;

    private bool isShooting;
    void Update()
    {
        if (movementJoystick.Direction != Vector2.zero)
        {
            shootDir = shootJoystick.Direction;
            transform.position += (Vector3)(movementJoystick.Direction / 10);
        }

        if(shootJoystick.Direction != Vector2.zero)
        {
            shootDir = shootJoystick.Direction.normalized;
            Debug.DrawRay(transform.position, shootDir, Color.red);
            if (!isShooting)
            {
                InvokeRepeating("Shoot", 0, shootRate);
                isShooting = true;
            }
        }
        else
        {
            if(isShooting)
            {
                CancelInvoke("Shoot");
                isShooting = false;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = ObjectPooler.instance.SpawnFromPool(ObjectPooler.PoolType.Pellet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = shootDir * 20;
    }
}
