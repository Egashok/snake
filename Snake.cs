using System;
using System.Timers;

System.Timers.Timer timer = new System.Timers.Timer();

bool quit = false;
int vx;
int vy;
int headX;
int headY;
int[,] GameField;
int w = 40, h = 40;
int score = 0;



void Init()
{
    Console.CursorVisible = false;
    Console.SetWindowSize(w + 1, h + 3);
    Console.SetBufferSize(w + 1, h + 3);
}

void Load()
{
    vx = 0;
    vy = 1;
    headX = w / 2;
    headY = h / 2;
    GameField = new int[w + 1, h + 1];
    GameField[headX, headY] = 1;
    Random random = new Random();

    GameField[random.Next(1, w), random.Next(1, h)] = -1;

    for (int i = 0; i <= w; i++)
    {
        GameField[i, 0] = 10000;
        GameField[i, h] = 10000;
    }
    for (int i = 0; i < h; i++)
    {
        GameField[0, i] = 10000;
        GameField[w, i] = 10000;
    }
}

void Update()
{
    {
        headX += vx;
        headY += vy;
        if (Collision()) return;

        if (GameField[headX, headY] < 0)
        {
            score++;
            Random random = new Random();
            GameField[random.Next(1, w), random.Next(1, h)] = -1;  
            GameField[headX, headY] = 1;
            Next(headX - vx, headY - vy, 1, 1);
        }
        else
            Next(headX, headY, 1);

    }
}

bool Collision()
{
    if (GameField[headX, headY] > 0) quit = true;
   
    return quit;
}
void Next(int tailX, int tailY, int n, int p = 0)
{

    GameField[tailX, tailY] = n + p;

    if (GameField[tailX + 1, tailY] == n + p) Next(tailX + 1, tailY, n + 1, p);
    else
        if (GameField[tailX - 1, tailY] == n + p) Next(tailX - 1, tailY, n + 1, p);
    else
        if (GameField[tailX, tailY - 1] == n + p) Next(tailX, tailY - 1, n + 1, p);
    else
        if (GameField[tailX, tailY + 1] == n + p) Next(tailX, tailY + 1, n + 1, p);
    else
        if (p == 0) GameField[tailX, tailY] = 0;

}

void PrintGameField()
{
    for (int y = 0; y <= h; y++)
        for (int x = 0; x <= w; x++)
        {
            Console.SetCursorPosition(x, y + 1);

            switch (GameField[x, y])
            {
                case 0:
                    Console.WriteLine(' ');
                    break;
                case -1:
                    Console.WriteLine('&');
                    break;
                case 1:
                    Console.WriteLine('*');
                    break;
                case 10000:
                    Console.WriteLine("█");
                    break;
                default:
                
                    Console.WriteLine('*');
                    break;
            }
        }
    Console.SetCursorPosition(10, 0);
    Console.Write($"Score:{score}");
}


void KeyboardUpdate()
{
    if (Console.KeyAvailable)
    {

        ConsoleKey key = Console.ReadKey().Key;

        switch (key)
        {

            case ConsoleKey.LeftArrow:

                vx = -1;
                vy = 0;
                break;
            case ConsoleKey.RightArrow:

                vx = 1;
                vy = 0;
                break;
            case ConsoleKey.UpArrow:

                vx = 0;
                vy = -1;
                break;
            case ConsoleKey.DownArrow:

                vx = 0;
                vy = 1;
                break;

            case ConsoleKey.Escape:
                timer.Stop();
                quit = true;
                break;

        }


    }

}

Init();

Console.ReadKey();
while (true)
{
    Load();
    Next(headX - vx, headY - vy, 1, 1);
    PrintGameField();
    Console.ReadKey();
    while (!quit)
    {
        KeyboardUpdate();
        Update();
        PrintGameField();
    };
    score = 0;
    quit = false;
};