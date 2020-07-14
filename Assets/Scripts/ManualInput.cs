using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInput : MonoBehaviour
{
    private CharacterControl characterControl;

    private void Awake()
    {
        characterControl = this.gameObject.GetComponent<CharacterControl>();
    }

    private void Update()
    {
        if(VirtualInputManager.Instance.MoveRight)
        {
            characterControl.MoveRight = true;
        }
        else
        {
            characterControl.MoveRight = false;
        }

        if (VirtualInputManager.Instance.MoveLeft)
        {
            characterControl.MoveLeft = true;
        }
        else
        {
            characterControl.MoveLeft = false;
        }
        
        if(VirtualInputManager.Instance.Jump)
        {
            characterControl.Jump = true;
        }
        else
        {
            characterControl.Jump = false;
        }

        if (VirtualInputManager.Instance.Sprint)
        {
            characterControl.Sprint = true;
        }
        else
        {
            characterControl.Sprint = false;
        }

        if(VirtualInputManager.Instance.Grapple)
        {
            characterControl.Grapple = true;
        }
        else
        {
            characterControl.Grapple = false;
        }
    }
}
