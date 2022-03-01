using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    
    public interface IPlayerState
    {
        public abstract IPlayerState HandleInput(Player player);
        public abstract void Update(Player player);
        public abstract void EnterState(Player player);
    }

    public class StandingState : MonoBehaviour, IPlayerState
    {
        public void EnterState(Player player)
        {
            player.animator.Play(Player.Stand);
        }

        public IPlayerState HandleInput(Player player)
        {
            //can go anywhere from standing
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                return new CrouchingState();
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                return new JumpingState();
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                return new AttackingState();
            }
            else if(Input.GetKeyDown(KeyCode.W))
            {
                return new WalkingState();
            }

            return null;

        }
        public void Update(Player player)
        {
            
        }
    }

    public class JumpingState : MonoBehaviour, IPlayerState
    {
        public void EnterState(Player player)
        {
            player.animator.Play(Player.Jump);
        }

        public IPlayerState HandleInput(Player player)
        {
            //can only enter jumping from standing and it only exits of its own accord, not from input?
            if(player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                return new StandingState();
            }

            return null;
        }
        public void Update(Player player)
        {

        }
    }

    public class CrouchingState : MonoBehaviour, IPlayerState
    {
        private float chargeTime;
        private float maxCharge = 5f;

        public void EnterState(Player player)
        {
            player.animator.Play(Player.Crouch);
        }

        public IPlayerState HandleInput(Player player)
        {
            //if you release control or try to jump you just stand
            if(Input.GetKeyUp(KeyCode.LeftControl))
            {
                return new StandingState();
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                return new StandingState();
            }

            return null;
        }

        public void Update(Player player)
        {
            chargeTime += Time.deltaTime;
            if(chargeTime >= maxCharge)
            {
                chargeTime = 0;
                player.SuperBomb();
            }
        }
    }

    public class AttackingState : MonoBehaviour, IPlayerState
    {
        public void EnterState(Player player)
        {
            player.animator.Play(Player.Attack);
        }

        public IPlayerState HandleInput(Player player)
        {
            //like jumping it just returns on its own?
            if(player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                return new StandingState();
            }

            return null;
        }
        public void Update(Player player)
        {
            //what's the point of this if handleinput is also called on update?
        }
    }

    public class WalkingState : MonoBehaviour, IPlayerState
    {

        public void EnterState(Player player)
        {
            player.animator.Play(Player.Walk);
        }

        public IPlayerState HandleInput(Player player)
        {
            //if you release control or try to jump you just stand
            if(Input.GetKeyUp(KeyCode.W))
            {
                return new StandingState();
            }

            return null;
        }

        public void Update(Player player)
        {
            
        }
    }
}
