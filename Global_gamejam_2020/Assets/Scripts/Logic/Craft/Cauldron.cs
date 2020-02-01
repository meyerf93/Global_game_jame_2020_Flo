using System.Collections.Generic;
using System.Collections;
using Logic.Craft;
using Logic.World;
using UnityEngine;
using UnityEngine.Serialization;

public class Cauldron : MonoBehaviour
{
    private RecipeManager _recipeManager;

    public int max_ingredient = 3;

    public Sprite leaf;
    public Sprite stone;
    public Sprite water;

    public SpriteRenderer first_case;
    public SpriteRenderer second_case;
    public SpriteRenderer third_case;


    public HeadPart CurrentHead { get; set; }
    public TorsoPart CurrentTorso { get; set; }
    public LegPart CurrentLeg { get; set; }

    public List<ResourceType> addedResources = new List<ResourceType>();

    private void Awake()
    {
        _recipeManager = gameObject.AddComponent<RecipeManager>();
        /*DepositResource(ResourceType.LEAF);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        CookBodyPart();
        
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        CookBodyPart();
        
        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);*/
        
        
    }
    public void DepositResource(ResourceType newIngredient)
    {
        if (addedResources.Count < max_ingredient)
        {
            addedResources.Add(newIngredient);
            display_ui_ressource(newIngredient,addedResources.Count);
        }
        
        Debug.Log("New resource added to caldron!");
    }
    void display_ui_ressource(ResourceType newIngredient, int element)
    {
        Sprite temp_sprite = first_case.sprite;
        switch (newIngredient)
        {
            case ResourceType.LEAF:
                temp_sprite = leaf;
                break;
            case ResourceType.STONE:
                temp_sprite = stone;
                break;
            case ResourceType.WATER:
                temp_sprite = water;
                break;
        }
        Color withe = new Color(255, 255, 255, 255);
        Color tranp = new Color(255, 255, 255, 0);

        switch (element)
        {
            case 1:
                first_case.sprite = temp_sprite;
                first_case.color = withe;
                break;
            case 2:
                second_case.sprite = temp_sprite;
                second_case.color = withe;
                break;
            case 3:
                third_case.sprite = temp_sprite;
                third_case.color = withe;
                break;
            default:
                first_case.color = tranp;
                second_case.color = tranp;
                third_case.color = tranp;
                break;
        }
    }

    void hide_ui_resosurce()
    {
        Color tranp = new Color(255, 255, 255, 0);
        first_case.color = tranp;
        second_case.color = tranp;
        third_case.color = tranp;
    }
    public void CookBodyPart()
    {
        Debug.Log("Try to cook part...");
        
        if (addedResources.Count < 3) return;
        var part = _recipeManager.GetBodyPart(
            addedResources[0],
            addedResources[1],
            addedResources[2]);
        addedResources.Clear();
        
        if (part.GetType() == typeof(HeadPart))
        {
            CurrentHead = (HeadPart)part;
        }
        else if (part.GetType() == typeof(TorsoPart))
        {
            CurrentTorso = (TorsoPart) part;
        }
        else if (part.GetType() == typeof(HeadPart))
        {
            CurrentLeg = (LegPart) part;
        }
        Debug.Log("New body part cooked!");
        hide_ui_resosurce();


    }

    public void AssembleAngel()
    {
        Debug.Log("Try to assemble angel...");
        if (CurrentHead == null || CurrentTorso == null || CurrentLeg == null) return;
        var newAngel = gameObject.AddComponent<Angel>();
        newAngel.SetBodyParts(CurrentHead, CurrentTorso, CurrentLeg);
        CurrentHead = null;
        CurrentLeg = null;
        CurrentTorso = null;

        // TODO Create new angel
        Debug.Log("New creature created and ready to fight the devil corruption!");
    }
         
}
