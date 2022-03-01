using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehavior : StateMachineBehaviour
{
    //public float diveSpeed = 10f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsFalling", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //while(stateInfo.normalizedTime < .8)
        //{
            Transform transform = animator.gameObject.transform;
            Vector3 newPosition = transform.position;
            newPosition.z += 3 * Time.deltaTime * animator.GetFloat("DiveCurve");
            transform.position = newPosition;
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //animator.gameObject.transform.position = new Vector3

    //    //Transform transform = animator.gameObject.transform;
    //    //Vector3 newPosition = transform.position;
    //    //newPosition.z +=  2f;
    //    //transform.position = newPosition;
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //    //Transform transform = animator.gameObject.transform;
    //    //Vector3 newPosition = transform.position;
    //    //newPosition.z += diveSpeed * Time.deltaTime;
    //    //transform.position = newPosition;
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
