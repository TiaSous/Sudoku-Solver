// variables 
int[,] sudoku = new int[9, 9];
int[,] vraisudoku = new int[9, 9];

// main
AffichageTableau(9, 9);
Console.SetCursorPosition(8, 0);
Console.Write("Appuyer sur ENTER pour activer la solution. Si vous vous êtes trompés, vous pouvez mettre un 0");
Console.SetCursorPosition(10, 3);
MouvementAndActionPlayer(sudoku, vraisudoku);
Console.SetCursorPosition(8, 0);
Console.Write("Solution trouvé !!!                                                                            ");
RemplirTableau(sudoku, vraisudoku);
Dessinersudoku(vraisudoku);
Console.ReadLine();

// fonction
static void MouvementAndActionPlayer(int[,] sudoku, int[,] vraisudoku)
{
    ConsoleKeyInfo keyInfo = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false); ;
    int userX = 10;
    int userY = 3;
    int number;
    for (int i = 0; i < 9; i++)
    {
        for (int v = 0; v < 9; v++)
        {
            sudoku[i, v] = 0;
        }
    }

    while (keyInfo.Key != ConsoleKey.Enter)
    {
        keyInfo = Console.ReadKey(false);

        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            if(userY>3)
            {
                userY -= 2;
            }
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            if(userY < 19) 
            { 
                userY += 2;
            }
        }
        else if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            if(userX > 10) 
            {
                userX -= 4;
            } 
        }
        else if(keyInfo.Key == ConsoleKey.RightArrow)
        {
            if(userX < 42)
            {
                userX += 4;
            }
        }
        else if(char.IsDigit(keyInfo.KeyChar))
        {
            number = int.Parse(keyInfo.KeyChar.ToString());
            if (number > 0)
            {
                sudoku[(userY - 3) / 2, (userX - 10) / 4] = number + 10;
                vraisudoku[(userY - 3) / 2, (userX - 10) / 4] = number;
            }
            else
            {
                sudoku[(userY - 3) / 2, (userX - 10) / 4] = number;
                vraisudoku[(userY - 3) / 2, (userX - 10) / 4] = number;
            }

        }
        Console.SetCursorPosition(userX, userY);
    }
}

static void Dessinersudoku(int[,] sudoku)
{
    for (int i = 0; i < 9; i++)
    {
        for (int v = 0; v < 9; v++)
        {
            Console.SetCursorPosition(v * 4 + 10, i * 2 + 3);
            Console.Write(sudoku[i, v]);
        }
    }
}

static void AffichageTableau(int intUserColonne, int intUserLigne)
{
    //affiche le tableau
    Console.Write("\n\n\t╔");

    //affiche la ligne selon le nombre de colonne choisit
    for (int y = 0; y < intUserColonne - 1; y++)
    {
        if(y==2 || y==5)
        {
            Console.Write("═══╦");
        }
        else
        {
            Console.Write("════");
        }
    }
    Console.Write("═══╗\t");

    Console.Write("\n\t");

    //affiche le tableau
    for (int y = 0; y < intUserLigne - 1; y++)
    {
        for (int x = 0; x <= intUserColonne; x++)
        {
            if(x==0 || x == 3 || x == 6 || x == 9)
            {
                Console.Write("║   ");
            }
            else
            {
                Console.Write("    ");
            }
        }

        if(y == 2 || y == 5)
        {
            Console.Write("\n\t╠");

            for (int z = 0; z < intUserColonne - 1; z++)
            {
                if(z==2 || z == 5)
                {
                    Console.Write("═══╬");
                }
                else
                {
                    Console.Write("════");
                }
            }

            Console.Write("═══╣\n\t");
        }
        else
        {
            Console.Write("\n\t");
            for (int x = 0; x <= intUserColonne; x++)
            {
                if (x == 0 || x == 3 || x == 6 || x == 9)
                {
                    Console.Write("║   ");
                }
                else
                {
                    Console.Write("    ");
                }
            }
            Console.Write("\n\t");
        }

    }

    for (int x = 0; x <= intUserColonne; x++)
    {
        if (x == 0 || x == 3 || x == 6 || x == 9)
        {
            Console.Write("║   ");
        }
        else
        {
            Console.Write("    ");
        }
    }
    Console.Write("\n\t");
    Console.Write("╚");
    for (int y = 0; y < intUserColonne - 1; y++)
    {
        if(y == 2 || y == 5)
        {
            Console.Write("═══╩");
        }
        else
        {
            Console.Write("════");
        }
        
    }
    Console.Write("═══╝");
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
