using System.Collections;
using System.Collections.Generic;
using Logic.World;


public class RecipeManager
{
    private List<BodyPart> _completePartsList = new List<BodyPart>();
       
    private void Initate_list_part()
    {
        //add x part
    }

    private List<BodyPart> _partsToDiscover = new List<BodyPart>();

    public void Reset()
    {
        _partsToDiscover.Clear();
        _partsToDiscover = _completePartsList;
    }

    public List<Recipe> RecipesList { get; set; }

    public BodyPart GetBodyPart(ResourceType res1, ResourceType res2, ResourceType res3)
    {
        return GetRecipe(res1, res2, res3).BodyPart;
    }

    private Recipe GetRecipe(ResourceType res1, ResourceType res2, ResourceType res3)
    {
        // Cherche et retourne la recette correspondant aux resources.
        // Si la recette n'existe pas, elle est créée et ajoutée à la liste des recettes connues.
             
        foreach (var recipe in RecipesList)
        {
            if (recipe.Ingredients[0] == res1 &&
                recipe.Ingredients[1] == res2 &&
                recipe.Ingredients[3] == res3)
            {
                return recipe;
            }
        }
        return GenerateNewRecipe(res1, res2, res3);
    }

    private Recipe GenerateNewRecipe(ResourceType res1, ResourceType res2, ResourceType res3)
    {
        var part = GetNextPartForRecipe();
        var newRecipe = new Recipe(res1, res2, res3, part);
        RecipesList.Add(newRecipe);
        return newRecipe;
    }

    private BodyPart GetNextPartForRecipe()
    {
        // Retourne la partie de corps correspondant à la nouvelle 
        // recette découverte.
        var part = _partsToDiscover[0];
        _partsToDiscover.RemoveAt(0);
        return part;
    }
}
