using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
using Game.BL;
using System.Xml.Linq;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Enemy> bullet = new List<Enemy>();
            List<Enemy1> bullet2 = new List<Enemy1>();
            // <------------------------- Maze Data ------------------------->
            string maze_path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 01\\PD\\Game\\storeMaze.txt";
            char[,] maze = new char[43, 99];
            // <------------------------- Player Character ------------------------->
            char box = (char)212;
            char box1 = (char)16;
            char box2 = (char)17;
            char[] Bob1 = { box2, box, box, box1 };
            char[] Bob2 = { ' ', '/', '\\', ' ' };
            // <------------------------- Enemy Character ------------------------->
            char Box1 = (char)16;
            char Box2 = (char)17;
            char[] Enemy1 = { '{', '*', 'v', '*', '}' };
            char[] Enemy2 = { Box2, '|', 'V', '|', Box1 };
            // Enemy Character2
            char Box = (char)147;
            char Box3 = (char)31;
            char[] Enemy2_1 = { Box1, 'O', '|', 'O', Box2 };
            char[] Enemy2_2 = { ' ', Box3, Box3, Box3, ' ' };
            // Enemy Character3
            char[] Enemy3_1 = { '{', '*', 'v', '*', '}' };
            char[] Enemy3_2 = { Box2, '|', 'V', '|', Box1 };
            // Player Coordinates
            int BobX = 2;
            int BobY = 1;
            // Enemy Coordinates1
            int EnemyX = 93;
            int EnemyY = 1;
            //// Enemy Coordinates2
            int Enemy2_X = 1;
            int Enemy2_Y = 13;
            //// Enemy Coordinates3
            int Enemy3_X = 1;
            int Enemy3_Y = 25;
            int enemy2x = 1;
            int enemy2y = 13;
            string direction = "right";
            int score = 0;
            // Enemy Health
            int Enemy1_health = 100;
            int Enemy2_health = 100;
            int Enemy3_health = 100;
            // Player Bullets
            int[] bullet2X = new int[100];
            int[] bullet2Y = new int[100];
            bool[] isBulletActive1 = new bool[100];
            bool[] isBulletActive2 = new bool[100];
            int bulletCount1 = 0;
            int bulletCount2 = 0;

            bool gameRunning = true;
            readMaze(maze_path, maze);

           
            int choice = 0;
            choice = frontPage();
            if (choice == 1)
            {
                Console.Clear();
                printMaze(maze);
                printBob(Bob1, Bob2, ref BobX, ref BobY);
                printEnemy(Enemy1, Enemy2, ref EnemyX, ref EnemyY);
                printEnemy2(ref enemy2x, ref enemy2y, Enemy2_1, Enemy2_2);
                printEnemy3(ref Enemy3_X, ref Enemy3_Y, Enemy3_1, Enemy3_2);
                printScore(ref score);
                Print_Enemy1_Health(ref Enemy1_health);
                Print_Enemy2_Health(ref Enemy2_health);
                Print_Enemy3_Health(ref Enemy3_health);
                while (gameRunning)
                {
                    Thread.Sleep(90);
                    printScore(ref score);
                    Print_Enemy1_Health(ref Enemy1_health);
                    Print_Enemy2_Health(ref Enemy2_health);
                    Print_Enemy3_Health(ref Enemy3_health);
                    if (Keyboard.IsKeyPressed(Key.LeftArrow))
                    {

                        moveBobLeft(Bob1, Bob2, ref BobX, ref BobY, maze);
                    }
                    else if (Keyboard.IsKeyPressed(Key.RightArrow))
                    {

                        moveBobRight(Bob1, Bob2, ref BobX, ref BobY, maze);
                    }
                    else if (Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        moveBobUp(Bob1, Bob2, ref BobX, ref BobY, maze);
                    }
                    else if (Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        moveBobDown(Bob1, Bob2, ref BobX, ref BobY, maze);
                    }
                    else if (Keyboard.IsKeyPressed(Key.Space))
                    {
                        generateBulletRight(isBulletActive1, bullet, ref bulletCount1, ref BobX, ref BobY);
                    }
                    else if (Keyboard.IsKeyPressed(Key.Control))
                    {
                        generateBulletLeft(isBulletActive2, bullet2, ref bulletCount2, ref BobX, ref BobY);
                    }
                    enemymove2(ref  direction, ref  enemy2x, ref  enemy2y,  maze,  Enemy2_1, Enemy2_2);
                    moveBulletRight(isBulletActive1,bullet, ref bulletCount1, maze);
                    moveBulletLeft(isBulletActive2,bullet2, ref  bulletCount2,maze);
                    bulletCollisionWithEnemy1(ref Enemy1_health, ref score, bullet, ref bulletCount1, ref EnemyX, isBulletActive1);
                    bulletCollisionWithEnemy2(ref  Enemy3_health, ref  score,bullet2, ref  bulletCount2, ref Enemy3_X,  isBulletActive2);
                    if (Keyboard.IsKeyPressed(Key.Escape))
                    {
                        Console.Clear();
                        gameRunning = false;
                    }
                }
                Console.ReadKey();
            }
        }


        // <------------------------- Read Maze ------------------------->
        static void readMaze(string maze_path, char[,] maze)
        {
            int y = 0;
            if (File.Exists(maze_path))
            {
                StreamReader fileVariable = new StreamReader(maze_path, true);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    for (int i = 0; i < record.Length; i++)
                    {
                        maze[y, i] = record[i];

                    }
                    y++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }
        // <------------------------- Print Maze ------------------------->
        static void printMaze(char[,] maze)
        {
            for (int i = 0; i < 43; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        // <------------------------- Print Bob ------------------------->
        static void printBob(char[] Bob1, char[] Bob2, ref int BobX, ref int BobY)
        {
            //SetConsoleTextAttribute(hConsole, 2);
            Console.SetCursorPosition(BobX, BobY);
            for (int index = 0; index <= 3; index++)
            {
                Console.Write(Bob1[index]);
            }
            Console.SetCursorPosition(BobX, BobY + 1);
            for (int index = 0; index <= 3; index++)
            {
                Console.Write(Bob2[index]);
            }
            //SetConsoleTextAttribute(hConsole, 15);
        }
        // <------------------------- Print Enemy1 ------------------------->
        static void printEnemy(char[] Enemy1, char[] Enemy2, ref int EnemyX, ref int EnemyY)
        {
            //SetConsoleTextAttribute(hConsole, 13);
            Console.SetCursorPosition(EnemyX, EnemyY);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(Enemy1[index]);
            }
            Console.SetCursorPosition(EnemyX, EnemyY + 1);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(Enemy2[index]);
            }
            //SetConsoleTextAttribute(hConsole, 15);
        }
        // <------------------------- Print Enemy2 ------------------------->
        static void printEnemy2(ref int enemy2x, ref int enemy2y, char[] Enemy2_1, char[] Enemy2_2)
        {
            Console.SetCursorPosition(enemy2x, enemy2y);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(Enemy2_1[index]);
            }
            Console.SetCursorPosition(enemy2x, enemy2y + 1);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(Enemy2_2[index]);
            }
        }
        // <------------------------- Print Enemy3 ------------------------->
        static void printEnemy3(ref int Enemy3_X, ref int Enemy3_Y, char[] Enemy3_1, char[] Enemy3_2)
        {
            //SetConsoleTextAttribute(hConsole, 12);
            Console.SetCursorPosition(Enemy3_X, Enemy3_Y);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(Enemy3_1[index]);
            }
            Console.SetCursorPosition(Enemy3_X, Enemy3_Y + 1);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(Enemy3_2[index]);
            }
            //SetConsoleTextAttribute(hConsole, 15);
        }
        // <------------------------- Move Bob Left ------------------------->
        static void moveBobLeft(char[] Bob1, char[] Bob2, ref int BobX, ref int BobY, char[,] maze)
        {
            char next = maze[BobY, BobX - 1];
            if (next == ' ' || next == '|')
            {
                eraseBob(ref BobX, ref BobY);
                BobX = BobX - 1;
                printBob(Bob1, Bob2, ref BobX, ref BobY);
            }
            if (next == '[')
            {
                eraseBob(ref BobX, ref BobY);
                BobX = BobX - 6;
                printBob(Bob1, Bob2, ref BobX, ref BobY);
            }
        }
        // <------------------------- Move Bob Right ------------------------->
        static void moveBobRight(char[] Bob1, char[] Bob2, ref int BobX, ref int BobY, char[,] maze)
        {
            //Console.SetCursorPosition(BobX+4, BobY);
            //maze[BobY, BobX+4] = 'p';
            //Console.Write(maze[BobY, BobX + 4]);
            char next = maze[BobY, BobX + 4];
            if (next == ' ' || next == '|')
            {
                eraseBob(ref BobX, ref BobY);
                BobX = BobX + 1;
                printBob(Bob1, Bob2, ref BobX, ref BobY);

            }
            if (next == ']')
            {
                eraseBob(ref BobX, ref BobY);
                BobX = BobX + 6;
                printBob(Bob1, Bob2, ref BobX, ref BobY);
            }
        }
        // <------------------------- Move Bob Up ------------------------->
        static void moveBobUp(char[] Bob1, char[] Bob2, ref int BobX, ref int BobY, char[,] maze)
        {

            char next = maze[BobY - 1, BobX];
            if (next == ' ' || next == '|')
            {
                eraseBob(ref BobX, ref BobY);
                BobY = BobY - 3;
                printBob(Bob1, Bob2, ref BobX, ref BobY);
            }
        }
        // <------------------------- Move Bob Down ------------------------->
        static void moveBobDown(char[] Bob1, char[] Bob2, ref int BobX, ref int BobY, char[,] maze)
        {

            char next = maze[BobY + 2, BobX];
            if (next == ' ' || next == '|')
            {
                eraseBob(ref BobX, ref BobY);
                BobY = BobY + 3;
                printBob(Bob1, Bob2, ref BobX, ref BobY);
            }
        }
        // <------------------------- Erase Bob ------------------------->
        static void eraseBob(ref int BobX, ref int BobY)
        {
            Console.SetCursorPosition(BobX, BobY);
            for (int index = 0; index <= 3; index++)
            {

                Console.Write(" ");
            }
            Console.SetCursorPosition(BobX, BobY + 1);
            for (int index = 0; index <= 3; index++)
            {
                Console.Write(" ");
            }
        }
        // <------------------------- Print Score ------------------------->
        static void printScore(ref int score)
        {
            Console.SetCursorPosition(110, 17);
            Console.Write("Score: " + score);
            //Console.SetCursorPosition(110, 19);
        }
        // Create Bullet
        static void generateBulletRight(bool[] isBulletActive1, List<Enemy> bullet,ref int bulletCount1, ref int BobX, ref int BobY)
        {
            Enemy bullet_object = new Enemy();
            bullet_object.bullet1X = BobX + 5;
            bullet_object.bullet1Y = BobY;
            isBulletActive1[bulletCount1] = true;
            Console.SetCursorPosition(BobY, BobX + 5);
            Console.Write(".");
            bullet.Add(bullet_object);
            bulletCount1++;
        }
        static void generateBulletLeft(bool[] isBulletActive2, List<Enemy1> bullet2, ref int bulletCount2, ref int BobX, ref int BobY)
        {
            Enemy1 bullet_object = new Enemy1();
            bullet_object.bullet2X = BobX - 5;
            bullet_object.bullet2Y = BobY;
            isBulletActive2[bulletCount2] = true;
            Console.SetCursorPosition(BobY, BobX - 5);
            Console.Write(".");
            bullet2.Add(bullet_object);
            bulletCount2++;
        }
        // Print Bullet
        static void printBullet1(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(".");
        }
        static void printBullet2(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(".");
        }
        // Erase Bullet
        static void eraseBullet1(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void eraseBullet2(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        // Bullet Activation/Inactivation
        static void makeBulletInactive1(bool[] isBulletActive1, int index)
        {
            isBulletActive1[index] = false;
        }
        static void makeBulletInactive2(bool[] isBulletActive2, int index)
        {
            isBulletActive2[index] = false;
        }
        // Move Bullet
        static void moveBulletRight(bool[] isBulletActive1, List<Enemy> bullet, ref int bulletCount1, char[,] maze)
        {
            for (int x = 0; x < bulletCount1; x++)
            {
                if (isBulletActive1[x] == true)
                {
                    char next = maze[bullet[x].bullet1Y, bullet[x].bullet1X + 6];
                    //char next1 = maze[bullet[x].bullet1Y, bullet[x].bullet1X - 3];
                    if (next != ' ' || next == '{' || next == ']' || next == '#')
                    {
                        eraseBullet1(bullet[x].bullet1X, bullet[x].bullet1Y);
                        makeBulletInactive1(isBulletActive1, x);
                    }
                    //if ( next1 == '{' )
                    //{
                    //    eraseBullet1(bullet[x].bullet1X, bullet[x].bullet1Y);
                    //    makeBulletInactive1(isBulletActive1, x);
                    //}
                    else
                    {
                        eraseBullet1(bullet[x].bullet1X, bullet[x].bullet1Y);
                        bullet[x].bullet1X = bullet[x].bullet1X + 1;
                        printBullet1(bullet[x].bullet1X, bullet[x].bullet1Y);
                    }
                }
            }
        }
        static void moveBulletLeft(bool[] isBulletActive2, List<Enemy1> bullet2, ref int bulletCount2, char[,] maze)
        {
            for (int x = 0; x < bulletCount2; x++)
            {
                if (isBulletActive2[x] == true)
                {
                    char next = maze[bullet2[x].bullet2Y, bullet2[x].bullet2X - 1];
                    if (next != ' ' || next == '}' || next == '[' || next == '#')
                    {
                        eraseBullet2(bullet2[x].bullet2X, bullet2[x].bullet2Y);
                        makeBulletInactive2(isBulletActive2, x);
                    }
                    else
                    {
                        eraseBullet2(bullet2[x].bullet2X, bullet2[x].bullet2Y);
                        bullet2[x].bullet2X = bullet2[x].bullet2X - 1;
                        printBullet2(bullet2[x].bullet2X, bullet2[x].bullet2Y);
                    }
                }
            }
        }
        // Bullet Collision With Enemy
        static void bulletCollisionWithEnemy1(ref int Enemy1_health, ref int score, List<Enemy> bullet, ref int bulletCount1, ref int EnemyX, bool[] isBulletActive1)
        {
            for (int x = 0; x < bulletCount1; x++)
            {
                if (isBulletActive1[x] == true)
                {
                    if (bullet[x].bullet1X + 1 == EnemyX)
                    {
                        addScore(ref score);
                    }
                    if (EnemyX - 1 == bullet[x].bullet1X)
                    { addScore(ref score);
                        Enemy1_health_Minus(ref Enemy1_health);
                    }
                }
            }
        }
        static void bulletCollisionWithEnemy2(ref int Enemy3_health, ref int score, List<Enemy1> bullet2, ref int bulletCount2, ref int Enemy3_X, bool[] isBulletActive2)
        {
            for (int x = 0; x < bulletCount2; x++)
            {
                if (isBulletActive2[x] == true)
                {
                    if (bullet2[x].bullet2X + 1 == Enemy3_X)
                    {
                        addScore(ref score);
                    }
                    if (Enemy3_X +8 == bullet2[x].bullet2X)
                    {
                        addScore(ref score);
                        Enemy2_health_Minus(ref Enemy3_health);
                    }
                }
            }
        }
        // Add Score
        static void addScore(ref int score)
        {
            score++;
        }
        static int frontPage()
        {
            int choice;
            //int L = 35;
            //frontcharater();
            loadscreen();
            //frontcharater();
            //SetConsoleTextAttribute(hConsole, 15);
            //shortLineStyle(L, 14);
            //Console.SetCursorPosition(150,16);
            //cout << ch << ch << " " << "1. Play Game..." << endl;
            Console.WriteLine(" " + "1. Play Game...");
            //Console.SetCursorPosition(150,19);
            //cout << ch << ch << " " << "2. Instructions..." << endl;
            Console.WriteLine(" " + "2. Instructions...");
            //Console.SetCursorPosition(150, 21);
            //cout << ch << ch << " " << "3. Exit Game..." << endl;
            Console.WriteLine(" " + "3. Exit Game...");
            //shortLineStyle(L, 21);
            //Console.SetCursorPosition(150,23);
            choice=int.Parse(Console.ReadLine());
            return choice;
        }
        static void loadscreen()
        {
            //Console.Clear();
            //system("COLOR 09");
            // system("cls");
            //printf("\e[?25l");

            //Set ASCII to print special character.
            //Code page 437
            //SetConsoleCP(437);
            //SetConsoleOutputCP(437);
            print_gameName();
            //int bar1 = 177, bar2 = 219;
            //gotoxy(150, 15);
            // cout << "\n\n\n\t\t\t\tLoading...";
            //Console.WriteLine("Loading...");
            //cout << "\n\n\n\t\t\t\t";
            //gotoxy(150, 17);
            //for (int i = 0; i < 25; i++)
            //{
            //    cout << (char)bar1;

            //}
            //cout << "\r";
            //cout << "\t\t\t\t";
            //gotoxy(150, 17);
            //for (int i = 0; i < 25; i++)
            //{
            //    cout << (char)bar2;
            //    Sleep(150);
            //}
            //gotoxy(150, 19);
            //// cout<<"\n\t\t\t\t" << (char)1 <<"!";
            //cout << (char)1 << "!";
            //system("Pause");
            // gotoxy(150,35);


            // return 0;
        }
        static void frontcharater()
        {
            //Console.Clear();
            //SetConsoleTextAttribute(hConsole, 3);
            Console.WriteLine("                       ..::=+****###***+==-::.                        ");
            Console.WriteLine("                   .-+#%%#***++++++++++++**###%#*-.                   ");
            Console.WriteLine("               .:+%%#*+=======++===============+*%#+-.                ");
            Console.WriteLine("              :*%#+=+==============================*%%=               ");
            Console.WriteLine("             =@%+=====++++*****######*******+++======*%*.             ");
            Console.WriteLine("           .=%#=+*##%%%##%%***@#**+@**+#@**#%@%%%%##*+*@*.            ");
            Console.WriteLine("          .+@@%%%@*++@++=##==+%*===%+==+@+==##==+@***@%@@#+:.         ");
            Console.WriteLine("        .-#%#@+=+@+==@+==#%+++%*+++%*++*%++=##==+@++=@+=+@%%%*-       ");
            Console.WriteLine("      .=#@*=+%+==%*++%%**#@#**%%***%#**#%***%#**#%+++@+==%*=+@%#:     ");
            Console.WriteLine("     =%#=%*==%***%%**#@##%@%%%@@@%@@@@@@@%%%@%##@#**%%*+*%+++@=%@:    ");
            Console.WriteLine("    .#@==#%+*#@#%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%##@#*+##=+@+.   ");
            Console.WriteLine("    :%%=+*%%#%@@@@%%%%%@%@@@@@@%%%%%@%@%@@@@@@%%%%%%@@@@@%##%*++@*.   ");
            Console.WriteLine("    -%@#*#@@@@@@%@-...-@@#-==++*%%%%@@*++==+@@#::..-%@@%@@@@%*#@@%+-  ");
            Console.WriteLine(" :+%*++@%@@%@@@%%%#.   -=.    -#@@@@%@%=.  .-=:   .#@@@@@%@@@@%*--+@+ ");
            Console.WriteLine(" #@-:-:-#@@@@@@@@@%%+:....:=*%%@@@%%@@@@%*=:....:+%@@@@@%@@@@@::::-%%.");
            Console.WriteLine(".%@=---+@*-+%@@@@@@@@@@%%%@@@@@%+:::-+%@@@@@@@%%%@@@@@@@@#+:=%%===+@* ");
            Console.WriteLine(" =%@*+*@+::::-+#%@@@@@@@@@@@%@#=------+@%%@@@@@@@@@@%*+-::::::#@#%#-. ");
            Console.WriteLine("  :=*#%@=::::::::-==+****+=-:-*%%***#%%*::-=++++=--::::::::::-*@+.    ");
            Console.WriteLine("     .-@*-::::::::::::::::::::::-++++-::::::::::::::::::::::-=#@:     ");
            Console.WriteLine("      .%@=-:::::::::::::::::::::::::::::::::::::-::::::::::-=+@*      ");
            Console.WriteLine("       -%%=--:::::::=#*+-::::::::::::::::::::-+#%-:::::::--=+@#.      ");
            Console.WriteLine("        :*@*=--:::::::=*#%%#*+==-------=++*#%%*=:::::::--==*@+        ");
            Console.WriteLine("          -#%*==---:::::::--=++*######**++=-:::::::--====*%#-         ");
            Console.WriteLine("           -%@@#*===----::::::::::::::::::::::---=====+#@@=           ");
            Console.WriteLine("         .%##@@@@@%*+========------------=========+*%@@@%*%-          ");
            Console.WriteLine("        -@=   :=*#%@@@%##**+==============++*##%%@@%#+-.  .#*         ");
            Console.WriteLine("       -%@@#+-.    -@#..:=+**###%%%%%%####*+=-:=@#.   .:-+%@@*        ");
            Console.WriteLine("      :%@@@@@@@@%#*%@:                         :#@#*#%@@@@@@@@-       ");
            Console.WriteLine("     .#@#+*%@@@@@@@@@@%#*+==------------==+*#%@@@@@@@@@@@@#*+@@:      ");
            Console.WriteLine("     -@%-:::-+++*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#+++=::::+@%      ");
            Console.WriteLine("     =@#:::-====+@@#+#%%@@@@@@@@@@@@@@@@@@@@%%#*+=@@%====--::-@@      ");
            Console.WriteLine("     =@@=--==*%%@@@:    ..::--=-------=-::..      #@@%%#+=---#@#      ");
            Console.WriteLine("     .*@@@%#%@@@@@%.    -++=-:.       .:--+*+.    =@*-=%@%#%@%:.      ");
            Console.WriteLine("      .:-:......-@%*+===--=+%@%%@@@@@%%@@#+==++##%@@@:.::---:.:.      ");
            Console.WriteLine("                -@@@@@@@@@@@@%:..:.....*@@@@@@@@@@@@%:.:....::..      ");
            Console.WriteLine("                .-+*#%%%%%%#+-.... ...::+*%%%%%%%#*=..................");

            //SetConsoleTextAttribute(hConsole, 15);
        }
        static void print_gameName()
        {
            //Console.SetCursorPosition(140,2);
            Console.WriteLine("______       _       _____ _           ______      _     _               ");
            //Console.SetCursorPosition(140, 3);
            Console.WriteLine("| ___ \\     | |     |_   _| |          | ___ \\    | |   | |              ");
            //Console.SetCursorPosition(140, 4);
            Console.WriteLine("| |_/ / ___ | |__     | | | |__   ___  | |_/ /___ | |__ | |__   ___ _ __ ");
            //Console.SetCursorPosition(140, 5);
            Console.WriteLine("| ___ \\/ _ \\| '_ \\    | | | '_ \\ / _ \\ |    // _ \\| '_ \\| '_ \\ / _ \\ '__|");
            //Console.SetCursorPosition(140, 6);
            Console.WriteLine("| |_/ / (_) | |_) |   | | | | | |  __/ | |\\ \\ (_) | |_) | |_) |  __/ |   ");
            //Console.SetCursorPosition(140, 7);
            Console.WriteLine("\\____/ \\___/|_.__/    \\_/ |_| |_|\\___| \\_| \\_\\___/|_.__/|_.__/ \\___|_|   ");

        }
        // Move Enemy 2
        static void enemymove2(ref string direction,ref int enemy2x, ref int enemy2y,char[,] maze,char[] Enemy2_1, char[] Enemy2_2)
        {

            char previousChar = ' ';
            if (direction == "right")
            {
                char nextLocation = maze[enemy2y, enemy2x + 5];
                if (nextLocation == '{')
                {
                    direction = "left";
                }
                else if (nextLocation == ' ')
                {
                    clear(enemy2x, enemy2y, previousChar);
                    enemy2x = enemy2x + 1;
                    previousChar = nextLocation;
                    printEnemy2(ref enemy2x,ref enemy2y,Enemy2_1,Enemy2_2);
                }
            }
            if (direction == "left")
            {
                char nextLocation = maze[enemy2y, enemy2x - 1];
                if (nextLocation == '#')
                {
                    direction = "right";
                }
                else if (nextLocation == ' ')
                {
                    clear(enemy2x, enemy2y, previousChar);
                    enemy2x = enemy2x - 1;
                    previousChar = nextLocation;
                    printEnemy2(ref enemy2x, ref enemy2y, Enemy2_1, Enemy2_2);
                }
            }
        }
        // Clear Enemy Previous Loction
        static void clear(int enemy2x, int enemy2y, char previous)
        {
            Console.SetCursorPosition(enemy2x, enemy2y);
            for (int index = 0; index <= 4; index++)
            {

                Console.Write(previous);
            }
            Console.SetCursorPosition(enemy2x, enemy2y + 1);
            for (int index = 0; index <= 4; index++)
            {
                Console.Write(previous);
            }
        }
        // Enemy1 Health
        static void Enemy1_health_Minus(ref int Enemy1_health)
        {
            Enemy1_health--;
        }
        static void Print_Enemy1_Health(ref int Enemy1_health)
        {
            Console.SetCursorPosition(110, 18);
            Console.Write("Enemy1 Health: " + Enemy1_health + " ");
        }
        // Enemy2 Health
        static void Enemy2_health_Minus(ref int Enemy2_health)
        {
            Enemy2_health--;
        }
        static void Print_Enemy2_Health(ref int Enemy2_health)
        {
            Console.SetCursorPosition(110, 19);
            Console.Write("Enemy2 Health: " + Enemy2_health + " ");
        }
        // Enemy3 Health
        static void Enemy3_health_Minus(ref int Enemy3_health)
        {
            Enemy3_health--;
        }
        static void Print_Enemy3_Health(ref int Enemy3_health)
        {
            Console.SetCursorPosition(110, 20);
            Console.Write("Enemy3 Health: " + Enemy3_health + " ");
        }
    }
}
