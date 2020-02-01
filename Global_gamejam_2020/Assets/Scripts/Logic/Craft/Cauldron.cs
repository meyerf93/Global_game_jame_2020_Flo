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
        
    private HeadPart CurrentHead { get; set; }
    private TorsoPart CurrentTorso { get; set; }
    private LegPart CurrentLeg { get; set; }

    public List<ResourceType> addedResources = new List<ResourceType>();

    private void Awake()
    {
        _recipeManager = gameObject.AddComponent<RecipeManager>();

    }
    public void DepositResource(ResourceType newIngredient)
    {
        if (addedResources.Count < max_ingredient)
        {
            addedResources.Add(newIngredient);
        }
        
        Debug.Log("New resource added to caldron!");
    }

    public void CookBodyPart()
    {
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
        
    }

    public void AssembleAngel()
    {
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
