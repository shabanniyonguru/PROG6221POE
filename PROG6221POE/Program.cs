using System;

namespace RecipeApp
{
    class Ingredient
    {
        //variable thats gonna get the name of the ingredient
        public string Name { get; set; }

        //variable thats gonna get the quantity of the ingredient
        public double Quantity { get; set; }

        //variable thats gonna get the name of the ingredient
        public string Unit { get; set; }
    }

    class Recipe
    {
        private Ingredient[] originalIngredients;
        private string[] originalSteps;

        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        //method for displaying the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        //method thats gonna scale the original quantity of the ingredient
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        //method thats gonna reset the quantity
        public void ResetQuantities()
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity = originalIngredients[i].Quantity;
            }
        }

        //method that clears the data when the user chooses to do so
        public void ClearData()
        {
            Ingredients = null;
            Steps = null;
        }

        //method for the process of entering a new recipe
        public void EnterNewRecipe()
        {
            ClearData();
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());
            Ingredients = new Ingredient[ingredientCount];
            originalIngredients = new Ingredient[ingredientCount];

            //loop for the number of ingredients entered
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter the quantity of {name}:");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine($"Enter the unit of measurement for {name}:");
                string unit = Console.ReadLine();

                Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
                originalIngredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            
            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());
            Steps = new string[stepCount];
            originalSteps = new string[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                Steps[i] = Console.ReadLine();
                originalSteps[i] = Steps[i];
            }

            DisplayRecipe();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            bool running = true;
            while (running)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Enter new recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data and enter a new recipe");
                Console.WriteLine("6. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    //option 1
                    case 1:
                        recipe.EnterNewRecipe();
                        break;

                    case 2:
                        //option 2
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        //option 3
                        Console.WriteLine("Enter scale factor (0.5, 2, or 3):");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        //option 4
                        recipe.ResetQuantities();
                        recipe.DisplayRecipe();
                        break;
                    case 5:
                        //option 5
                        recipe.ClearData();
                        recipe.EnterNewRecipe();
                        break;
                    case 6:
                        //option 6
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}





