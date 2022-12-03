using System;
using System.Data;
using System.IO;
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
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Загрузить сохранение или начать новую игру?\nНажмите L, чтобы загрузить сохранение\nНажмите N, чтобы начать новую игру\n");
                ConsoleKey answer = Console.ReadKey(true).Key;
                if/*(Console.ReadLine()=="N")*/ (answer == ConsoleKey.N)
                {
                    Map = GenerateMap();
                    break;
                }
                else if/*(Console.ReadLine()=="L")*/ (answer == ConsoleKey.L)
                {
                    Console.WriteLine("сохранения на стадии разработки");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Нельзя прочитать клавишу, попытайтесь ещё");
                    Thread.Sleep(1000);
                }

            }
            
            
            ConsoleKey action = ConsoleKey.Spacebar;
            while (action != ConsoleKey.Escape) {
                UpdateMap();
                action = Console.ReadKey(true).Key;
                if(action == ConsoleKey.S) {
                    Savestate();
                }
                Move(Map, action);
                if(HP == 0)
                {
                    Console.WriteLine($"The end... Количество пройденных шагов:{steps}");
                }
            }
        }
        public static char[][] GenerateMap()
        {
            Random rnd = new Random();
            char[][] map = new char[27][];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                map[i] = new char[map.GetLength(0)*2];
            }
            for(int i = 0 ; i < map.GetLength(0); i++)
            {
                if (i == 0 || i == map.GetLength(0)-1)
                {
                    for (int j = 0; j < map[i].Length;j++)
                    {
                        map[i][j] = '█';
                    }
                    
                }
                else 
                {
                    for(int j = 1;j< map[i].Length-1;j++)
                    map[i][j] = ' ';
                    map[i][0] = '█';
                    map[i][map[i].Length-1] = '█';
                }
                
            }
            map[(map.GetLength(0) - 1) / 2][(map[0].Length - 1)/2] = 'P';//player's first place
            byte Enemycount = 0;
            int[] coordinates;
            while (Enemycount < 10)
            {
                coordinates = new int[2]{rnd.Next(1,map.GetLength(0)-2), rnd.Next(1, map[0].Length-2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻')&&Enemycount<=10)
                {
                    map[coordinates[0]][coordinates[1]] = '☻';
                    Enemycount++;
                }
                
            }
            byte healingstuffcount = 0;
            while (healingstuffcount < 5)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length-2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻'|| map[coordinates[0]][coordinates[1]] != '♥')&&healingstuffcount<=5)
                {
                    map[coordinates[0]][coordinates[1]] = '♥';
                    healingstuffcount++;
                }
            }
            byte bufferscount = 0;
            while (bufferscount <3)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length-2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻' || map[coordinates[0]][coordinates[1]] != '♥'|| map[coordinates[0]][coordinates[1]] != '♦')&&bufferscount<=3)
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
                    Console.Write(Map[i][j]);
                }
                Console.Write("\n");
            }
            Console.WriteLine($"HP - {HP}/30 | Power - {power}");
        }
        public static char[][] Move(char[][] space, ConsoleKey direction)
        {
            ConsoleKey[] actions= new ConsoleKey[4] {ConsoleKey.UpArrow, ConsoleKey.LeftArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow};
            //int[] playerPlace = new int[2];
            for(int i=0; i < space.Length; i++)
            {
                for(int j=0; j < space.Length; j++)
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
                        }
                        break;
                    }
                }
                Thread.Sleep(1);
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
            FileStream file = new FileStream(save, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamWriter writer = new StreamWriter(save))
            {
                writer.WriteLine($"{Map}\n{HP}\n{power}\n{steps}");
            }
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