using System;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Practice_17
{
    public class program
    {
        static char[][] Map;
        static int HP = 30;
        static int power = 5;
        static int steps = 0;
        static string save = @"Save.txt";
        static char[] elements = new char[4] { '♥', 'P', '☻', '♦' };
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Загрузить сохранение или начать новую игру?\nНажмите L, чтобы загрузить сохранение\nНажмите N, чтобы начать новую игру\n");
                ConsoleKey answer = Console.ReadKey(true).Key;
                if/*(Console.ReadLine()=="N")*/ (answer == ConsoleKey.N)
                {
                    Map = generateEverything(GenerateMap());
                    break;
                }
                else if/*(Console.ReadLine()=="L")*/ (answer == ConsoleKey.L)
                {
                    if (File.Exists(save))
                    {
                        Map = Loadstate(GenerateMap());
                    }
                    else
                    {
                        Console.WriteLine("Нет сохранений");
                        Thread.Sleep(100);
                    }
                }
            }

            ConsoleKey action = ConsoleKey.Spacebar;
            while (action != ConsoleKey.Escape) {
                UpdateMap();
                if (HP <= 0) break;
                action = Console.ReadKey(true).Key;
                if (action == ConsoleKey.S)
                {
                    Savestate();
                }
                Move(Map, action);
            }
            Console.WriteLine($"The end... Количество пройденных шагов:{steps}");
        }
        public static char[][] GenerateMap()
        {

            char[][] map = new char[27][];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                map[i] = new char[map.GetLength(0) * 2];
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                if (i == 0 || i == map.GetLength(0) - 1)
                {
                    for (int j = 0; j < map[i].Length; j++)
                    {
                        map[i][j] = '█';
                    }

                }
                else
                {
                    for (int j = 1; j < map[i].Length - 1; j++)
                        map[i][j] = ' ';
                    map[i][0] = '█';
                    map[i][map[i].Length - 1] = '█';
                }

            }
            return map;
        }
        public static char[][] generateEverything(char[][] map){
            Random rnd = new Random();
            map[(map.GetLength(0) - 1) / 2][(map[0].Length - 1) / 2] = 'P';//player's first place
            byte Enemycount = 0;
            int[] coordinates;
            while (Enemycount < 10)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length - 2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻') && Enemycount <= 10)
                {
                    map[coordinates[0]][coordinates[1]] = '☻';
                    Enemycount++;
                }

            }
            byte healingstuffcount = 0;
            while (healingstuffcount < 5)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length - 2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻' || map[coordinates[0]][coordinates[1]] != '♥') && healingstuffcount <= 5)
                {
                    map[coordinates[0]][coordinates[1]] = '♥';
                    healingstuffcount++;
                }
            }
            byte bufferscount = 0;
            while (bufferscount < 3)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length - 2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻' || map[coordinates[0]][coordinates[1]] != '♥' || map[coordinates[0]][coordinates[1]] != '♦') && bufferscount <= 3)
                {
                    map[coordinates[0]][coordinates[1]] = '♦';
                    bufferscount++;
                }

            }
            return map;
        }
        public static void UpdateMap()
        {
            Console.Clear();
            Console.WriteLine("ИСпользуйте кнопки стрелок для перемещения\nНажмите S для сохранения прогресса игры\nНажмите Esc для выхода из игры");
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map[i].Length; j++)
                {
                    switch (Map[i][j])
                    {
                        default: {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.Write(Map[i][j]);
                                break;
                            }
                        case '♥': {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(Map[i][j]);
                                break;
                            };
                        case 'P': {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(Map[i][j]);
                                break; 
                            };
                        case '☻': {
                                Console.BackgroundColor= ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(Map[i][j]);
                                break; 
                            };
                        case '█': {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(Map[i][j]);
                                break; 
                            };
                        case '♦': {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(Map[i][j]);
                                break;
                            };
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
            }
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"HP - {HP}/30 | Power - {power}");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static char[][] Move(char[][] space, ConsoleKey direction)
        {
            ConsoleKey[] actions= new ConsoleKey[4] {ConsoleKey.UpArrow, ConsoleKey.LeftArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow};
            //int[] playerPlace = new int[2];
            for(int i=0; i < space.GetLength(0); i++)
            {
                for(int j=0; j < space[i].Length; j++)
                {
                    if (space[i][j] == 'P')
                    {
                        
                        if((direction == actions[0]) && space[i - 1][j] != '█')
                        {
                            if (space[i - 1][j] == '♥') {
                                Healing();
                                space[i][j] = ' ';
                                space[i - 1][j] = 'P';
                            }
                            else if (space[i - 1][j] == '☻') {
                                Fight();
                                space[i][j] = ' ';
                                space[i - 1][j] = 'P';
                            }
                            else if (space[i - 1][j] == '♦') {
                                Buff();
                                space[i][j] = ' ';
                                space[i - 1][j] = 'P';
                            }
                            else if(space[i - 1][j] == ' ') {
                                space[i][j] = ' ';
                                space[i - 1][j] = 'P';
                            }
                            steps++;
                            Thread.Sleep(1);
                        }
                        else if ((direction == actions[1]) && space[i][j-1] != '█')
                        {
                            if (space[i][j - 1] == '♥') {
                                Healing();
                                space[i][j] = ' ';
                                space[i][j - 1] = 'P';
                            }
                            else if (space[i][j - 1] == '☻') {
                                Fight();
                                space[i][j] = ' ';
                                space[i][j - 1] = 'P';
                            }
                            else if (space[i][j - 1] == '♦')
                            {
                                Buff();
                                space[i][j] = ' ';
                                space[i][j - 1] = 'P';
                            }
                            else if (space[i][j - 1] == ' ') {
                                space[i][j] = ' ';
                                space[i][j-1] = 'P';
                            }
                            steps++;
                            Thread.Sleep(1);
                        }
                        else if ((direction == actions[2]) && space[i + 1][j] != '█')
                        {
                            if (space[i + 1][j] == '♥') {
                                Healing();
                                space[i][j] = ' ';
                                space[i + 1][j] = 'P';
                            }
                            else if (space[i + 1][j] == '☻') {
                                Fight();
                                space[i][j] = ' ';
                                space[i + 1][j] = 'P';
                            }
                            else if (space[i + 1][j] == '♦') {
                                Buff();
                                space[i][j] = ' ';
                                space[i + 1][j] = 'P';
                            }
                            else if (space[i + 1][j] == ' ') {
                                space[i][j] = ' ';
                                space[i+1][j] = 'P';
                            }
                            Thread.Sleep(1);
                            steps++;
                        }
                        else if ((direction == actions[3]) && space[i][j + 1] != '█')
                        {
                            if (space[i][j + 1] == '♥') {
                                Healing();
                                space[i][j] = ' ';
                                space[i][j + 1] = 'P';
                            }
                            else if (space[i][j + 1] == '☻') { 
                                Fight();
                                space[i][j] = ' ';
                                space[i][j + 1] = 'P';
                            }
                            else if (space[i][j+1] == '♦') {
                                Buff();
                                space[i][j] = ' ';
                                space[i][j + 1] = 'P';
                            }
                            else if (space[i][j+1] == ' ') {
                                space[i][j] = ' ';
                                space[i][j + 1] = 'P';
                            }
                            steps++;
                            Thread.Sleep(1);
                        }
                        break;
                        
                    }
                }
            }
            return space;
        }
        public static void Fight()
        {
            int EnemyHP = 15;
            int EnemyPower = 5;
            while(EnemyHP > 0) {
                HP -= EnemyPower;
                EnemyHP -= power;
            }
        }
        public static void Healing()
        {
            if (HP <= 5)
            {
                HP += 25;
            }
            else if (HP < 30)
            {
                HP = 30;
            }
        }
        public static void Buff()
        {
            power += 3;
        }
        public static void Savestate()
        {
            FileStream file = new FileStream(save, FileMode.Create, FileAccess.ReadWrite);
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (char elem in elements)
                {
                    for (int i = 0; i < Map.GetLength(0); i++)
                    {
                        for (int j = 0; j < Map[i].Length; j++)
                        {
                            if (elem == Map[i][j])
                            {
                                writer.Write($"{i} {j} ");
                            }
                        }
                    }
                    writer.Write('\n');
                }
                writer.Write($"{HP}\n{power}\n{steps}");
            }
            
        }
        public static char[][] Loadstate(char[][] map) {
            FileStream file = new FileStream(save, FileMode.Open, FileAccess.Read);
            int[][][] coordinaty = new int[elements.Length][][];
            string[] lines = new string[elements.Length];
            char[][] linesParts = new char[elements.Length][];
            for(int i=0; i<lines.Length;i++)
            {
                using(StreamReader reader = new StreamReader(save))
                {
                    lines[i] = reader.ReadLine();
                }
            }
            for(int i=0; i < linesParts.Length; i++)
            {
                linesParts[i]= new char[linesParts.Length];
                for (int j = 0; j < linesParts.Length; j++)
                {
                    linesParts[i][j] = lines[i][j];
                }
            }
            for(int i=0; i < coordinaty.GetLength(0); i++)
            {
                coordinaty[i] = new int[linesParts[i].Length][];
                for (int j = 0; j < coordinaty[i].GetLength(0); j++)
                {
                    int w = 0;
                    int d = 0;
                    coordinaty[i][j] = new int[linesParts[i].Length];
                    int[] place = new int[2];
                    string x = "";
                    for(int t = 0; t < linesParts[i].Length; t++)
                    {
                        if (linesParts[i][t] != ' ')
                        {
                            x += linesParts[i][t];
                            w++;
                        }
                        else if (w % 3 == 2)
                        {
                            coordinaty[i][d] = place;
                            place = new int[2];
                            w++;
                            d++;
                        }
                        else {
                            place[w % 2] = Convert.ToInt32(x);
                            w++;
                        }
                    }
                }
            }
            for (int i = 0; i < coordinaty[0].GetLength(0); i++) {
                if (coordinaty[0][i][0] != null && coordinaty[0][i][1] != null)
                {
                    Map[coordinaty[0][i][0]][coordinaty[0][i][1]] = '♥';
                }
                else break;
            }
            for (int i = 0; i < coordinaty[1].GetLength(0); i++) {
                if (coordinaty[1][i][0] != null && coordinaty[1][i][1] != null)
                {
                    Map[coordinaty[1][i][0]][coordinaty[0][i][1]] = 'P';
                }
                else break;
            }
            for (int i = 0; i < coordinaty[2].GetLength(0); i++) {
                if (coordinaty[1][i][0] != null && coordinaty[1][i][1] != null)
                {
                    Map[coordinaty[2][i][0]][coordinaty[0][i][1]] = '☻';
                }
                else break;
            }
            for (int i = 0; i < coordinaty[3].GetLength(0); i++) {
                if (coordinaty[1][i][0] != null && coordinaty[1][i][1] != null)
                {
                    Map[coordinaty[0][i][0]][coordinaty[0][i][1]] = '♦';
                }
                else break;
            }
            HP = Convert.ToInt32(lines[4]);
            power = Convert.ToInt32(lines[5]);
            steps = Convert.ToInt32(lines[6]);
            return map ;
        }
    }
}
/*
 * "♥" - аптечка
 * "P" - игрок
 * "☻" - враг
 * "█" - граница карты
 * "♦" - бонусы
 */