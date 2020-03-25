using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerOneHanded : MonoBehaviour
{
    // Start is called before the first frame update

    public FixedJoystick joystick;
    public Vector3 shootDir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Direction != Vector2.zero)
        {
            shootDir = joystick.Direction;
            transform.position += (Vector3)(joystick.Direction / 10);
            Debug.DrawRay(transform.position, shootDir, Color.red);
        }
    }
}
