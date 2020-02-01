using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Cauldron
    {
        private RecipeManager _recipeManager;
        
        public HeadPart CurrentHead { get; set; }
        public TorsoPart CurrentTorso { get; set; }
        public LegPart CurrentLeg { get; set; }

        public List<ResourceId> AddedIngredients;

        public Cauldron(RecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }

        public void AddIngredient(ResourceId newIngredient)
        {
            if (AddedIngredients.Count < 3)
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
}