using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTwoHanded : MonoBehaviour
{
    public FixedJoystick movementJoystick, shootJoystick;
    public Vector3 shootDir;

    void Update()
    {
        if (movementJoystick.Direction != Vector2.zero)
        {
            shootDir = shootJoystick.Direction;
            transform.position += (Vector3)(movementJoystick.Direction / 10);
            Debug.DrawRay(transform.position, shootDir, Color.red);
        }
    }
}
