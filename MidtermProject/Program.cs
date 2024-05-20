using MidtermProject;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

string filepath = "../../../menu.txt";

// if file doesn't exist -----------------------------------------------------------------------
if (File.Exists(filepath) == false)
{
    StreamWriter writer = new StreamWriter(filepath);
    writer.WriteLine("Coffee|Drink|1.50|Black Coffee");
    writer.WriteLine("Croissant|Pastry|2|Butter Croissant");
    writer.WriteLine("Brownie|Pastry|3|Chocolate Brownie");
    writer.WriteLine("Caprese Pesto|Sandwich|5|If you are dreaming of making a café-style sandwich at home then this is a good starting point for you. Fresh tomatoes, creamy mozzarella, spinach, simple seasoning, olive oil, and the balsamic glaze are all layered between two crusty ciabatta bread slices loaded with basil pesto!! I mean what’s not to love about this sandwich. It screams fresh flavors in every bite! Can it get easier than this??");
    writer.WriteLine("Lemon Frosted Cookie|Pastry|1|Glazed Lemon Cookies feature buttery, citrusy, soft, and perfectly sweet cookies topped with a lemon glaze. These are the best lemon cookies that come together quickly, contain simple ingredients, and don’t even require chilling.");
    writer.WriteLine("Matcha Latte|Drink|6|Matcha latte is a beverage that originates from Japan. It's made from finely ground green tea leaves that are mixed with steamed milk. Unlike other teas, where you steep the leaves and strain them, matcha is made by whisking the powder into water or milk");
    writer.WriteLine("Boba Tea|Drink|4|Bubble Tea, also known as boba milk tea, is a cold, frothy drink made with a tea base shaken with flavors, sweeteners and/or milk with tapioca pearls at the base of the drink.");
    writer.WriteLine("Buffalo Chicken Sandwich|Sandwich|5|Blue cheese crumbles. Sliced juicy red onion. Boneless chicken breasts marinated in Buffalo Wings Sauce and blue cheese dressing. Nothing says \"eat me\" more than this spicy chicken sandwich recipe infused with hot buffalo flavor.");
    writer.WriteLine("Milk Tea|Drink|4|Milk tea is a beverage made from tea and milk, and can be served hot or cold. It can include many different types of tea, milk, and spices. For example, milk tea can be made with black tea, bubble tea, or Thai milk tea. Milk tea can also include sweeteners like honey or sugar. The milk mellows and smooths out the tea's flavors, particularly some of the bitter notes found in black tea.");
    writer.WriteLine("Milkshake|Drink|4|A milkshake is a sweet, cold beverage made by blending milk, ice cream, and flavorings. It can also be made with non-dairy products, such as plant milks, and dry ingredients like fruit, nuts, seeds, candy, or cookies. Milkshakes are traditionally served with whipped cream as topping in a tall glass with a straw. ");
    writer.WriteLine("Grilled Cheese|Sandwich|4|Grilled cheese is a classic American sandwich made with buttered and toasted bread and cheese");
    writer.WriteLine("Bagel Egg and Cheese Sandwich|Sandwich|5|An egg sandwich is a sandwich with some kind of cooked egg filling. Fried eggs, scrambled eggs, omelette, sliced boiled eggs and egg salad (a mix of chopped cooked egg and mustard and mayonnaise) are popular options.");
    writer.Close();
}


// reading file and listing -----------------------------------------------------------------------
List<Product> Products = new List<Product>();
StreamReader reader = new StreamReader(filepath);

while (true)
{
    string line = reader.ReadLine();
    if (line == null) break; 
    else
    {
        string[] parts = line.Split('|');
        Product p = new Product(parts[0], parts[1], decimal.Parse(parts[2]), parts[3]);
    Products.Add(p);
    }
}
reader.Close();


//Main Code==============================================================================================================================================================
while (true)
{
    List<Receipt> receipt = new List<Receipt>();
    bool addMoreItems = true;
    decimal cost = 0;
    string answer = "";

    while (addMoreItems)
    {
        // ordering on menu -----------------------------------------------------------------------
        DisplayMenu(Products);
        Console.WriteLine();

        Console.Write("Please type in the number of the item you would like, type 'add' to add a new item to the menu, or type 'quit' to end: ");
        answer = Console.ReadLine().Trim().ToLower();
        int input = 0;

        // add new item -----------------------------------------------------------------------
        if (answer == "add")
        {
            Console.Write("Enter Name of Item: ");
            string item = Console.ReadLine().Trim();

            Console.Write("Enter Category of Item: ");
            string category = Console.ReadLine().Trim();

            Console.Write("Enter Price of Item: ");
            decimal price = decimal.Parse(Console.ReadLine().Trim());

            Console.Write("Enter Description of Item: ");
            string description = Console.ReadLine().Trim();

            Product newProduct = new Product(item, category, price, description);
            Products.Add(newProduct);

            Console.WriteLine("Thank you for adding your product to our menu!");

            continue;
        }

        // quit to end -----------------------------------------------------------------------
        if (answer == "quit") break;

        // choosing item on menu -----------------------------------------------------------------------
        while (true)
        {
            try
            {
                input = int.Parse(answer);
                if (input < 1 || input > Products.Count)
                {
                    Console.Write("Invalid input, please choose something on the menu. ");
                    continue;
                }
                break;
            }
            catch
            {
                Console.Write("Invalid input, please choose something on the menu. ");
                answer = Console.ReadLine();
            }
        }

        // quantity of item -----------------------------------------------------------------------
        int quantity = 0;
        for (int i = 1; i <= Products.Count; i++)
        {
            if (i == input)
            {
                Console.Write("How many would you like? ");
                quantity = int.Parse(Console.ReadLine());

                while (quantity < 1)
                {
                    Console.Write("Please enter a valid quantity. ");
                    quantity = int.Parse(Console.ReadLine());
                }
            }
        }

        // add items to receipt -----------------------------------------------------------------------
        for (int i = 0; i < quantity; i++)
        {
            receipt.Add(new Receipt(Products[input - 1].Name, Products[input - 1].Price));
        }

        // cost of order -----------------------------------------------------------------------
        cost += quantity * Products[input - 1].Price;
        Console.WriteLine($"Your total is {cost:C}");

        // adding more to cart -----------------------------------------------------------------------
        while (true)
        {
            Console.Write("Would you like to order more? (y/n): ");
            string response = Console.ReadLine().ToLower().Trim();

            if (response == "y")
            {
                Console.WriteLine();
                break;
            }
            else if (response == "n")
            {
                addMoreItems = false;
                break;
            }
            else
            {
                Console.Write("Invalid response. ");
            }
        }
    }

    // quit program -----------------------------------------------------------------------
    if (answer.ToLower() == "quit") break;

    // caculate cost -----------------------------------------------------------------------
    decimal totalCost = cost * 1.06m;
    Console.WriteLine($"\nSubtotal: {cost:C}");
    Console.WriteLine($"Sales tax: 6%");
    Console.WriteLine($"Total: {totalCost:C}");

    // finishing payment and display receipt -----------------------------------------------------------------------
    string paymentForm = "";
    GetPaymentType(totalCost, out paymentForm);

    DisplayReceipt(receipt, cost, paymentForm);
}

// update menu file -----------------------------------------------------------------------
StreamWriter writer1 = new StreamWriter(filepath);
foreach (Product p in Products)
{
    writer1.WriteLine($"{p.Name}|{p.Categories}|{p.Price}|{p.Description}");
}
writer1.Close();

//Methods==============================================================================================================================================================
//display menu
static void DisplayMenu(List<Product> Products)
{
    Console.WriteLine(" _____________________________________________");
    Console.WriteLine("|\t    Mythic Matcha Cafe Menu           |");
    Console.WriteLine("|_____________________________________________|");
    int count = 1;
    foreach (Product p in Products)
    {
        Console.WriteLine($"|{count,2}. {p.Name,-35} {p.Price,5:c}|"); 
        count++;
    }
    Console.WriteLine("|_____________________________________________|");

}

//display Receipt ----------------------------------------------------------------------------------------------------------------------------
static void DisplayReceipt(List<Receipt> receipt, decimal cost, string paymentForm)
{
    Console.WriteLine(" _________________________________________");
    Console.WriteLine("|\t          Receipt                 |");
    Console.WriteLine("|_________________________________________|");

    foreach (Receipt r in receipt)
    {
        Console.WriteLine($"|{r.Name,-35} {r.Price,5:c}|");

    }
    Console.WriteLine("|_________________________________________|");

    Console.WriteLine($"\nSubtotal: {cost:C}");
    Console.WriteLine($"Sales tax: 6%");
    Console.WriteLine($"Total: {cost * 1.06m:C}");
    Console.WriteLine($"\nPayment method {paymentForm}");
    Console.WriteLine("\nTransaction complete.\n");
}

// Ask for payment type and process payment -------------------------------------------------------------------------------------------------
static void GetPaymentType(decimal totalCost, out string paymentForm) 
{
    paymentForm = "";

    while (true)
    {        
        Console.Write("\nWhat is your payment type - cash, credit, or check? ");
        string paymentType = Console.ReadLine().ToLower().Trim();

        decimal cashPayment = 0;

        // cash payment type -----------------------------------------------------------------------
        if (paymentType == "cash")
        {
            
            Console.Write("How much is the amount? ");
            while (decimal.TryParse(Console.ReadLine().Trim(), out cashPayment) == false || cashPayment.ToString().Length < 0)
            {
                Console.Write("Invalid input. ");
            }

            decimal cashBack = totalCost - cashPayment;

            paymentForm = $" \nCash: {cashPayment:C} \n";

            if (cashBack > 0)
            {
                Console.WriteLine($"Total: {cashBack:C}");
                totalCost = cashBack;
                continue;
            }
            else if (cashBack < 0)
            {
                Console.WriteLine($" Here is your change: {-cashBack:C}");
                break;
            }
            else if (cashBack == 0)
            {
                Console.WriteLine("Thank you for your purchase! Come back soon!");
                break;
            }

        }

        // credit payment type -----------------------------------------------------------------
        if (paymentType == "credit")
        {
            paymentForm += $"Credit: {Math.Round(totalCost, 2):C}";
            string creditCardNumber = "";
            string expirationDate = ""; //int.Parse removes 0's at begining
            string CVVNumber = "";

            Console.Write("Enter credit card number: ");
            while (ValidateNum(out creditCardNumber) == false || creditCardNumber.Length < 16 || creditCardNumber.Length > 16 || long.Parse(creditCardNumber) == 0)
            {
                Console.Write("Invalid input. ");
            }
            Console.Write("Enter expiration date (MMYY): ");
            while (ValidateNum(out expirationDate) == false || expirationDate.Length < 4 || expirationDate.Length > 4 || int.Parse(expirationDate) < 124)
            {
                Console.Write("Invalid input. ");
            }
            Console.Write("Enter CVV: ");
            while (ValidateNum(out CVVNumber) == false || CVVNumber.Length < 3 || CVVNumber.Length > 4)
            {
                Console.Write("Invalid input. ");
            }

            Console.WriteLine($"Processing credit card payment for {Math.Round(totalCost, 2):C} with card number {creditCardNumber.Substring(creditCardNumber.Length-4)}.");
            break;
        }

        //check payment ---------------------------------------------------------------------------
        if (paymentType == "check")
        {
            paymentForm += $"check: {Math.Round(totalCost, 2):C}";
            string checkNumber;
            Console.Write("Enter check number: ");
            while (ValidateNum(out checkNumber) == false || checkNumber.Length < 4 || checkNumber.Length > 4)
            {
                Console.Write("Invalid input. ");
            }
            Console.WriteLine($"Thank you for payment with check number: {checkNumber}");             
            break ;
        }   
    }
}
// credit number validation---------------------------------------------------------------------------------------------------------
static bool ValidateNum(out string num) 
{
    long x = 0;
    while (true)
    {
        string input = Console.ReadLine();
         if (long.TryParse(input, out x))
         {
            num = input;
            return true;
         }
        Console.Write("Invalid input. ");
    }
}