using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace tabuleiro
{
     abstract class Peca
    {
      

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set;}
        public int QuantidadeMovimentos { get; protected set; }

        public Tabuleiro Tabuleiro { get; set; }

        public Peca() { }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QuantidadeMovimentos = 0;
            
        }
        public void IncrementarQuantidadeMovimento() { 
            QuantidadeMovimentos++;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i =0;i< Tabuleiro.Linhas; i++)
            {
                for(int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j]){
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
