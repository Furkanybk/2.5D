using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/Sprint")]
public class Sprint : StateData
{
    public bool MustRequireMovement;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {  

    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        if(control.Sprint)
        {
            if(MustRequireMovement)
            {
                if(control.MoveLeft || control.MoveRight)
                { 
                    animator.SetBool(TransitionParameters.Sprint.ToString(), true);
                }
            }
            else
            {
                animator.SetBool(TransitionParameters.Sprint.ToString(), true);
            }
        }
        else
        {
            animator.SetBool(TransitionParameters.Sprint.ToString(), false);
        }

        if (control.Jump)
        {
            animator.SetBool(TransitionParameters.RunJump.ToString(), true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
    } 
}
