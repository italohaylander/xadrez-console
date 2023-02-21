﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {


        private PartidaDeXadrez Partida;
        public Peao(Tabuleiro tab, Cor cor,PartidaDeXadrez partida) : base(cor, tab) {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigos(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return  Tabuleiro.Peca(pos) == null;
            
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0,0);


            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantidadeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1 );
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigos(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigos(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                // #JogadaEspecial enPassant

                if(Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha,Posicao.Coluna -1 );
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigos(esquerda) && Tabuleiro.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;   
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigos(direita) && Tabuleiro.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha -1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantidadeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha +1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigos(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigos(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }


                // #JogadaEspecial enPassant

                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigos(esquerda) && Tabuleiro.Peca(esquerda) == Partida.VulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigos(direita) && Tabuleiro.Peca(direita) == Partida.VulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }


            }

            return mat;
           
        }


    }
}
