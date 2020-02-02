using System.Collections;
using System.Collections.Generic;
using Logic.World;
using UnityEngine;
public class Creature : MonoBehaviour
{
    private List<BuildingType> _remaining_action = new List<BuildingType>();
    public Creature()
    {
    }

    protected void ExecuteNextAction()
    {
       
    }
        
    public void Die()
    {
        //animation ... 
        Destroy(gameObject);
    }
        
    protected void GoTo(Vector3 transformPosition)
    {
        
    }
        
}
