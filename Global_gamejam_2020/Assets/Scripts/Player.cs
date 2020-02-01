using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public Cauldron cauldron;
    public float moveSpeed;

    InputMaster Controls;
    private string conlision_tag_etected;

    Vector2 move;
    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_boxCollider2D;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = false;  // For determining which way the player is currently facing.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();
        Controls = new InputMaster();

        conlision_tag_etected = "None";
        Controls.Player.Take_ressource.performed += _ => Take_ressource();
        Controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        Controls.Player.Move.canceled += ctx => move = Vector2.zero;
        Controls.Player.Drop_chaudron.performed += _ => add_ingredient();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter in trigger " + collision.gameObject.tag);
        conlision_tag_etected = "None";

        if (collision.gameObject.tag == "Ressource")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("It's Ressource");
            conlision_tag_etected = "Ressource";
        }
        else if (collision.gameObject.tag == "cauldron_triger")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("It's cauldron_triger");
            //cauldron.AddedIngredients()
            conlision_tag_etected = "cauldron_triger";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        conlision_tag_etected = "None";
    }

    void Take_ressource()
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (conlision_tag_etected == "Ressource")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
             Debug.Log("Take ressource");
        }
    }

    void add_ingredient()
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (conlision_tag_etected == "cauldron_triger")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("add super amaizin ingredient");
        }
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



    public void Move(float move_x, float move_y)
    {
        //Debug.Log("make move x :" + move_x + " y : " + move_y);

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move_x, move_y);
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
