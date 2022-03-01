using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbToTopState : StateMachineBehaviour
{
    Vector3 startingTransformPos;
    CharacterMovement charMove;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        charMove = animator.GetComponent<CharacterMovement>();
        startingTransformPos = animator.gameObject.transform.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //Vector3 interpolatedPosition = Vector3.Lerp(startingTransformPos, 
    //    //    new Vector3(startingTransformPos.x, startingTransformPos.y+ 1.67f, startingTransformPos.z + 1.29f), 
    //    //    stateInfo.normalizedTime);
    //    //animator.gameObject.transform.position = interpolatedPosition;

    //    //animator.gameObject.transform.position = startingTransformPos +
    //    //    new Vector3(
    //    //    0,
    //    //    1.67f * stateInfo.normalizedTime,
    //    //    1.29f * stateInfo.normalizedTime);
    //    //animator.gameObject.transform.position = animator.bodyPosition;
    //    //Debug.Log("body pos: " + animator.bodyPosition);
        
        
    //    //Debug.Log(animator.GetFloat("ClimbToTopCurveY"));
    //    //charMove.transform.position = startingTransformPos + new Vector3(0, animator.GetFloat("ClimbToTopCurveY"), 
    //    //    animator.GetFloat("ClimbToTopCurveZ"));

    //}


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Rigidbody rb = animator.gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

        }

        //animator.gameObject.transform.position = new Vector3(
        //    animator.gameObject.transform.position.x,
        //    animator.gameObject.transform.position.y + 2.2f,
        //    animator.gameObject.transform.position.z + 1.29f);
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
