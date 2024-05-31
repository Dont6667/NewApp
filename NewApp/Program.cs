using System;

class Program
{
    static void Main(string[] args)
    {
        // Получаем данные пользователя
        var userData = GetUserData();

        // Выводим данные на экран
        DisplayUserData(userData);
    }

    static (string, string, int, bool, string[], string[]) GetUserData()
    {
        string firstName, lastName;
        int age;
        bool hasPet;
        int numPets;
        string[] petNames;
        int numFavoriteColors;
        string[] favoriteColors;

        // Вводим имя
        Console.Write("Введите ваше имя: ");
        firstName = Console.ReadLine();

        // Вводим фамилию
        Console.Write("Введите вашу фамилию: ");
        lastName = Console.ReadLine();

        // Вводим возраст с проверкой на корректность
        age = GetPositiveIntInput("Введите ваш возраст: ");

        // Спрашиваем о наличии питомца
        Console.Write("Есть ли у вас питомец? (да/нет): ");
        string petAnswer = Console.ReadLine().ToLower();
        hasPet = (petAnswer == "да");

        // Если есть питомец, запрашиваем количество питомцев и их клички
        if (hasPet)
        {
            numPets = GetPositiveIntInput("Введите количество питомцев: ");
            petNames = GetPetNames(numPets);
        }
        else
        {
            numPets = 0;
            petNames = new string[0];
        }

        // Запрашиваем количество любимых цветов и сами цвета
        numFavoriteColors = GetPositiveIntInput("Введите количество ваших любимых цветов: ");
        favoriteColors = GetFavoriteColors(numFavoriteColors);

        return (firstName, lastName, age, hasPet, petNames, favoriteColors);
    }

    static string[] GetPetNames(int numPets)
    {
        string[] petNames = new string[numPets];
        for (int i = 0; i < numPets; i++)
        {
            Console.Write($"Введите кличку питомца {i + 1}: ");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    static string[] GetFavoriteColors(int numColors)
    {
        string[] favoriteColors = new string[numColors];
        for (int i = 0; i < numColors; i++)
        {
            Console.Write($"Введите ваш любимый цвет {i + 1}: ");
            favoriteColors[i] = Console.ReadLine();
        }
        return favoriteColors;
    }

    static int GetPositiveIntInput(string message)
    {
        int result;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out result) || result <= 0); // Проверка на корректность ввода числа
        return result;
    }

    static void DisplayUserData((string, string, int, bool, string[], string[]) userData)
    {
        Console.WriteLine("\nВаши данные:");
        Console.WriteLine($"Имя: {userData.Item1}");
        Console.WriteLine($"Фамилия: {userData.Item2}");
        Console.WriteLine($"Возраст: {userData.Item3}");

        if (userData.Item4)
        {
            Console.WriteLine("У вас есть питомцы:");
            for (int i = 0; i < userData.Item5.Length; i++)
            {
                Console.WriteLine($"Питомец {i + 1}: {userData.Item5[i]}");
            }
        }
        else
        {
            Console.WriteLine("У вас нет питомцев.");
        }

        Console.WriteLine("Ваши любимые цвета:");
        for (int i = 0; i < userData.Item6.Length; i++)
        {
            Console.WriteLine($"Цвет {i + 1}: {userData.Item6[i]}");
        }
    }
}
