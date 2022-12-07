using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Practice_17
{
    public class program
    {
        static char[][] Map;
        static int[] playerSpawn;
        static int HP = 30;
        static int power = 5;
        static int steps = 0;
        static int Fightcount = 10;
        static string save = @"Save.txt";
        static char[] elements = new char[4] { '♥', '☻', '♦', ' ' };
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Загрузить сохранение или начать новую игру?\nНажмите L, чтобы загрузить сохранение\nНажмите N, чтобы начать новую игру\n");
                ConsoleKey answer = Console.ReadKey(true).Key;
                if(answer == ConsoleKey.N)
                {
                    Map = generateEverything(GenerateMap());
                    break;
                }
                else if(answer == ConsoleKey.L)
                {
                    if (File.Exists(save))
                    {
                        Map = Loadstate();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Нет сохранений");
                        Thread.Sleep(100);
                    }
                }
            }

            ConsoleKey action = ConsoleKey.Spacebar;
            while (action != ConsoleKey.Escape)
            {
                UpdateMap();
                if (HP <= 0 || Fightcount == 0) break;
                action = Console.ReadKey(true).Key;
                if (action == ConsoleKey.S)
                {
                    Savestate();
                }
                Move(Map, action);
            }
            Console.Clear();
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
            playerSpawn = new int[2] { (map.GetLength(0)-1)/2, (map[0].Length-1)/2 };
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
            byte bosscount = 0;
            while (bosscount < 1)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length - 2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻' || map[coordinates[0]][coordinates[1]] != '♥' || map[coordinates[0]][coordinates[1]] != '♦') && bosscount <= 1)
                {
                    map[coordinates[0]][coordinates[1]] = '☺';
                    bosscount++;
                }

            }
            byte portals = 0;
            while (portals < 2)
            {
                coordinates = new int[2] { rnd.Next(1, map.GetLength(0) - 2), rnd.Next(1, map[0].Length - 2) };
                if ((map[coordinates[0]][coordinates[1]] != 'P' || map[coordinates[0]][coordinates[1]] != '☻' || map[coordinates[0]][coordinates[1]] != '♥' || map[coordinates[0]][coordinates[1]] != '♦' || map[coordinates[0]][coordinates[1]] != '0' || map[coordinates[0]][coordinates[1]] != '0') && portals <= 2)
                {
                    map[coordinates[0]][coordinates[1]] = '0';
                    portals++;
                }
            }
            return map;
        }
        public static void UpdateMap()
        {
            Console.Clear();
            Console.WriteLine("Иcпользуйте кнопки стрелок для перемещения\nНажмите S для сохранения прогресса игры\nНажмите Esc для выхода из игры");
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map[i].Length; j++)
                {
                    if (i == playerSpawn[0] && j == playerSpawn[1])
                    {
                        Console.ForegroundColor= ConsoleColor.White;
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                            else Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        else
                        {
                            if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                            else Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        Console.Write('P');
                    }
                    else
                    {
                        switch (Map[i][j])
                        {
                            default:
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    Console.Write(Map[i][j]);
                                    break;
                                }
                            case '♥':
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(Map[i][j]);
                                    break;
                                };
                            case '☻':
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write(Map[i][j]);
                                    break;
                                };
                            case '█':
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(Map[i][j]);
                                    break;
                                };
                            case '♦':
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(Map[i][j]);
                                    break;
                                };
                            case '☺':
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.ForegroundColor = ConsoleColor.Red;
                                        else Console.ForegroundColor = ConsoleColor.DarkRed;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.ForegroundColor = ConsoleColor.Red;
                                        else Console.ForegroundColor = ConsoleColor.DarkRed;
                                    }
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Write(Map[i][j]);
                                    break;
                                };
                            case '0':
                                {
                                    if (i % 2 == 0)
                                    {
                                        if (j % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    else
                                    {
                                        if (j % 2 == 1) Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        else Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    }
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.Write(Map[i][j]);
                                    break;
                                };
                        }
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
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (space[playerSpawn[0]-1][playerSpawn[1]] != '█')
                        {
                            action(playerSpawn[0] - 1, playerSpawn[1]);
                            playerSpawn[0]--;
                            steps++;
                        }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (space[playerSpawn[0]][playerSpawn[1]-1] != '█')
                        {
                            action(playerSpawn[0], playerSpawn[1] - 1);
                            playerSpawn[1]--;
                            steps++;
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (space[playerSpawn[0]+1][playerSpawn[1]] != '█')
                        {
                            action(playerSpawn[0] + 1, playerSpawn[1]);
                            playerSpawn[0]++;
                            steps++;
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (space[playerSpawn[0]][playerSpawn[1]+1] != '█')
                        { 
                            action(playerSpawn[0], playerSpawn[1]+1);
                            playerSpawn[1]++;
                            steps++;
                        }
                        break;
                    }
            }
            return space;
        }
        public static void action(int a, int b)
        {
            if ('♥' == Map[a][b]) { 
                Healing();
                Map[a][b] = ' ';
            }
            else if ('☻' == Map[a][b])
            {
                Fight();
                Map[a][b] = ' ';
            }
            else if ('♦' == Map[a][b]) { 
                Buff();
                Map[a][b] = ' ';
            }
            else if ('☺' == Map[a][b])
            {
                Fight();
                Fight();
                Map[a][b] = ' ';
            }
            else if('0' == Map[a][b])
            {
                Teleport(a,b);
            }
        }
        public static void Fight()
        {
            int EnemyHP = 15;
            int EnemyPower = 5;
            while(EnemyHP > 0) {
                HP -= EnemyPower;
                EnemyHP -= power;
            }
            Fightcount -= 1;
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
        public static void Teleport(int a, int b)
        {
            Random rnd = new Random();
            for(int i=0; i < Map.GetLength(0); i++)
            {
                for(int j=0; j< Map[i].Length; j++)
                {
                    if (i!=a && j!=b && Map[i][j] =='0')
                    {
                        playerSpawn = new int[2] {i, j};
                    }
                }
            }
        }
        public static void Savestate()
        {
            FileStream file = new FileStream(save, FileMode.Create, FileAccess.ReadWrite);
            using (StreamWriter writer = new StreamWriter(file))
            { 
                    for (int i = 0; i < Map.GetLength(0); i++)
                    {
                        writer.WriteLine(new string(Map[i]));
                    }
                writer.Write($"{HP}\n{power}\n{steps}\n{Fightcount}\n{playerSpawn[0]} {playerSpawn[1]}");
            }
        }
        public static char[][] Loadstate() {
            char[][] map = GenerateMap();
            FileStream file = new FileStream(save, FileMode.Open, FileAccess.Read);
            string code;
            using(StreamReader reader = new StreamReader(file))
            {
                code=reader.ReadToEnd();
            }
            for(int i =0; i < map.GetLength(0);i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (code[(i + 1) * j] != '\n') { 
                        map[i][j] = code[(i + 1) * j];
                    code.Remove((i + 1) * j);
                    }
                    else {
                        code.Remove((i + 1) * j);
                        --j;
                    }
                }
                string coord = "";
                int count=0;
                while (code != "")
                {
                    foreach (char symb in code)
                    {
                        if (Char.IsDigit(symb))
                        {
                            coord += symb;
                            code.Remove(symb, 1);
                        }
                        if (symb == '\n')
                        {
                            code.Remove(symb, 1);
                            break;
                        }
                    }
                    switch (count){
                        case (0): {
                                HP = Convert.ToInt32(coord);
                                break;
                            }
                        case (1): {
                                power = Convert.ToInt32(coord);
                                break; 
                            }
                        case (2): {
                                steps = Convert.ToInt32(coord);
                                break; 
                            }
                        case (3): {
                                string[] place = coord.Split(' ');
                                for(int w = 0; w < place.Length; w++)
                                {
                                    playerSpawn[w] = Convert.ToInt32(place[w]);
                                }
                                break;
                            }
                    }
                    coord = "";
                    count++;
                }
            }
            return map;
        }
    }
}
/*
 * "♥" - аптечка
 * "P" - игрок
 * "☻" - враг
 * "█" - граница карты
 * "♦" - бонусы
 * "☺" - Босс, имеет силу двух врагов
 */