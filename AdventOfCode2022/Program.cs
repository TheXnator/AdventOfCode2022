static void Run() {
    Console.WriteLine(String.Format("Day 1 part 1: {0}", GetMostCalories()));
    Console.WriteLine(String.Format("Day 1 part 2: {0}", GetMostCalories(true)));

    Console.WriteLine(String.Format("Day 2 part 1: {0}", GetRockPaperScissors()));
    Console.WriteLine(String.Format("Day 2 part 2: {0}", GetRockPaperScissorsLosses()));
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

Run();