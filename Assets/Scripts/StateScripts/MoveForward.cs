using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/MoveForward")]
public class MoveForward : StateData
{
    public AnimationCurve SpeedGraph;
    public float Speed;
    public float BlockDistance;
    private bool Self;
    public bool LockDirection;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.MoveRight && control.MoveLeft)
        {
            animator.SetBool(TransitionParameters.Move.ToString(), false);
            return;
        }

        if (!control.MoveRight && !control.MoveLeft)
        {
            animator.SetBool(TransitionParameters.Move.ToString(), false);
            return;
        }

        if (control.MoveRight)
        {
            if(!CheckFront(control))
            { 
                control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }  
        }
        if (control.MoveLeft)
        {
            if (!CheckFront(control))
            {
                control.transform.Translate(Vector3.forward * Speed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }  
        }

        CheckTurn(control);

        if(control.Jump)
        {
            animator.SetBool(TransitionParameters.Jump.ToString(), true);
        } 
    }

    private void CheckTurn(CharacterControl control)
    {
        if(!LockDirection)
        {
            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        } 
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    bool CheckFront(CharacterControl control)
    { 
        foreach (GameObject o in control.FrontSpheres)
        {
            Self = false;

            Debug.DrawRay(o.transform.position, control.transform.forward * 0.3f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, control.transform.forward, out hit, BlockDistance))
            {
                foreach(Collider c in control.RagdollParts)
                {
                    if(c.gameObject == hit.collider.gameObject)
                    {
                        Self = true;
                        break;
                    }
                }

                if(!Self)
                { 
                    return true;
                }
            }
        }
        return false;
    }
}
