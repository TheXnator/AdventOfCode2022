static void Run() {
    Console.WriteLine(String.Format("Day 1 part 1: {0}", GetMostCalories()));
}

static int GetMostCalories()
{
    string filename = "day1inputs.txt";
    int maxval = 0;
    int curval = 0;

    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents)
    {
        try {
            int lineval = Convert.ToInt32(line);
            curval = curval + lineval;
        } catch (Exception e) {
            if (curval > maxval) {
                maxval = curval;
            }

            curval = 0;
        }
    }

    return maxval;
}

Run();