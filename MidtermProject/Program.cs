using MidtermProject;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
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
//Main Code---------------------------------------------------------------------------------------------------------------          Add File IO
while (true)
{
    List<Receipt> receipt = new List<Receipt>();
    bool addMoreItems = true;
    decimal cost = 0;
    string answer = "";

    while (addMoreItems)
    {
        // ordering on menu
        DisplayMenu(Products);
        Console.WriteLine();

        Console.Write("Please type in the number of the item you would like or type 'quit' to end: ");
        answer = Console.ReadLine();
        int input = 0;
        if (answer.ToLower() == "quit") break;
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
        // quantity of item
        int quantity = 0;
        for (int i = 1; i <= Products.Count; i++)
        {
            if (i == input)
            {
                Console.Write("How many would you like? ");
                quantity = int.Parse(Console.ReadLine());

                while (quantity < 1)
                {
                    Console.Write("Please enter a valid quantity.");
                    quantity = int.Parse(Console.ReadLine());
                }

            }
        }
        // add items to receipt
        for (int i = 0; i < quantity; i++)
        {
            receipt.Add(new Receipt(Products[input - 1].Name, Products[input - 1].Price));
        }

        // cost of order
        cost += quantity * Products[input - 1].Price;
        Console.WriteLine($"Your total is {cost:C}");

        // adding more to cart
        while (true)
        {
            Console.Write("Would you like to order more? (y/n): ");
            string response = Console.ReadLine();

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
                Console.WriteLine("Invalid response.");
            }

        }


    }
    if (answer.ToLower() == "quit") break;
    decimal totalCost = cost * 1.06m;
    Console.WriteLine($"\nSubtotal: {cost:C}");
    Console.WriteLine($"Sales tax: 6%");
    Console.WriteLine($"Total: {totalCost:C}");

    string paymentForm = "";
    GetPaymentType(totalCost, out paymentForm);


    DisplayReceipt(receipt, cost, paymentForm);
}


//Methods----------------------------------------------------------------------------------------------
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

//display Receipt
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

// Ask for payment type and process payment 
static void GetPaymentType(decimal totalCost, out string paymentForm)
{
    paymentForm = "";

    while (true)
    {        
        Console.Write("\nWhat is your payment type? Cash, credit, or check? ");
        string paymentType = Console.ReadLine().ToLower().Trim();

        decimal cashPayment = 0;

        // cash payment type
        if (paymentType == "cash")
        {
            
            Console.Write("How much is the amount? ");
            while (decimal.TryParse(Console.ReadLine().Trim(), out cashPayment) == false || cashPayment.ToString().Length < 0)
            {
                Console.WriteLine("Invalid input.");
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

        // credit payment type
        if (paymentType == "credit")
        {
            paymentForm += $"Credit: {Math.Round(totalCost, 2):C}";
            string creditCardNumber = "";
            string expirationDate = ""; //int.Parse removes 0's at begining
            string CVVNumber = "";

            Console.Write("Enter credit card number: ");
            while (ValidateNum(out creditCardNumber) == false || creditCardNumber.Length < 16 || creditCardNumber.Length > 16)
            {
                Console.WriteLine("invalid input, try again...");
            }
            Console.WriteLine("Enter expiration date (MMYY): ");
            while (ValidateNum(out expirationDate) == false || expirationDate.ToString().Length < 4 || expirationDate.ToString().Length > 4)
            {
                Console.WriteLine("invalid input, try again...");
            }
            Console.Write("Enter CVV: ");
            while (ValidateNum(out CVVNumber) == false || CVVNumber.ToString().Length < 3 || CVVNumber.ToString().Length > 3)
            {
                Console.WriteLine("invalid input, try again...");
            }

            //PROCESS payment
            Console.WriteLine($"Processing credit card payment for {Math.Round(totalCost, 2):C} with card number {creditCardNumber.ToString().Substring(creditCardNumber.ToString().Length-4)}.");
            break;
        }

        //check payment
        if (paymentType == "check")
        {
            paymentForm += $"check: {Math.Round(totalCost, 2):C}";
            string checkNumber;
            Console.Write("Enter check number: ");
            while (ValidateNum(out checkNumber) == false || checkNumber.ToString().Length < 4 || checkNumber.ToString().Length > 4)
            {
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine($"Thank you for payment with check number: {checkNumber}");             
            break ;
        }   
    }
}

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
        Console.WriteLine("Invalid input.");
    }
}