using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerModel player;
        [SerializeField] private Animator animator;

        private static readonly int IsWalk = Animator.StringToHash("IsWalk");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        //[SerializeField] private Joystick horizontalJoystick;
        //[SerializeField] private Joystick verticalJoystick;
        private void FixedUpdate()
        {
            //var horizontal = horizontalJoystick.Horizontal * player.RotationSpeed * Time.fixedDeltaTime * player.Deceleration;
            //var vertical = verticalJoystick.Vertical * player.Sped * Time.fixedDeltaTime* player.Deceleration;

            if(Input.GetAxis("Horizontal") != 0|| Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool(IsWalk, true);
                
                var horizontal = Input.GetAxis("Horizontal") * player.RotationSpeed * Time.fixedDeltaTime * player.Deceleration;
                var vertical = Input.GetAxis("Vertical") * player.Sped * Time.fixedDeltaTime * player.Deceleration;
            
            
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    horizontal = player.Acceleration * horizontal;
                    vertical = player.Acceleration * vertical;
                    animator.SetBool(IsRunning, true);
                }
                else
                {
                    animator.SetBool(IsRunning, false);
                }
 
                transform.Translate(0f, 0f, vertical);
                transform.Rotate(0f, horizontal, 0f);
            }
            else
            {
                animator.SetBool(IsWalk, false);
            }
           
        }
    }
}