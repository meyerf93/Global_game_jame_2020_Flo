using System;
using System.Collections;
using System.Collections.Generic;
using Logic.Creatures;
using Logic.World;
using UnityEngine;

public abstract class BodyPart : MonoBehaviour
{
    public string partType;
    public AngelType angelType;
    public List<BuildingType> actionsList;
    public Sprite ui;
    private void Awake()
    {
        
    }

    
}
