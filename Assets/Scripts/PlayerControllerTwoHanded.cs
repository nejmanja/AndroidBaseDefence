using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwoHanded : MonoBehaviour
{
    public FixedJoystick movementJoystick, shootJoystick;
    public Vector3 shootDir;
    private bool isShooting;
    public RangedWeapon currentWeapon;
    Coroutine lastRoutine = null;
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
