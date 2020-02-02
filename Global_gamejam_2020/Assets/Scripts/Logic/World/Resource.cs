using UnityEngine;
using Logic.World;
using UnityEngine.UIElements;

public class Resource : MonoBehaviour
{
    public ResourceType type;
    public bool grounded = true;

    public SpriteRenderer help;

    public void display_help()
    {
        //Debug.Log("need help");
        help.color = new Color(255, 255, 255, 255);
    }
    
    public void hide_help()
    {
        //Debug.Log("don't need help");
        help.color = new Color(255, 255, 255, 0);
    }
    
}