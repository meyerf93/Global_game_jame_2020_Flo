using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class RecipeManager
    {
        private List<BodyPart> _complete_parts_list = new List<BodyPart>();
       

        private List<BodyPart> _parts_to_discover;

        public void Reset()
        {
            _parts_to_discover.Clear();
            _parts_to_discover = _complete_parts_list;
        }

        public List<Recipe> RecipesList { get; set; }

        public BodyPart GetBodyPart(ResourceId res1, ResourceId res2, ResourceId res3)
        {
            return GetRecipe(res1, res2, res3).BodyPart;
        }

        private Recipe GetRecipe(ResourceId res1, ResourceId res2, ResourceId res3)
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

        private Recipe GenerateNewRecipe(ResourceId res1, ResourceId res2, ResourceId res3)
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
            var part = _parts_to_discover[0];
            _parts_to_discover.RemoveAt(0);
            return part;
        }
    }
}