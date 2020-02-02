using System.Collections.Generic;
using System.Collections;
using Logic.Craft;
using Logic.World;
using UnityEngine;
using UnityEngine.Serialization;
using Logic.Creatures;
public class Cauldron : MonoBehaviour
{
    public RecipeManager _recipeManager;
    public WorldMap worldManager;
    public int max_ingredient = 3;

    public GameObject help_angel;
    public GameObject help_body;
        
    public Sprite leaf;
    public Sprite stone;
    public Sprite water;

    public SpriteRenderer first_case;
    public SpriteRenderer second_case;
    public SpriteRenderer third_case;

    public SpriteRenderer head_case;
    public SpriteRenderer body_case;
    public SpriteRenderer foot_case;

    public Familly famillies_list;
    public List<ResourceType> addedResources = new List<ResourceType>();
    public List<BodyPart> addedBody = new List<BodyPart>();

    private void Awake()
    {
        _recipeManager = gameObject.AddComponent<RecipeManager>();
        DepositResource(ResourceType.LEAF);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        CookBodyPart();
        
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        CookBodyPart();
        
        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        
        
    }
    public void DepositResource(ResourceType newIngredient)
    {
        //Debug.Log("number of ressource added : " + addedResources.Count);
        //Debug.Log("max ingredient : " + max_ingredient);
        if (addedResources.Count < max_ingredient)
        {
            //Debug.Log("New resource added to caldron! : " + newIngredient);

            addedResources.Add(newIngredient);
            display_ui_ressource(newIngredient,addedResources.Count);
            display_help_cauldron();
        }
        
    }
    void display_ui_ressource(ResourceType newIngredient, int element)
    {
        //Debug.Log("new ingredient to display : " + newIngredient);
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
        
        if (addedResources.Count < 3) return;
        //Debug.Log("Try to cook part...");
        BodyPart part = _recipeManager.GetBodyPart(
            addedResources[0],
            addedResources[1],
            addedResources[2]);
        addedResources.Clear();
        found_good_part_ui(part);
        hide_ui_resosurce();

        addedBody.Add(part);

        Debug.Log("New "+part.partType+" cooked!");
                       
        display_part_body(part);
        hide_help_body();
        display_help_cauldron();
    }
    private void found_good_part_ui(BodyPart part)
    {
        Debug.Log("try to found the ui");
        foreach(Angel temp_angel in famillies_list.Angel)
        {
            Debug.Log("part angel type : " + part.angelType);
            Debug.Log("part temp_angel type : " + temp_angel._head.angelType);

            if (part.angelType == temp_angel._head.angelType)
            {
                Debug.Log("found the same angel type : "+ part.angelType);

                switch (part.partType)
                {

                    case BodyPartType.Head:
                        part.ui = temp_angel._head.ui;
                        return;
                    case BodyPartType.Body:
                        part.ui = temp_angel._torso.ui;
                        return;
                    case BodyPartType.Foot:
                        part.ui = temp_angel._legs.ui;
                        return;
                }
                //Debug.Log("found the same body part " + part.partType);

            }

        }
    }
    private void display_part_body(BodyPart bodypart)
    {
        Color temp = new Color(255, 255, 255, 255);
        //Debug.Log("body part angel type : " + bodypart.angelType);
        //Debug.Log("body part body type : " + bodypart.partType);

        //Debug.Log("ui sprite : " + bodypart.ui);
        switch (bodypart.partType)
        {
            case BodyPartType.Head:
                head_case.sprite = bodypart.ui;
                head_case.color = temp;
                break;
            case BodyPartType.Body:
                body_case.sprite = bodypart.ui;
                body_case.color = temp;
                break;
            case BodyPartType.Foot:
                foot_case.sprite = bodypart.ui;
                foot_case.color = temp;
                break;
        }
    }

    public void cheat_2()
    {
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.STONE);
        CookBodyPart();

        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.WATER);
        CookBodyPart();

        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.STONE);
    }
    public void cheat()
    {
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.WATER);
        CookBodyPart();

        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
        CookBodyPart();

        DepositResource(ResourceType.WATER);
        DepositResource(ResourceType.STONE);
        DepositResource(ResourceType.WATER);
    }

    private void hide_part_body()
    {
        Color temp = new Color(255, 255, 255, 0);

        head_case.color = temp;
        body_case.color = temp;
        foot_case.color = temp;

    }
    public void AssembleAngel()
    {
        //Debug.Log("Try to assemble angel...");
        if (addedBody.Count != 3) return;
        Angel newAngel = gameObject.AddComponent<Angel>();

        BodyPart CurrentHead = gameObject.AddComponent<BodyPart>();
        BodyPart CurrentTorso = gameObject.AddComponent<BodyPart>();
        BodyPart CurrentLeg = gameObject.AddComponent<BodyPart>();

        foreach (BodyPart part in addedBody)
        {
            if (part.partType == BodyPartType.Head) CurrentHead = part;
            if (part.partType == BodyPartType.Body) CurrentTorso = part;
            if (part.partType == BodyPartType.Foot) CurrentLeg = part;

        }

        newAngel.SetBodyParts(CurrentHead, CurrentTorso, CurrentLeg);
        worldManager.SpwanAngel(newAngel);

        //Debug.Log("create angel ");
        addedBody.Clear();
        foreach(BodyPart temp_part in gameObject.GetComponents<BodyPart>())
        {
            Destroy(temp_part);
        }

        Destroy(newAngel);
        hide_part_body();
        hide_help_angel();
    }

    public void display_help_cauldron()
    {
        if (addedResources.Count == max_ingredient)
        {
            display_help_body();
        }
        else
        {
            hide_help_body();
        }

        if(addedBody.Count == max_ingredient)
        {
            display_help_angel();
        }
        else
        {
            hide_help_angel();
        }
    }

    public void hide_help_cauldron()
    {
        hide_help_body();
        hide_help_angel();
    }

    private void hide_help_angel()
    {
        help_angel.SetActive(false);
    }
    private void display_help_angel()
    {
        help_angel.SetActive(true);
    }

    private void display_help_body()
    {
        help_body.SetActive(true);
    }
    private void hide_help_body()
    {
        help_body.SetActive(false);
    }


    public bool ressource_is_full()
    {
        return addedResources.Count == max_ingredient;
    }
         
}
