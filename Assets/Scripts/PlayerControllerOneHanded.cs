using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerOneHanded : MonoBehaviour
{
    // Start is called before the first frame update

    public FixedJoystick joystick;
    public GameObject bulletPrefab;
    public Vector3 shootDir;

    // Update is called once per frame
    void Update()
    {
        if(joystick.Direction != Vector2.zero)
        {
            shootDir = joystick.Direction.normalized;
            transform.position += (Vector3)(joystick.Direction / 10);
        }
        Debug.DrawRay(transform.position, shootDir, Color.red);
    }

    public void ShootButtonClicked()
    {
        Debug.Log("pew");
        //TODO: add object pool, this is inefficient
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject; 
        bullet.GetComponent<Rigidbody2D>().velocity = shootDir * 20;
    }
}
