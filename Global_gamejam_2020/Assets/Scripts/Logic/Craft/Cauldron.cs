using System.Collections.Generic;
using System.Collections;
using Logic.World;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    private RecipeManager _recipeManager;

    public int max_ingredient = 3;
        
    private HeadPart CurrentHead { get; set; }
    private TorsoPart CurrentTorso { get; set; }
    private LegPart CurrentLeg { get; set; }

    public List<ResourceType> AddedIngredients;

    private void Awake()
    {
        _recipeManager = new RecipeManager();

    }
    public void AddIngredient(ResourceType newIngredient)
    {
        if (AddedIngredients.Count < max_ingredient)
        {
            AddedIngredients.Add(newIngredient);
        }
    }

    public BodyPart CreateBodyPart()
    {
        if (AddedIngredients.Count < 3) return null;
        var part = _recipeManager.GetBodyPart(
            AddedIngredients[0],
            AddedIngredients[1],
            AddedIngredients[2]);
        AddedIngredients.Clear();
        return part;
    }
         
}
