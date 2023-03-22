string folderPath = @"/Users/reti/projects/data/";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShoppingList = new List<string>();


if (File.Exists(filePath)) //tagastab kas true või false
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}
else
{
    File.Create(filePath).Close(); //file luuakse ja siis pannakse kinni
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}




static List<string> GetItemsFromUser()
{
    List<string> UserList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add/exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item: ");
            string userItem = Console.ReadLine();
            UserList.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return UserList; //andmete tegastamine vahemälusse
}


static void ShowItemsFromList(List<string> someList)
{
    Console.Clear(); //kustutab kõik tekstid konsoolist

    int listLenght = someList.Count;
    Console.WriteLine($"You have added {listLenght} items to your shopping list.");

    int i = 1; //nummerdab asjad ostukorvis
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}


