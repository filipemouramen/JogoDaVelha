while (true)
{
    Console.Clear();
    Console.WriteLine("#JOGO DA VELHA#");
    Console.WriteLine("Escolha o modo de jogo!");
    Console.WriteLine("1 - Jogador Vs Máquina");
    Console.WriteLine("2 - Humano Vs Humano");
    Console.WriteLine("3 - Sair...");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            IniciarJogoVsMaquina();
            break;
        case "2":
            IniciarJogoVsHumano();
            break;
        case "3":
            Console.WriteLine("Saindo");
            return;
        default:
            Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
            Console.ReadLine();
            break;
    }
}
    
    static void IniciarJogoVsMaquina()
{
    string[,] tabuleiro = new string[3, 3];
    string jogadorO = "O"; 
    string jogadorX = "X"; 
    string jogadorAtual = jogadorX;
    bool fimDeJogo = false;

    while (!fimDeJogo)
    {
        Console.Clear();
        ImprimirTabuleiro(tabuleiro);
        int linha, coluna;

        if (jogadorAtual == jogadorO)
        {
            Console.WriteLine("Vez do computador");
            linha = new Random().Next(0, 3);
            coluna = new Random().Next(0, 3);
            
        }
        else
        {
            Console.WriteLine("Jogador atual: " + jogadorAtual);
            Console.WriteLine("Digite a linha: ");
            linha = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Digite a coluna: ");
            coluna = int.Parse(Console.ReadLine()) - 1;

            if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
            {
                Console.WriteLine("Posição inválida! Pressione Enter para tentar novamente...");
                Console.ReadLine();
                continue;
            }
        }

        if (tabuleiro[linha, coluna] == null)
        {
            tabuleiro[linha, coluna] = jogadorAtual;

            if (VerificarVitoria(tabuleiro, jogadorAtual))
            {
                Console.Clear();
                ImprimirTabuleiro(tabuleiro);
                Console.WriteLine("********Vitória do jogador " + jogadorAtual + "********");
                fimDeJogo = true;
            }
            else if (TabuleiroCheio(tabuleiro))
            {
                Console.Clear();
                ImprimirTabuleiro(tabuleiro);
                Console.WriteLine("Deu velha!");
                fimDeJogo = true;
            }
            else
            {
                jogadorAtual = (jogadorAtual == jogadorX) ? jogadorO : jogadorX;
            }
        }
        else
        {
            Console.WriteLine("Posição ocupada! Pressione Enter para tentar novamente...");
            Console.ReadLine();
        }
    }
    Console.WriteLine("Pressione Enter para voltar ao menu...");
    Console.ReadLine();
}

static void IniciarJogoVsHumano()
{
    string[,] tabuleiro = new string[3, 3];
    string jogadorO = "O";
    string jogadorX = "X";
    string jogadorAtual = jogadorX;
    bool fimDeJogo = false;

    while (!fimDeJogo)
    {
        Console.Clear();
        ImprimirTabuleiro(tabuleiro);
        Console.WriteLine("Jogador atual: " + jogadorAtual);

        Console.WriteLine("Digite a linha: ");
        int linha = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine("Digite a coluna: ");
        int coluna = int.Parse(Console.ReadLine()) - 1;

        if (linha < 0 || linha > 2 || coluna < 0 || coluna > 2)
        {
            Console.WriteLine("Posição inválida! Pressione Enter para tentar novamente...");
            Console.ReadLine();
            continue;
        }

        if (tabuleiro[linha, coluna] == null)
        {
            tabuleiro[linha, coluna] = jogadorAtual;

            if (VerificarVitoria(tabuleiro, jogadorAtual))
            {
                Console.Clear();
                ImprimirTabuleiro(tabuleiro);
                Console.WriteLine("********Vitória do jogador " + jogadorAtual + "********");
                fimDeJogo = true;
            }
            else if (TabuleiroCheio(tabuleiro))
            {
                Console.Clear();
                ImprimirTabuleiro(tabuleiro);
                Console.WriteLine("Deu velha!");
                fimDeJogo = true;
            }
            else
            {
                jogadorAtual = (jogadorAtual == jogadorX) ? jogadorO : jogadorX;
            }
        }
        else
        {
            Console.WriteLine("Posição ocupada! Pressione Enter para tentar novamente...");
            Console.ReadLine();
        }
    }
    Console.WriteLine("Pressione Enter para voltar ao menu...");
    Console.ReadLine();
}
static void ImprimirTabuleiro(string[,] tabuleiro)
{
    for (int linha = 0; linha < 3; linha++)
    {
        for (int coluna = 0; coluna < 3; coluna++)
        {
            Console.Write(tabuleiro[linha, coluna] == null ? "   " : " " + tabuleiro[linha, coluna] + " ");
            if (coluna < 2) Console.Write("|");
        }
        Console.WriteLine();
        if (linha < 2) Console.WriteLine("---+---+---");
    }
    Console.WriteLine();
}

static bool VerificarVitoria(string[,] tabuleiro, string jogador)
{
    return 
        (tabuleiro[0, 0] == jogador && tabuleiro[0, 1] == jogador && tabuleiro[0, 2] == jogador) ||
        (tabuleiro[1, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[1, 2] == jogador) ||
        (tabuleiro[2, 0] == jogador && tabuleiro[2, 1] == jogador && tabuleiro[2, 2] == jogador) ||
        (tabuleiro[0, 0] == jogador && tabuleiro[1, 0] == jogador && tabuleiro[2, 0] == jogador) ||
        (tabuleiro[0, 1] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 1] == jogador) ||
        (tabuleiro[0, 2] == jogador && tabuleiro[1, 2] == jogador && tabuleiro[2, 2] == jogador) ||
        (tabuleiro[0, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[2, 2] == jogador) ||
        (tabuleiro[2, 0] == jogador && tabuleiro[1, 1] == jogador && tabuleiro[0, 2] == jogador);
}
static bool TabuleiroCheio(string[,] tabuleiro)
{
    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            if (tabuleiro[i, j] == null) return false;
    return true;
}
