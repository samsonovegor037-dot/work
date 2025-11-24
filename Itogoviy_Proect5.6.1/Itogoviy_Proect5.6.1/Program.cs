namespace Itogoviy_Proect5._6._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var anketa = FillAnketa();
            DisplayAnketa(anketa);
        }
        public static string[] Pets(int count)
        {
            string[] Name = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите кличку питомца № " + (i + 1) + ":");
                Name[i] = Console.ReadLine();
            }
            return Name;
        }
        public static string[] Colors(int count)
        {
            string[] NameColors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите название цвета № " + (i + 1) + ":");
                NameColors[i] = Console.ReadLine();
            }
            return NameColors;
        }
        static bool CheckNum(string num, out int currentnum)
        {


            if (int.TryParse(num, out int intnum))
            {
                if (intnum > 0)
                {
                    currentnum = intnum;
                    return false;
                }
            }
            {
                currentnum = 0;
                return true;
            }
        }
        public static (string name, string LastName, bool pet, string[] PetName, int Age, int CountPet, int Color, string[] color) FillAnketa()
        {
            var anketa = (name: "", LastName: "", pet: false, PetName: new string[0], Age: 0, CountPet: 0, Color: 0, color: new string[0]);

            Console.WriteLine("Введите имя: ");
            anketa.name = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            anketa.LastName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами: ");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));
            anketa.Age = intage;

            Console.WriteLine("Есть ли у вас животные? Да или Нет");
            var rezult = Console.ReadLine();
            if (rezult == "Да")
            {
                anketa.pet = true;

                int InpCountPet;
                string countPetStr;
                do
                {
                    Console.WriteLine("Введите количество животных цифрами: ");
                    countPetStr = Console.ReadLine();
                } while (CheckNum(countPetStr, out InpCountPet));

                anketa.CountPet = InpCountPet;
                anketa.PetName = Pets(InpCountPet);
            }
            else
            {
                anketa.pet = false;
                anketa.PetName = new string[0];
            }

            int InpColor;
            string color;
            do
            {
                Console.WriteLine("Введите количество любимых цветов цифрами: ");
                color = Console.ReadLine();
            } while (CheckNum(color, out InpColor));

            anketa.Color = InpColor;
            anketa.color = Colors(InpColor);

            return anketa;
        }
        public static void DisplayAnketa(
        (string name, string LastName, bool pet, string[] PetName, int Age, int CountPet, int Color, string[] color) data)
        {
            Console.WriteLine();
            Console.WriteLine("Имя: " + data.name);
            Console.WriteLine("Фамилия: " + data.LastName);
            Console.WriteLine("Возраст: " + data.Age);
            Console.WriteLine("Питомцы: " + (data.pet ? "Да" : "Нет"));

            if (data.pet)
            {
                Console.WriteLine("Клички питомцев:");
                for (int i = 0; i < data.PetName.Length; i++)
                {
                    Console.WriteLine("  " + data.PetName[i]);
                }
            }

            Console.WriteLine("Любимые цвета:");
            for (int i = 0; i < data.color.Length; i++)
            {
                Console.WriteLine("  " + data.color[i]);
            }
        }
    }
}
