using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("#JOGO DA VELHA#");
            Console.WriteLine("Digite 1 para iniciar o jogo");
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
        }
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
            if (JogadorAtual == jogadorO)
            {
                Console.WriteLine("Vez do computador");
                Console.ReadKey();
                linha = new Random().Next(0, 3);
                coluna = new Random().Next(0, 3);

                while (tabuleiro[linha, coluna] != null)
                {
                    linha = new Random().Next(0, 3);
                    coluna = new Random().Next(0, 3);
                }
            }
            else
            {
                Console.WriteLine("Jogador atual: " + JogadorAtual);
                linha = ObterPosicao("linha") - 1;
                coluna = ObterPosicao("coluna") - 1;

                if (tabuleiro[linha, coluna] == null)
                {
                    tabuleiro[linha, coluna] = JogadorAtual;

                    if (VerificarVitoria(tabuleiro))
                    {
                        Console.Clear();
                        ImprimirTabuleiro(tabuleiro);
                        Console.WriteLine("Vitória do jogador " + JogadorAtual);
                        fimDeJogo = true;
                    }
                    else if (VerificarEmpate(tabuleiro))
                    {
                        Console.Clear();
                        ImprimirTabuleiro(tabuleiro);
                        Console.WriteLine("Deu velha!");
                        fimDeJogo = true;
                    }
                    else
                    {
                        JogadorAtual = JogadorAtual == jogadorX ? jogadorO : jogadorX;
                    }
                }
                else
                {
                    Console.WriteLine("Posição está ocupada. Tente novamente.");
                }
            }
            Console.Clear();
            ImprimirTabuleiro(tabuleiro);
        }
    }

    static int ObterPosicao(string tipo)
    {
        int posicao;
        while (true)
        {
            Console.WriteLine($"Digite a {tipo} (1-3):");
            if (int.TryParse(Console.ReadLine(), out posicao) && posicao >= 1 && posicao <= 3)
            {
                return posicao;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }
    }

    static bool VerificarVitoria(string[,] tabuleiro)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tabuleiro[i, 0] != null && tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2]) return true;
            if (tabuleiro[0, i] != null && tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i]) return true;
        }
        if (tabuleiro[0, 0] != null && tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2]) return true;
        if (tabuleiro[0, 2] != null && tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0]) return true;
        return false;
    }

    static bool VerificarEmpate(string[,] tabuleiro)
    {
        foreach (var celula in tabuleiro)
        {
            if (celula == null)
                return false;
        }
        return true;
    }

    static void ImprimirTabuleiro(string[,] tabuleiro)
    {
        for (int linha = 0; linha < 3; linha++)
        {
            for (int coluna = 0; coluna < 3; coluna++)
            {
                string valor = tabuleiro[linha, coluna] ?? " ";
                Console.Write($" {valor} ");
                if (coluna < 2)
                    Console.Write("|");
            }
            Console.WriteLine();
            if (linha < 2)
                Console.WriteLine("---|---|---");
        }
    }
}
