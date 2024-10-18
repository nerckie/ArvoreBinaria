﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caArvoreBinaria
{
    class NohArvore
    {
        // atributos
        private int valor;
        private NohArvore noEsquerda; // sae
        private NohArvore noDireita;  // sad

        // métodos
        public NohArvore() { }

        public NohArvore(int _valor)
        {
            noEsquerda = null;
            this.valor = _valor;
            noDireita = null;
        }

        public int getValor()
        {
            return valor;
        }

        public void setValor(int _valor)
        {
            this.valor = _valor;
        }

        public NohArvore getNoEsquerda()
        {
            return noEsquerda;
        }

        public void setNoEsquerda(NohArvore _noEsquerda)
        {
            this.noEsquerda = _noEsquerda;
        }

        public NohArvore getNoDireita()
        {
            return noDireita;
        }

        public void setNoDireita(NohArvore _noDireita)
        {
            this.noDireita = _noDireita;
        }

    } // fim da classe NohArvore
}
