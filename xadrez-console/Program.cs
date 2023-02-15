using tabuleiro;
using xadrez;
namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {


            //PosicaoXadrez p1 = new PosicaoXadrez('c', 7);

           // Console.WriteLine(p1);

           // Console.WriteLine(p1.ToPosicao());
            
            
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                              
                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destinho:");
                        Posicao destinho = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.ValidarPosicaoDeDestino(origem, destinho);

                        partida.RealizaJogada(origem, destinho);
                    }
                    catch (TabuleiroException e) 
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                
                
                
                Tela.ImprimirTabuleiro(partida.Tab);
                Console.WriteLine();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

