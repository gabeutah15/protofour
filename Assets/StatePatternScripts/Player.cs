using StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    public IPlayerState _state;
    [SerializeField]
    private GameObject bombPSPrefab = null;

    public static readonly int Jump = Animator.StringToHash("JumpInPlace");
    public static readonly int Stand = Animator.StringToHash("Idle");
    public static readonly int Crouch = Animator.StringToHash("Crouch");
    public static readonly int Attack = Animator.StringToHash("Attack");
    public static readonly int Walk = Animator.StringToHash("Walk");


    private void Start()
    {
        animator = GetComponent<Animator>();
        _state = new StandingState();//need to do this to start?
    }

    // Start is called before the first frame update
    void HandleInput()
    {
        IPlayerState state = _state.HandleInput(this);
        if(state != null)
        {
            _state = null;//is this needed?
            _state = state;
            _state.EnterState(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        _state.Update(this);
    }

    public void SuperBomb()
    {
        GameObject bombInstance = Instantiate(bombPSPrefab, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
        bombInstance.GetComponent<ParticleSystem>().Play();
    }
}
