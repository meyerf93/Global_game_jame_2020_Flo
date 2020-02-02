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
    private SpriteRenderer renderer_img;

    private void Awake()
    {
        renderer_img = gameObject.GetComponent<SpriteRenderer>();
        actionsList = new List<BuildingType>();
    }

    public void change_ui()
    {
        renderer_img.sprite = ui;
    }
}
