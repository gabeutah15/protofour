using UnityEngine;

public class ClimbStartScript : MonoBehaviour
{
    [SerializeField]
    Transform startPosition;
    float bottomExitTimer = 0.0f;
    [SerializeField]
    GameObject ExitClimbOnGround;
    CharacterMovement charMove;

    private void OnTriggerEnter(Collider other)
    {
        charMove = other.gameObject.GetComponent<CharacterMovement>();

        if(charMove.isFalling && !charMove.isJumping)
            return;

        if (charMove && !charMove.isClimbing)
        {
            bottomExitTimer = 0;
            ExitClimbOnGround.SetActive(false);
            charMove.isClimbing = true;
            charMove.animator.SetBool("IsClimbing", true);
            charMove.isFalling = false;
            charMove.animator.SetBool("IsFalling", false);
            charMove.transform.position = new Vector3(charMove.transform.position.x, charMove.transform.position.y, startPosition.position.z);
            charMove.transform.rotation = startPosition.rotation;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.useGravity = false;
                rb.isKinematic = true;//this better than gravity false?
            }
        }

    }

    private void Update()
    {
        if(charMove)
        {
            if(charMove.isClimbing)
            {
                bottomExitTimer += Time.deltaTime;
                if(bottomExitTimer > 2)
                {
                    ExitClimbOnGround.SetActive(true);
                }
            }
        }
    }
}
