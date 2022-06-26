Random random = new Random();

Dictionary<string,string> quizTerms = new Dictionary<string,string>();
// first string is key / term, second string is value / definition

//TestDictionary();

ReadStream();

//main loop
while (quizTerms.Count > 0)
{
    Console.Clear();
    Console.WriteLine(quizTerms.Count() + " terms left");

    int index;
    index = AskQuestion();

    CheckCorrect(index);
}

int AskQuestion()
{
    int index = random.Next(quizTerms.Count);

    string question = quizTerms.Keys.ElementAt(index);
    string answer = quizTerms.Values.ElementAt(index);

    Console.WriteLine("\nWhat is: " + question);
    Console.WriteLine("\n<press enter for answer>");
    Console.ReadLine();
    Console.WriteLine(answer +"\n");

    return index;
}


void CheckCorrect(int index)
{
    while (true)
    {
        Console.WriteLine("Did you get it correct? (y/n)");

        string correct = Console.ReadLine();

        if (correct == "y")
        {
            //Console.WriteLine("Correct");          
            // remove from array

            if (quizTerms.Count() == 1)
            {
                Console.WriteLine("\nWell done!");
                quizTerms.Remove(quizTerms.Keys.ElementAt(index));
                break;
            }
            else
            {
                quizTerms.Remove(quizTerms.Keys.ElementAt(index));
                break;
            }
        }
        else if (correct == "n")
        {
            Console.WriteLine("Wrong");

            //do not remove question from array
   
            break;
        }
        else if (correct == "q")
        {
            System.Environment.Exit(0);
        }


    }
}

void ReadStream()
{
    Console.WriteLine("1.abbreviations\n2.suffixes\n3.prefixes\n4.root");
    string topic = Console.ReadLine();
    string topicFile;
    topicFile = "rootTerms.txt";

    switch (topic)
    {
        case "1":
            topicFile= "abbrev.txt";
            break ;
        case "2":
            topicFile="suffixes.txt";
            break;
        case "3":
            topicFile="prefixes.txt";
            break;
        case "4":
            topicFile= "rootTerms.txt";
            break;
        default:
            topicFile = "rootTerms.txt";
            break;
    }

    StreamReader sr = new StreamReader("..\\..\\..\\"+topicFile);
    //StreamReader sr = new StreamReader("..\\..\\..\\rootTerms.txt");

    string term = sr.ReadLine();
    string definition = sr.ReadLine();
    string blank = sr.ReadLine();

    quizTerms.Add(term, definition);

    while ((term = sr.ReadLine()) != null)
    {
        definition = sr.ReadLine();
        blank = sr.ReadLine();
        quizTerms.Add(term, definition);
    }

    sr.Close();
}

void TestDictionary()
{
    quizTerms.Add("hyster-", "pertaining to uterus");
    quizTerms.Add("my(o)", "muscle");
}

