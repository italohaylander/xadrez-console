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
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destinho:");
                    Posicao destinho = Tela.LerPosicaoXadrez().ToPosicao();
                    
                    partida.ExecutaMoviemnto(origem, destinho);
                     
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

