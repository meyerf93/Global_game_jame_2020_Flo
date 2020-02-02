using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using Logic.World;
public class Player : MonoBehaviour
{
    public Cauldron cauldron;
    public float moveSpeed;

    public GameObject prefab_leaf;
    public GameObject prefab_stone;
    public GameObject prefab_water;

    public GameObject worldMap;

    public Sprite leaf;
    public Sprite stone;
    public Sprite water;

    public GameObject display_ressource;


    InputMaster Controls;
    private string conlision_tag_etected;

    Vector2 move;
    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_boxCollider2D;
    private Vector3 m_Velocity = Vector3.zero;

    private GameObject colision_ressource;
    private bool m_FacingRight = false;  // For determining which way the player is currently facing.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();
        Controls = new InputMaster();

        conlision_tag_etected = "None";
        Controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        Controls.Player.Move.canceled += ctx => move = Vector2.zero;
        Controls.Player.Take_ressource.performed += _ => InteractWithResource();

        Controls.Player.Cook_part.performed += _ => CookBodyPart();
        Controls.Player.AssembleBodyParts.performed += _ => AssembleBodyParts();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Enter in trigger " + collision.gameObject.tag);
        conlision_tag_etected = "None";

        if (collision.gameObject.CompareTag("Ressource"))
        {
            //Controls.Player.Take_ressource.canceled += _ => add_ingredient(); ;
            //Controls.Player.Take_ressource.performed += _ => Take_ressource();

            //If the GameObject's name matches the one you suggest, output this message in the console
            //bug.Log("It's Ressource");
            colision_ressource = collision.gameObject;
            conlision_tag_etected = "Ressource";
        }
        else if (collision.gameObject.CompareTag("cauldron_triger"))
        {
            //Controls.Player.Take_ressource.canceled += _ => Take_ressource(); ;


            //If the GameObject has the same tag as specified, output this message in the console
            //bug.Log("It's cauldron_triger");
            //cauldron.AddedIngredients()
            conlision_tag_etected = "cauldron_triger";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        conlision_tag_etected = "None";
    }

    void InteractWithResource()
    {
        if (conlision_tag_etected == "Ressource")
        {
            Resource temp_ressource = display_ressource.GetComponent<Resource>();
            if (temp_ressource.grounded)
            {
                PickUpResource();
            }
        }
        else
        {
            DropResource();
        }
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        //Check for a match with the specified name on any GameObject that collides with your GameObject
    }

    private void DropResource()
    {
        if (conlision_tag_etected == "cauldron_triger")
        {
            DropResourceInCaldron();
        }
        else
        {
            DropResourceOnTheFloor();
        }
    }

    private void DropResourceOnTheFloor()
    {
        Resource temp_ressource = display_ressource.GetComponent<Resource>();
        SpriteRenderer temp_sprite = display_ressource.GetComponent<SpriteRenderer>();
        GameObject temp_gameobj;
        Color temp_color = new Color(255, 255, 255, 0);
        Transform parent = GetComponentInParent<Transform>();
        if (temp_ressource.grounded == false)
        {
            switch (temp_ressource.type)
            {
                case ResourceType.LEAF:
                    temp_gameobj = Instantiate(prefab_leaf,
                        new Vector3(parent.position.x + 1, parent.position.y, parent.position.z), Quaternion.identity);
                    break;
                case ResourceType.STONE:
                    temp_gameobj = Instantiate(prefab_stone,
                        new Vector3(parent.position.x + 1, parent.position.y, parent.position.z), Quaternion.identity);
                    break;
                case ResourceType.WATER:
                    temp_gameobj = Instantiate(prefab_water,
                        new Vector3(parent.position.x + 1, parent.position.y, parent.position.z), Quaternion.identity);
                    break;
            }

            temp_sprite.color = temp_color;
            temp_ressource.grounded = true;
        }
    }

    private void PickUpResource()
    {
        Resource temp_ressource = colision_ressource.GetComponent<Resource>();

        if (temp_ressource.grounded == true)
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Take ressource");
            display_prefab(temp_ressource.type);
            Destroy(colision_ressource);
        }
    }

    private void DropResourceInCaldron()
    {
        //If the GameObject's name matches the one you suggest, output this message in the console
        Debug.Log("add super amaizin ingredient");
        Resource temp_ressource = display_ressource.GetComponent<Resource>();

        cauldron.DepositResource(temp_ressource.type);

        SpriteRenderer temp_sprite = display_ressource.GetComponent<SpriteRenderer>();
        Color temp_color = new Color(255, 255, 255, 0);
        if (temp_ressource.grounded == false)
        {
            temp_sprite.color = temp_color;
            temp_ressource.grounded = true;
            //worldMap.SpawnNewResource(temp_ressource.type);
        }
    }

    
    void display_prefab(ResourceType ressource)
    {
        Resource temp_ressource;
        SpriteRenderer temp_sprite;
        Color temp_color = new Color(255, 255, 255, 255);
        temp_ressource = display_ressource.GetComponent<Resource>();
        temp_sprite = display_ressource.GetComponent<SpriteRenderer>();
        switch (ressource)
        {
            case ResourceType.LEAF:
                temp_ressource.type = ResourceType.LEAF;
                temp_sprite.sprite = leaf;
                break;
            case ResourceType.STONE:
                temp_ressource.type = ResourceType.STONE;
                temp_sprite.sprite = stone;
                break;
            case ResourceType.WATER:

                temp_ressource.type = ResourceType.WATER;
                temp_sprite.sprite = water;
                break;
        }

        temp_sprite.color = temp_color;
        temp_ressource.grounded = false;

    }

    void CookBodyPart()
    {
        if (conlision_tag_etected == "cauldron_triger")
        {
            cauldron.CookBodyPart();
        }
    }

    void AssembleBodyParts()
    {
        if (conlision_tag_etected == "cauldron_triger")
        {
            cauldron.AssembleAngel();
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
