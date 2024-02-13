// variable
int[,] sudoku = new int[9, 9];
int[,] vraisudoku = new int[9, 9];


// main
RentrerValeur(sudoku, vraisudoku);
Console.Clear();
Console.WriteLine("Le programme charge une solution");
RemplirTableau(sudoku, vraisudoku);
Console.Clear();
Console.WriteLine("Voici la solution\n");
Dessinersudoku(vraisudoku);
Console.ReadLine();

// fonction
static void RentrerValeur(int[,] sudoku, int[,] vraisudoku)
{
    int x = 0;
    int y = 0;
    int valeur = 1;

    for (int i = 0; i < 9; i++)
    {
        for (int v = 0; v < 9; v++)
        {
            sudoku[i, v] = 0;
        }
    }

    while (valeur > 0)
    {
        Console.Write("Rentrez le x: ");
        x = int.Parse(Console.ReadLine());

        Console.Write("Rentrez le y: ");
        y = int.Parse(Console.ReadLine());

        Console.Write("Rentrez la valeur: ");
        valeur = int.Parse(Console.ReadLine());

        if (valeur > 0)
        {
            sudoku[y - 1, x - 1] = valeur + 10;
            vraisudoku[y - 1, x - 1] = valeur;
        }
        Console.Clear();
        Dessinersudoku(vraisudoku);
    }
}

static void Dessinersudoku(int[,] sudoku)
{
    for (int i = 0; i < 9; i++)
    {
        for (int v = 0; v < 9; v++)
        {
            if(v == 3 || v == 6)
            {
                Console.Write(" | ");
            }
            Console.Write(sudoku[i, v]);
        }
        Console.WriteLine();
        if(i == 2 || i== 5)
        {
            Console.WriteLine("---------------");
        }
    }
}

static void RemplirTableau(int[,] sudoku, int[,] vraisudoku)
{
    for (int i = 0; i < 9; i++)
    {
        for (int v = 0; v < 9; v++)
        {
            if (sudoku[i, v] < 10)
            {
                vraisudoku[i, v]++;
                if (VerifierLigne(vraisudoku, v, i, vraisudoku[i, v]) && VerifierColonne(vraisudoku, v, i, vraisudoku[i, v]) && VerifierCase(vraisudoku, v, i, vraisudoku[i, v]))
                {

                }
                else
                {
                    if (vraisudoku[i, v] == 9)
                    {
                        vraisudoku[i, v] = 0;
                        if (v == 0)
                        {
                            i--;
                            v = 8;
                            while (sudoku[i, v] > 10 || (vraisudoku[i, v] == 9 && sudoku[i, v] < 10))
                            {
                                if (sudoku[i, v] < 10)
                                {
                                    vraisudoku[i, v] = 0;
                                }

                                if (v == 0)
                                {
                                    i--; v = 8;
                                }
                                else
                                {
                                    v--;
                                }
                            }
                        }
                        else
                        {
                            v--;
                            while (sudoku[i, v] > 10 || (vraisudoku[i, v] == 9 && sudoku[i, v] < 10))
                            {
                                if (sudoku[i, v] < 10)
                                {
                                    vraisudoku[i, v] = 0;
                                }
                                if (v == 0)
                                {
                                    i--; 
                                    v = 8;
                                }
                                else
                                {
                                    v--;
                                }
                            }

                        }
                        v--;
                    }
                    else
                    {
                        v--;
                    }
                }
            }
        }
    }
}

static bool VerifierLigne(int[,] vraisudoku, int x, int y, int valeur)
{
    for (int v = 0; v < 9; v++)
    {
        if (v != x)
        {
            if (vraisudoku[y, v] == valeur)
            {
                return false;
            }
        }
    }
    return true;
}

static bool VerifierColonne(int[,] vraisudoku, int x, int y, int valeur)
{
    for (int v = 0; v < 9; v++)
    {
        if (v != y)
        {
            if (vraisudoku[v, x] == valeur)
            {
                return false;
            }
        }
    }
    return true;
}

static bool VerifierCase(int[,] vraisudoku, int x, int y, int valeur)
{
    if (x < 3 && y < 3)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int v = 0; v < 3; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 6 && y < 3)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int v = 3; v < 6; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 9 && y < 3)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int v = 6; v < 9; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 3 && y < 6)
    {
        for (int i = 3; i < 6; i++)
        {
            for (int v = 0; v < 3; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 6 && y < 6)
    {
        for (int i = 3; i < 6; i++)
        {
            for (int v = 3; v < 6; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 9 && y < 6)
    {
        for (int i = 3; i < 6; i++)
        {
            for (int v = 6; v < 9; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 3 && y < 9)
    {
        for (int i = 6; i < 9; i++)
        {
            for (int v = 0; v < 3; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 6 && y < 9)
    {
        for (int i = 6; i < 9; i++)
        {
            for (int v = 3; v < 6; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    else if (x < 9 && y < 9)
    {
        for (int i = 6; i < 9; i++)
        {
            for (int v = 6; v < 9; v++)
            {
                if (v == x && i == y)
                {
                }
                else
                {
                    if (vraisudoku[i, v] == valeur)
                    {
                        return false;
                    }
                }
            }
        }
    }
    return true;
}