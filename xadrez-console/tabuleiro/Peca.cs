using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez_console.tabuleiro
{
     class Peca
    {
      

        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set;}
        public int QuantidadeMovimentos { get; protected set; }

        public Tabuleiro Tabuleiro { get; set; }

        public Peca() { }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QuantidadeMovimentos = 0;
            
        }
    }
}
