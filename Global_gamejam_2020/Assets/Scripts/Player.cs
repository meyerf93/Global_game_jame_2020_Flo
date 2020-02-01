using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    public float moveSpeed;

    InputMaster Controls;

    Vector2 move;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();



        Controls = new InputMaster();
        Controls.Player.Fire.performed += _ => shoot();
        Controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        Controls.Player.Move.canceled += ctx => move = Vector2.zero;

    }

    void shoot()
    {
        Debug.Log("fire");
    }


    private void Update()
    {
        Move(move.x, move.y);
    }

    private void OnEnable()
    {
        Controls.Player.Enable();
    }

    private void OnDisable()
    {
        Controls.Player.Disable();
    }







    public void Move(float move_x, float mvoe_y)
    {

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move_x, mvoe_y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity*moveSpeed, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move_x > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move_x < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
