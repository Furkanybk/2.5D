using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/RunningToJump")]
public class RunningToJump : StateData
{ 
    public float JumpForce;
    public AnimationCurve Gravity;
    public AnimationCurve Pull;
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * JumpForce);
        animator.SetBool(TransitionParameters.Grounded.ToString(), false);
    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        control.GravityMultipler = Gravity.Evaluate(stateInfo.normalizedTime);
        control.PullMultipler = Pull.Evaluate(stateInfo.normalizedTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}
