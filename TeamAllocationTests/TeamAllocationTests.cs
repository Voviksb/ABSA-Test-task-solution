using ABSA_Test_task;

namespace TeamAllocationTests
{
    [TestClass]
    public class TeamAllocationTests
    {
        [TestMethod]
        public void NoPreferences()
        {
            // Arrange
            string input = "5;[1, 2, 3, 4, 5];[1, 2, 3, 4, 5];[1, 2, 3, 4, 5];[1, 2, 3, 4, 5];[1, 2, 3, 4, 5]";

            // Act
            string output = TeamAllocation.IsComfortableCombinationPossible(input);

            // Assert
            Assert.AreEqual("Yes", output);
        }

        [TestMethod]
        public void StrictChoicesNoOverlapping()
        {
            // Arrange
            string input = "5;[1];[2];[3];[4];[5]";

            // Act
            string output = TeamAllocation.IsComfortableCombinationPossible(input);

            // Assert
            Assert.AreEqual("Yes", output);
        }

        [TestMethod]
        public void StrictChoicesWithOverlapping()
        {
            // Arrange
            string input = "5;[1];[1];[3];[4];[5]";

            // Act
            string output = TeamAllocation.IsComfortableCombinationPossible(input);

            // Assert
            Assert.AreEqual("No", output);
        }

        [TestMethod]
        public void RandomizeChoices()
        {
            // Arrange
            var random = new Random();
            int n = random.Next(2, 11);

            int employeesCount = random.Next(2, n);
            List<List<int>> chosenPlacesLists = new List<List<int>>();
            for (int i = 0; i < employeesCount; i++)
            {
                int chosenPlacesCount = random.Next(1, n + 1);
                var chosenPlaces = new List<int>();
                for (int j = 0; j < chosenPlacesCount; j++)
                    chosenPlaces.Add(random.Next(1, n + 1));

                chosenPlacesLists.Add(chosenPlaces.Distinct().ToList());
            }

            string inputStart = $"{n};";

            var formattedLists = new List<string>();
            foreach (List<int> list in chosenPlacesLists)
            {
                string formattedList = "[";
                var numbers = string.Join(", ", list);
                formattedList += numbers + "]";
                formattedLists.Add(formattedList);
            }
            var inputEnd = string.Join(";", formattedLists);

            var input = inputStart + inputEnd;

            // Act
            string output = TeamAllocation.IsComfortableCombinationPossible(input);

            // Assert - Validate manually
            Console.WriteLine(input);
            Console.WriteLine(output);
        }
    }
}