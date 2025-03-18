while (true)
{
    Console.Clear();
    Console.WriteLine("#JOGO DA VELHA#");
    Console.WriteLine("Digite 1 para Iniciar o jogo");
    Console.WriteLine("Digite 2 para sair do jogo");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            IniciarJogo();
            break;
        case "2":
            Console.WriteLine("Saindo do jogo...");
            return;
    }

    static void IniciarJogo()
    {
        string[,] tabuleiro = new string[3, 3];
        string jogadorO = "O";
        string jogadorX = "X";
        string JogadorAtual = jogadorX;
        int linha, coluna;

        bool fimDeJogo = false;

        while (!fimDeJogo)
        {
            Console.WriteLine("Jogador atual: " + JogadorAtual);
            Console.WriteLine("Digite a linha:");
            linha = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Digite a coluna:");
            coluna = int.Parse(Console.ReadLine()) - 1;

            if (tabuleiro[linha, coluna] == null)
            {
                tabuleiro[linha, coluna] = JogadorAtual;
                if (

                    (tabuleiro[0, 0] == tabuleiro[0, 1] &&
                    tabuleiro[0, 1] == tabuleiro[0, 2]) &&
                    tabuleiro[0, 0] != null
                    ||
                   (tabuleiro[1, 0] == tabuleiro[1, 1] &&
                    tabuleiro[1, 1] == tabuleiro[2, 2]) &&
                    tabuleiro[1, 0] != null
                    ||
                    (tabuleiro[2, 0] == tabuleiro[2, 1] &&
                    tabuleiro[2, 1] == tabuleiro[2, 2]) &&
                    tabuleiro[2, 0] != null
                    ||
                    (tabuleiro[0, 0] == tabuleiro[1, 0] &&
                    tabuleiro[1, 0] == tabuleiro[2, 0] &&
                    tabuleiro[0, 0] != null)
                    ||
                    (tabuleiro[0, 1] == tabuleiro[1, 1] &&
                    tabuleiro[1, 1] == tabuleiro[2, 1] &&
                    tabuleiro[0, 1] != null)
                    ||
                    (tabuleiro[0, 2] == tabuleiro[1, 2] &&
                    tabuleiro[1, 2] == tabuleiro[2, 2] &&
                    tabuleiro[0, 2] != null)
                    ||
                    (tabuleiro[0, 0] == tabuleiro[1, 1] &&
                    tabuleiro[1, 1] == tabuleiro[2, 2] &&
                    tabuleiro[0, 0] != null
                    )
                    ||
                    (tabuleiro[2, 0] == tabuleiro[1, 1] &&
                    tabuleiro[1, 1] == tabuleiro[0, 2] &&
                    tabuleiro[2, 0] != null
                    )
                    )
                {
                    Console.WriteLine("Vitória do jogador" + JogadorAtual);
                    fimDeJogo = true;
                }
                else
                    if
                    (
                    tabuleiro[0, 0] != null &&
                    tabuleiro[0, 1] != null &&
                    tabuleiro[0, 2] != null &&
                    tabuleiro[1, 0] != null &&
                    tabuleiro[1, 1] != null &&
                    tabuleiro[1, 2] != null &&
                    tabuleiro[2, 0] != null &&
                    tabuleiro[2, 1] != null &&
                    tabuleiro[2, 2] != null
                    )
                {
                    Console.WriteLine("Deu velha!");
                    fimDeJogo = true;
                }

                if (JogadorAtual == jogadorX)
                    JogadorAtual = jogadorO;
                else
                    JogadorAtual = jogadorX;
            }
            else
            {
                Console.WriteLine("Posição está ocupada");
            }
            Console.Clear();
            ImprimirTabuleiro();
        }

        void ImprimirTabuleiro()
        {
            for (int linhaTabuleiro = 0; linhaTabuleiro < 3; linhaTabuleiro++)
            {
                for (int colunaTabuleiro = 0; colunaTabuleiro < 3; colunaTabuleiro++)
                {
                    if (tabuleiro[linhaTabuleiro, colunaTabuleiro] == null)
                        Console.Write("   ");
                    else
                        Console.Write(" " + tabuleiro[linhaTabuleiro, colunaTabuleiro] + " ");
                    if (colunaTabuleiro < 2)
                        Console.Write(" | ");
                }
                Console.WriteLine();
                if (linhaTabuleiro < 2)
                    Console.WriteLine("----------------");
            }
        }
    }
}