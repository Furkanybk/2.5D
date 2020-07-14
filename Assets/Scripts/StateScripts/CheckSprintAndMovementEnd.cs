using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/CheckSprintAndMovementEnd")]
public class CheckSprintAndMovementEnd : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        if ((control.MoveLeft || control.MoveRight) && control.Sprint)
        {
            animator.SetBool(TransitionParameters.Move.ToString(), true);
            animator.SetBool(TransitionParameters.Sprint.ToString(), true);
        }
        else
        {
            animator.SetBool(TransitionParameters.Move.ToString(), false);
            animator.SetBool(TransitionParameters.Sprint.ToString(), false);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
    }
}
