using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Creature : MonoBehaviour
{
    private const int maximum_moves = 3;
    private int _remaining_action;
    public Creature()
    {
        _remaining_action = maximum_moves;
    }

    protected void MakeAction()
    {
        _remaining_action--;
        if (_remaining_action == 0)
        {
            Die();
        }
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
