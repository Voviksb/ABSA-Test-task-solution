namespace ABSA_Test_task
{
    public class TeamAllocation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide the number of working places in the new office and employees's sitting preferences");
            Console.WriteLine("Insert input in the following format: N;[1, 2, 4];[3, 4];[5];[1, 4, 5]:");

            string input = Console.ReadLine(); 
            Console.WriteLine(IsComfortableCombinationPossible(input));
        }

        public static string IsComfortableCombinationPossible(string input)
        {
            int placesCount;
            bool isNumber = int.TryParse(input[0].ToString(), out placesCount);

            if(!isNumber)
                throw new ArgumentException("Invalid places count inserted");

            if (placesCount < 1)
                throw new ArgumentException("Places count cannot be less than 1");

            input = input.Substring(1);
            string[] inputLists = input.Split(';', StringSplitOptions.RemoveEmptyEntries);


            List<List<int>> chosenPlacesLists = new List<List<int>>();
            foreach (string inputList in inputLists)
            {
                string[] inputChosenPlaces = inputList.Split(new char[] { ',', ' ', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> chosenPlaces = inputChosenPlaces.Select(int.Parse).ToList();
                chosenPlacesLists.Add(chosenPlaces);
            }

            if(chosenPlacesLists.Count > placesCount)
                throw new ArgumentException("Employees count cannot be more than places count");

            bool isPossible = AllocateTeam(chosenPlacesLists);
            string answer = isPossible ? "Yes" : "No";
            return answer;
        }

        private static bool AllocateTeam(List<List<int>> chosenPlacesLists)
        {
            for (int i = 0; i < chosenPlacesLists.Count; i++)
            {
                for (int j = 0; j < chosenPlacesLists[i].Count; j++)
                {
                    List<int> possibleCombination = new List<int>();
                    possibleCombination.Add(chosenPlacesLists[i][j]);

                    for (int k = 0; k < chosenPlacesLists.Count; k++)
                    {
                        if (k == i)
                            continue;
                        
                        for (int l = 0; l < chosenPlacesLists[k].Count; l++)
                        {
                            if (possibleCombination.Contains(chosenPlacesLists[k][l]))
                                continue;

                            possibleCombination.Add(chosenPlacesLists[k][l]);
                            break;
                        }
                    }
                    if (possibleCombination.Count == chosenPlacesLists.Count)
                        return true;
                }
            }
            return false;
        }
    }
}