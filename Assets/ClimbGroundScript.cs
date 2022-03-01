using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbGroundScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement charMove = other.gameObject.GetComponent<CharacterMovement>();
        if(!charMove)
            return;

        if(charMove.isFalling)
            return;

        if(charMove.isClimbing)
        {
            charMove.animator.SetTrigger("ExitClimbToIdle");

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if(rb)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }

    }
}
