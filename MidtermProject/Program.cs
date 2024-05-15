using MidtermProject;
//menu items and names along with other values
List<Product> Products = new List<Product>() {

    new Product("Coffee","Drink",1.50m,"Black Coffee"),
    new Product("Croissant","Pastry", 2.00m,"Butter Croissant"),
    new Product("Brownie","Pastry",3.00m,"Chocolate Brownie"),
    new Product("Caprese Pesto","Sandwich",5.00m,"If you are dreaming of making a café-style sandwich at home then this is a good starting point for you. Fresh tomatoes, creamy mozzarella, spinach, simple seasoning, olive oil, and the balsamic glaze are all layered between two crusty ciabatta bread slices loaded with basil pesto!! I mean what’s not to love about this sandwich. It screams fresh flavors in every bite! Can it get easier than this??"),
    new Product("Lemon Frosted Cookie","Pastry",1.00m,"Glazed Lemon Cookies feature buttery, citrusy, soft, and perfectly sweet cookies topped with a lemon glaze. These are the best lemon cookies that come together quickly, contain simple ingredients, and don’t even require chilling."),
    new Product("Matcha Latte","Drink",6.00m,"Matcha latte is a beverage that originates from Japan. It's made from finely ground green tea leaves that are mixed with steamed milk. Unlike other teas, where you steep the leaves and strain them, matcha is made by whisking the powder into water or milk"),
    new Product("Boba Tea","Drink",4.00m,"Bubble Tea, also known as boba milk tea, is a cold, frothy drink made with a tea base shaken with flavors, sweeteners and/or milk with tapioca pearls at the base of the drink."),
    new Product("Buffalo Chicken Sandwich ","Sandwich",5.30m,"Blue cheese crumbles. Sliced juicy red onion. Boneless chicken breasts marinated in Buffalo Wings Sauce and blue cheese dressing. Nothing says \"eat me\" more than this spicy chicken sandwich recipe infused with hot buffalo flavor."),
    new Product("Milk Tea","Drink",4.00m,"Milk tea is a beverage made from tea and milk, and can be served hot or cold. It can include many different types of tea, milk, and spices. For example, milk tea can be made with black tea, bubble tea, or Thai milk tea. Milk tea can also include sweeteners like honey or sugar. The milk mellows and smooths out the tea's flavors, particularly some of the bitter notes found in black tea."),
    new Product("Milkshake","Drink",4.30m,"A milkshake is a sweet, cold beverage made by blending milk, ice cream, and flavorings. It can also be made with non-dairy products, such as plant milks, and dry ingredients like fruit, nuts, seeds, candy, or cookies. Milkshakes are traditionally served with whipped cream as topping in a tall glass with a straw. "),
    new Product("Grilled Cheese","Sandwich",4.30m,"Grilled cheese is a classic American sandwich made with buttered and toasted bread and cheese, and is sometimes known as a toasted sandwich or cheese toastie. The sandwich is made by heating slices of cheese between bread slices with butter or mayonnaise on a pan, griddle, or toaster until the bread browns and the cheese melts. Grilled cheese is inexpensive, simple to make, and has the gooey goodness of melted cheese and the crunchy warmth of toasted bread. \r\n\r\nWikipedia\r\nGrilled cheese - Wikipedia\r\nThe grilled cheese (sometimes known as a toasted sandwich or cheese toastie) is a hot cheese sandwich typically prepared by heating slices of cheese between slices of bread with a cooking fat such as butter or mayonnaise on a frying pan, griddle, or sandwich toaster, until the bread browns and the cheese melts.\r\n\r\nNatasha's Kitchen\r\nGrilled Cheese Sandwich Recipe (VIDEO) - Natasha's Kitchen\r\nAug 13, 2021 — What is Grilled Cheese? Grilled cheese is a classic American sandwich that has been around since 1920. It is a hot sandwich made with buttered and toasted bread and originally filled with American cheese, but is now commonly made with one or more different cheeses.\r\n\r\nwisconsincheese.com\r\nGrilled Cheese\r\nIt's got both the gooey goodness of melted cheese and the crunchy warmth of toasted bread. And a grilled cheese sandwich doesn't ask a lot of you – it's inexpensive and simple to make. It's easy-going, too.\r\nGenerative AI is experimental.\r\n"),
    new Product("Bagel Egg and Cheese Sandwich","Sandwich",5.00m,"An egg sandwich is a sandwich with some kind of cooked egg filling. Fried eggs, scrambled eggs, omelette, sliced boiled eggs and egg salad (a mix of chopped cooked egg and mustard and mayonnaise) are popular options."),


};

//next step is Display menu
// Calculate subtotal, sales tax, grand total
// Ask for payment type and process payment
// Display receipt
// Return to menu for new order

//static void Main(string[] args, List<Product> Products)
//{
//    while (true)
//    {
//        DisplayMenu(Products);

//        Console.WriteLine("Enter the number of the item you want to purchase (or type 'done' to complete the purchase):");
//        string input = Console.ReadLine();

//        if (input.ToLower() == "done")
//        {
//            CompletePurchase();
//            break;
//        }

//        if (int.TryParse(input, out int choice) && choice > 0 && choice <= Products.Count)
//        {
//            Console.Write("Enter the quantity: ");
//            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
//            {
//                Product product = Products[choice - 1];
//                decimal lineTotal = product.Price * quantity;
//                Console.WriteLine($"Line Total: ${lineTotal}");
//            }
//            else
//            {
//                Console.WriteLine("Invalid quantity.");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Invalid choice.");
//        }
//    }
//}

//static void CompletePurchase()
//{
//    throw new NotImplementedException();
//}

//static void DisplayMenu(List<Product> Products)
//{
//    Console.WriteLine("Menu:");
//    for (int i = 0; i < Products.Count; i++)
//    {
//        Console.WriteLine($"{i + 1}. {Products[i].Name} - ${Products[i].Price}");
//    }
//}   
      
          
 