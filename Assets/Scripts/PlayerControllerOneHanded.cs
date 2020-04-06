using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerControllerOneHanded : MonoBehaviour
{
    // Start is called before the first frame update

    public FixedJoystick joystick;
    public GameObject bulletPrefab;
    public Vector3 shootDir;
    public Button shootButton;
    public RangedWeapon currentWeapon;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Direction != Vector2.zero)
        {
            shootDir = joystick.Direction.normalized;
            currentWeapon.transform.right = shootDir;
            transform.position += (Vector3)(joystick.Direction / 10);
        }
        Debug.DrawRay(transform.position, shootDir, Color.red);
    }
}
