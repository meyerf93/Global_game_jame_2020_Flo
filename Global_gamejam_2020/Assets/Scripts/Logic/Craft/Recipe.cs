
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Recipe
    {
        public List<ResourceId> Ingredients { get; set; }
        public BodyPart BodyPart { get; set; }



        public Recipe(ResourceId res1, ResourceId res2, ResourceId res3, BodyPart part)
        {
            Ingredients = new List<ResourceId>(3) {res1, res2, res3};
            this.BodyPart = part;
        }

    }
}