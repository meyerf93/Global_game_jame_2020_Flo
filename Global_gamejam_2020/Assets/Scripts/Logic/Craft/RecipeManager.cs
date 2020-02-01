using System;
using System.Collections.Generic;
using Logic.Creatures.Parts;
using Logic.World;
using UnityEngine;

namespace Logic.Craft
{
    public class RecipeManager : MonoBehaviour
    {
        public BodyPartsGenerator _bodyPartsGenerator;

        public List<BodyPart> _partsToDiscover = new List<BodyPart>();

        private void Awake()
        {
            DiscoveredRecipes = new List<Recipe>();
            _bodyPartsGenerator = gameObject.AddComponent<BodyPartsGenerator>();
            Reset();
        }

        public void Reset()
        {
            _bodyPartsGenerator.Reset();
        }

        public List<Recipe> DiscoveredRecipes { get; set; }

        public BodyPart GetBodyPart(ResourceType res1, ResourceType res2, ResourceType res3)
        {
            return GetRecipe(res1, res2, res3).PartOfBody;
        }

        private Recipe GetRecipe(ResourceType res1, ResourceType res2, ResourceType res3)
        {
            // Cherche dans la liste des recettes découvertes
            foreach (var recipe in DiscoveredRecipes)
            {
                if (recipe.Resources[0] == res1 &&
                    recipe.Resources[1] == res2 &&
                    recipe.Resources[3] == res3)
                {
                    return recipe;
                }
            }
            // Si la recherche ne retourne rien, créer nouvelle recette
            return GenerateNewRecipe(res1, res2, res3);
        }

        private Recipe GenerateNewRecipe(ResourceType res1, ResourceType res2, ResourceType res3)
        {
            Debug.Log("New recipe discovered!!");
            var part = _bodyPartsGenerator.GetNextBodypart();
            var newRecipe = new Recipe(res1, res2, res3, part);
            DiscoveredRecipes.Add(newRecipe);
            return newRecipe;
        }
    }
}
