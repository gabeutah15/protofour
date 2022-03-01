using UnityEngine;

public class ClimbEndScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Climb End: " + other.gameObject.name);
        CharacterMovement charMove = other.gameObject.GetComponent<CharacterMovement>();
        if (charMove)
        {
            charMove.animator.SetBool("IsClimbing", false);
        }
    }
}
