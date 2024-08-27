string? choice;
string file = "courseData.txt";
do
{
    // ask user a question
    Console.WriteLine("1) Display saved SuperSmash Characters.");
    Console.WriteLine("2) Add a New SuperSmash Bro Character.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        if(File.Exists(file))
        {
            int count = 0;
            // TODO: read data from file
            StreamReader sr = new(file);
            while(!sr.EndOfStream)
            {
               string? line = sr.ReadLine();
               // convert string to an array
               string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split('|');
               // display array data
            Console.WriteLine("Id: {0}, Name: {1}, Relationship to Mario: {2}", arr[0], arr[1], arr[2]); 
               count += 1;
            }
            sr.Close();
            Console.WriteLine($"Number of saved Characters: {count}");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
    else if (choice == "2")
    {
        // TODO: create file from data
        StreamWriter sw = new(file, true);
        for (int i = 0; i < 7; i++)
        {
            // ask a question
            Console.WriteLine("Enter a SuperSmash Character (Y/N)?");
            // input the response
            string? resp = Console.ReadLine()?.ToUpper();
            // if the response is anything other than "Y", stop asking
            if (resp != "Y") { break; }
            // prompt for character id
            Console.WriteLine("Enter a character ID number.");
            // save the character id
            string? id = Console.ReadLine();
            // prompt for character name
            Console.WriteLine("Enter the character name.");
            // save the character name
            string? name = Console.ReadLine();
            // prompt for relation to mario
            Console.WriteLine("Enter Relation to Mario.");
            //save the relation
            string? relation = Console.ReadLine();

            sw.WriteLine("{0}|{1}|{2}", id, name, relation);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");
