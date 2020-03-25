using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModeSwitcher : MonoBehaviour
{
    //Two handed mode items
    public Joystick shootJoystick;
    public PlayerControllerTwoHanded twoHanedController;
    //One handed mode items
    public UnityEngine.UI.Button shootButton;
    public PlayerControllerOneHanded oneHandedController;

    bool twoHanded = false;
    public void ButtonClicked()
    {
        twoHanded = !twoHanded;
        if (twoHanded)
        {
            Debug.Log("two handed");
            shootJoystick.gameObject.SetActive(true);
            twoHanedController.enabled = true;
            shootButton.gameObject.SetActive(false);
            oneHandedController.enabled = false;
        }
        else
        {
            Debug.Log("one handed");
            shootJoystick.gameObject.SetActive(false);
            twoHanedController.enabled = false;
            shootButton.gameObject.SetActive(true);
            oneHandedController.enabled = true;
        }
    }
}
