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
    public float speed = 200f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = joystick.Direction * speed * Time.deltaTime;
        if (joystick.Direction != Vector2.zero)
        {
            shootDir = joystick.Direction.normalized;
            currentWeapon.transform.right = shootDir;
            //transform.position += (Vector3)(joystick.Direction / 10);
        }
        Debug.DrawRay(transform.position, shootDir, Color.red);
    }
}
