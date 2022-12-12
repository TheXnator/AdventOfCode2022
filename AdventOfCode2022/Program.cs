static void Run() {
    /*Console.WriteLine(String.Format("Day 1 part 1: {0}", GetMostCalories()));
    Console.WriteLine(String.Format("Day 1 part 2: {0}", GetMostCalories(true)));

    Console.WriteLine(String.Format("Day 2 part 1: {0}", GetRockPaperScissors()));
    Console.WriteLine(String.Format("Day 2 part 2: {0}", GetRockPaperScissorsLosses()));

    Console.WriteLine(String.Format("Day 3 part 1: {0}", GetRucksackPriorities()));
    Console.WriteLine(String.Format("Day 3 part 2: {0}", GetBadgesPriorities()));*/

    Console.WriteLine(String.Format("Day 4 part 1: {0}", GetFullOverlapSections()));
    Console.WriteLine(String.Format("Day 4 part 2: {0}", GetOverlapSections()));
}

static int GetMostCalories(bool top3=false)
{
    string filename = "day1inputs.txt";
    int curval = 0;
    List<int> allvals = new List<int>();

    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents)
    {
        try {
            int lineval = Convert.ToInt32(line);
            curval = curval + lineval;
        } catch (Exception e) {
            allvals.Add(curval);
            curval = 0;
        }
    }

    allvals = allvals.OrderByDescending(c => c).ToList();

    return top3 ? (allvals[0] + allvals[1] + allvals[2]) : allvals[0];
}

static int GetRockPaperScissors() {
    string filename = "day2inputs.txt";
    int score = 0;

    Dictionary<char, char> wins = new Dictionary<char, char>();
    wins.Add('X', 'C');
    wins.Add('Y', 'A');
    wins.Add('Z', 'B');

    Dictionary<char, int> choiceScores = new Dictionary<char, int>();
    choiceScores.Add('A', 1);
    choiceScores.Add('B', 2);
    choiceScores.Add('C', 3);
    choiceScores.Add('X', 1);
    choiceScores.Add('Y', 2);
    choiceScores.Add('Z', 3);

    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents)
    {
        char opponentchoice = line[0];
        char ownchoice = line[2];

        // Apply win-loss score
        int winloss = (choiceScores[opponentchoice] == choiceScores[ownchoice] ? 3 : (wins[ownchoice] == opponentchoice ? 6 : 0));
        score = score + winloss;
        // Apply choice score
        int choiceScore = choiceScores[ownchoice];
        score = score + choiceScore;
    }

    return score;
}

static int GetRockPaperScissorsLosses()
{
    string filename = "day2inputs.txt";
    int score = 0;

    Dictionary<char, char> wins = new Dictionary<char, char>();
    wins.Add('A', 'B');
    wins.Add('B', 'C');
    wins.Add('C', 'A');

    Dictionary<char, char> losses = new Dictionary<char, char>();
    losses.Add('A', 'C');
    losses.Add('B', 'A');
    losses.Add('C', 'B');

    Dictionary<char, int> choiceScores = new Dictionary<char, int>();
    choiceScores.Add('A', 1);
    choiceScores.Add('B', 2);
    choiceScores.Add('C', 3);

    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents)
    {
        char opponentchoice = line[0];
        char desiredresult = line[2];

        char winchoice = wins[opponentchoice];
        char losschoice = losses[opponentchoice];
        char ownchoice = desiredresult == 'X' ? losschoice : (desiredresult == 'Y' ? opponentchoice : winchoice);

        // Apply win-loss score
        int winloss = (desiredresult == 'Y' ? 3 : (desiredresult  == 'Z' ? 6 : 0));
        score = score + winloss;
        // Apply choice score
        int choiceScore = choiceScores[ownchoice];
        score = score + choiceScore;
    }

    return score;
}

static int GetCharRucksackPriority(char c) {
    return ((int)c) < 97 ? (((int)c) - 64 + 26) : ((((int)c)) - 96);
}

static int GetRucksackPriorities() {
    string filename = "day3inputs.txt";

    int priorities = 0;

    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents) {
        string compartment1 = line.Substring(0, line.Length / 2);
        string compartment2 = line.Substring(line.Length / 2);

        foreach (char c in compartment1) {
            if (compartment2.Contains(c)) {
                int charval = GetCharRucksackPriority(c);
                priorities = priorities + charval;
                break;
            }
        }
    }

    return priorities;
}

static int GetBadgesPriorities() {
    string filename = "day3inputs.txt";
    int priorities = 0;

    string[] contents = File.ReadAllLines(filename);
    for (int x = 0; x < contents.Length; x = x + 3) {
        string bag1 = contents[x];
        string bag2 = contents[x+1];
        string bag3 = contents[x+2];

        foreach (char c in bag1) {
            if (bag2.Contains(c) && bag3.Contains(c)) {
                int charval = GetCharRucksackPriority(c);
                priorities = priorities + charval;
                break;
            }
        }
    }

    return priorities;
}

static int GetFullOverlapSections() {
    string filename = "day4inputs.txt";
    int num = 0;

    string[] contents = File.ReadAllLines(filename);
    for (int x = 0; x < contents.Length; x++) {
        string[] pairs = contents[x].Split(',');
        string[] firstnums = pairs[0].Split('-');
        string[] secondnums = pairs[1].Split('-');

        bool betweenfirst = Convert.ToInt32(firstnums[0]) >= Convert.ToInt32(secondnums[0]) && Convert.ToInt32(firstnums[1]) <= Convert.ToInt32(secondnums[1]);
        bool betweensecond = Convert.ToInt32(secondnums[0]) >= Convert.ToInt32(firstnums[0]) && Convert.ToInt32(secondnums[1]) <= Convert.ToInt32(firstnums[1]);

        if (betweenfirst || betweensecond)
        {
            num++;
        }
    }

    return num;
}

static int GetOverlapSections()
{
    string filename = "day4inputs.txt";
    int num = 0;

    string[] contents = File.ReadAllLines(filename);
    for (int x = 0; x < contents.Length; x++)
    {
        string[] pairs = contents[x].Split(',');
        string[] firstnums = pairs[0].Split('-');
        string[] secondnums = pairs[1].Split('-');

        bool betweenfirst = Convert.ToInt32(firstnums[0]) >= Convert.ToInt32(secondnums[0]) && Convert.ToInt32(firstnums[0]) <= Convert.ToInt32(secondnums[1]);
        bool betweensecond = Convert.ToInt32(secondnums[0]) >= Convert.ToInt32(firstnums[0]) && Convert.ToInt32(secondnums[0]) <= Convert.ToInt32(firstnums[1]);

        if (betweenfirst || betweensecond)
        {
            num++;
        }
    }

    return num;
}

Run();