using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    //[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    //[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    //[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    //[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    //[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_FacingDown = true;
    private Vector3 m_Velocity = Vector3.zero;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }


    public void MoveHorizontal(float move)
    {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                FlipHorizontal();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
            // ... flip the player.
                FlipHorizontal();
            }

    }

    public void MoveVertical(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, move * 10f);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        //May not need this
        /*
         * 
        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            FlipVertical();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            FlipVertical();
        }

        private void FlipVertical()
    {
        // Switch the way the player is labelled as facing.
        m_FacingDown = !m_FacingDown;

        // Multiply the player's y local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
         */

    }


    private void FlipHorizontal()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}