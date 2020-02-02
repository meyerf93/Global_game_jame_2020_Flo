using System;
using System.Collections;
using System.Collections.Generic;
using Logic.Creatures;
using Logic.World;
using UnityEngine;

[Serializable]
public class BodyPart : MonoBehaviour
{
    public BodyPartType partType;
    public AngelType angelType;
    public List<BuildingType> actionsList;
    public Sprite ui;
    private void Awake()
    {
        actionsList = new List<BuildingType>();
    }

    
}
