using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/CheckRunningTurn")]
public class CheckRunningTurn : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        if (control.IsPositive())
        
        {
            if(control.MoveLeft)
            {
                animator.SetBool(TransitionParameters.Turn.ToString(), true);
            }
        }

        if (!control.IsPositive())
        {
            if (control.MoveRight)
            {
                animator.SetBool(TransitionParameters.Turn.ToString(), true);
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(TransitionParameters.Turn.ToString(), false);
    }
}
