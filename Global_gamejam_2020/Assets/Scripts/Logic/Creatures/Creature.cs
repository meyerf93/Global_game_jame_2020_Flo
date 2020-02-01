using System.Collections;
using System.Collections.Generic;
using Logic.World;
using UnityEngine;
public class Creature : MonoBehaviour
{
    private List<BuildingType> _remaining_action;
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
        
    public void GoTo(int X, int Y)
    {

    }
        
}
