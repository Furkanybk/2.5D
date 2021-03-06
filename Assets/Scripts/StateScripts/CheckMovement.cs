﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New State", menuName = "AbilityData/CheckMovement")]
public class CheckMovement : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        if (control.MoveLeft || control.MoveRight)
        {
            animator.SetBool(TransitionParameters.Move.ToString(), true); 
        }
        else
        {
            animator.SetBool(TransitionParameters.Move.ToString(), false); 
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
    }
}
