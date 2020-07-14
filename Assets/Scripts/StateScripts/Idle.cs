using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/Idle")]
public class Idle : StateData
{

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(TransitionParameters.Jump.ToString(), false);
    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if(control.Jump)
        {
            animator.SetBool(TransitionParameters.Jump.ToString(), true);
        }
        if (control.MoveRight)
        {
            animator.SetBool(TransitionParameters.Move.ToString(), true);
        }
        if (control.MoveLeft)
        {
            animator.SetBool(TransitionParameters.Move.ToString(), true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}
