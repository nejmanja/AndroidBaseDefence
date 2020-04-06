using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwoHanded : MonoBehaviour
{
    public FixedJoystick movementJoystick, shootJoystick;
    public Vector3 shootDir;
    public float speed = 200f;
    private bool isShooting;
    public RangedWeapon currentWeapon;
    Coroutine lastRoutine = null;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = movementJoystick.Direction * speed * Time.deltaTime;

        if(shootJoystick.Direction != Vector2.zero)
        {
            shootDir = shootJoystick.Direction.normalized;
            currentWeapon.transform.right = shootDir;
            Debug.DrawRay(transform.position, shootDir, Color.red);
            if (!isShooting)
            {
                isShooting = true;
                lastRoutine = currentWeapon.StartCoroutine(currentWeapon.Shoot());
            }
        }
        else
        {
            if(isShooting)
            {
                currentWeapon.StopCoroutine(lastRoutine);
                isShooting = false;
            }
        }
    }
}
