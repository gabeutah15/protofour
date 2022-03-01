using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : StateMachineBehaviour
{
    CharacterMovement charMove;
    float startingY;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        charMove = animator.GetComponent<CharacterMovement>();
        startingY = animator.transform.position.y;
        if (charMove)
        {
            charMove.isJumping = true;
            animator.SetBool("IsJumping", true);
            charMove.audioSource.loop = false;
            charMove.audioSource.clip = charMove.jumpClip;
            charMove.audioSource.Play();
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        charMove.transform.position = new Vector3(charMove.transform.position.x, animator.GetFloat("JumpCurve") * charMove.JumpHeight + startingY, charMove.transform.position.z);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (charMove)
        {
            charMove.isJumping = false;
            animator.SetBool("IsJumping", false);
            charMove.audioSource.loop = true;

        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
