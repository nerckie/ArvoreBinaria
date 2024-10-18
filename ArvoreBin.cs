using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace caArvoreBinaria
{
    class ArvoreBin
    {
        // atributos 
        private NohArvore root;

        // métodos
        public ArvoreBin()
        {
            root = null;
        }

        public bool isEmpty()
        {
            if (root == null)
                return true;
            else
                return false;
        }

        public void inserir(int n) // aridade 1
        {
            inserir(this.root, n); // aridade 2
        }

        public void inserir(NohArvore node, int valor) // aridade 2
        {                               // 10 e 15
            if (this.root == null)
            {
                this.root = new NohArvore(valor);
            }
            else
            {
                if (valor < node.getValor())
                { // insere a esquerda
                    if (node.getNoEsquerda() != null)
                    {
                        inserir(node.getNoEsquerda(), valor);
                    }
                    else // subarvore da esquerda está vazia
                    {
                        //Se nodo esquerdo vazio insere o novo no aqui 
                        node.setNoEsquerda(new NohArvore(valor));
                    }

                    //Verifica se o valor a ser inserido é maior que o noh corrente 
                    //da árrvore, se sim vai para subarvore direita 
                }
                else if (valor > node.getValor())
                {
                    //Se tiver elemento no no direito continua a busca 
                    if (node.getNoDireita() != null)
                    {
                        inserir(node.getNoDireita(), valor);
                    }
                    else // subárvore da direita está vazia
                    {
                        //Se nodo direito vazio insere o novo no aqui 
                        node.setNoDireita(new NohArvore(valor));
                    }
                } // fim do if para inserir a direita
            }

        } // fim do metodo inserir - aridade 2

        public void imprimirArvore()
        {
            if (this.root == null)
                Console.WriteLine("Árvore vazia");
            else
                imprimirArvore(this.root);
        }

        public void imprimirArvore(NohArvore node)
        {
            if (node.getNoEsquerda() != null)
            {
                imprimirArvore(node.getNoEsquerda());
            }

            Console.WriteLine("Noh: " + node.getValor());

            if (node.getNoDireita() != null)
            {
                imprimirArvore(node.getNoDireita());
            }

        }

        public void remover(int valor)
        {
            root = remover(root, valor); // Inicia a remoção chamando com a raiz da árvore.
        }

        private NohArvore remover(NohArvore node, int valor)
        {
            if (node == null)
                return node; // Se o nó atual é nulo, a árvore ou subárvore está vazia, não há nada a fazer.

            // Verifica se o valor a ser removido é menor ou maior que o valor do nó atual.
            if (valor < node.getValor())
            {
                node.setNoEsquerda(remover(node.getNoEsquerda(), valor)); // Continua a busca na subárvore à esquerda.
            }
            else if (valor > node.getValor())
            {
                node.setNoDireita(remover(node.getNoDireita(), valor)); // Continua a busca na subárvore à direita.
            }
            else
            {
                // Nó a ser removido encontrado

                // Caso 1: Nó com apenas um filho ou nenhum filho
                if (node.getNoEsquerda() == null)
                {
                    return node.getNoDireita(); // Retorna o filho direito como substituto.
                }
                else if (node.getNoDireita() == null)
                {
                    return node.getNoEsquerda(); // Retorna o filho esquerdo como substituto.
                }

                // Caso 2: Nó com dois filhos - encontrar o sucessor in-order
                node.setValor(minValor(node.getNoDireita())); // Atualiza o valor do nó com o valor mínimo da subárvore à direita.

                // Remover o sucessor in-order
                node.setNoDireita(remover(node.getNoDireita(), node.getValor())); // Remove o sucessor in-order da subárvore à direita.
            }

            return node; // Retorna o nó atual após a remoção ou a atualização.
        }

        private int minValor(NohArvore node)
        {
            int valorMin = node.getValor(); // Começa com o valor do nó atual.
            while (node.getNoEsquerda() != null)
            {
                valorMin = node.getNoEsquerda().getValor(); // Encontra o valor mínimo seguindo para a esquerda.
                node = node.getNoEsquerda();
            }
            return valorMin; // Retorna o valor mínimo na subárvore à esquerda.
        }

        public int altura()
        {
            // Verifica se a árvore está vazia (raiz nula).
            if (this.root == null)
            {
                return 0; // A altura de uma árvore vazia é 0.
            }
            else
            {
                // Chama a função recursiva para calcular a altura da árvore a partir da raiz.
                return altura(this.root);
            }
        }

        private int altura(NohArvore node)
        {
            // Verifica se o nó é nulo (caso base da recursão).
            if (node == null)
            {
                return -1; // A altura de um nó nulo é -1.
            }

            // Calcula a altura das subárvores esquerda e direita de forma recursiva.
            int alturaEsquerda = altura(node.getNoEsquerda());
            int alturaDireita = altura(node.getNoDireita());

            // Retorna a altura máxima entre as subárvores esquerda e direita, acrescida de 1.
            if (alturaEsquerda > alturaDireita)
            {
                return alturaEsquerda + 1;
            }
            else
            {
                return alturaDireita + 1;
            }
        }

        public int numNoh()
        {
            // Verifica se a árvore está vazia (raiz nula).
            if (this.root == null)
            {
                return 0; // Se a árvore estiver vazia, o número de nós é 0.
            }
            else
            {
                // Chama a função recursiva para calcular o número de nós na árvore a partir da raiz.
                return numNoh(this.root);
            }
        }

        private int numNoh(NohArvore node)
        {
            // Verifica se o nó é nulo (caso base da recursão).
            if (node == null)
            {
                return 0; // Se o nó for nulo, não contribui para o número total de nós.
            }

            // Calcula o número de nós nas subárvores esquerda e direita chamando a função recursivamente.
            int numNohEsquerda = numNoh(node.getNoEsquerda());
            int numNohDireita = numNoh(node.getNoDireita());

            // Retorna o número total de nós, que é a soma das subárvores esquerda e direita mais o próprio nó atual.
            return numNohEsquerda + numNohDireita + 1;
        }

        public int numFol()
        {
            // Verifica se a árvore está vazia (raiz nula).
            if (this.root == null)
            {
                return 0; // Se a árvore estiver vazia, o número de folhas é 0.
            }
            else
            {
                // Chama a função recursiva para calcular o número de folhas na árvore a partir da raiz.
                return numFol(this.root);
            }
        }

        private int numFol(NohArvore node)
        {
            // Verifica se o nó é nulo (caso base da recursão).
            if (node == null)
            {
                return 0; // Se o nó for nulo, não há folhas.
            }
            else if (node.getNoEsquerda() == null && node.getNoDireita() == null)
            {
                return 1; // Se o nó não tem filhos, ele é uma folha.
            }
            else
            {
                // Calcula o número de folhas nas subárvores esquerda e direita chamando a função recursivamente.
                int numFolEsquerda = numFol(node.getNoEsquerda());
                int numFolDireita = numFol(node.getNoDireita());
                return numFolEsquerda + numFolDireita;
            }
        }


        public static bool saoiguais(ArvoreBin a, ArvoreBin b)
        {
            // Verifica se ambas as árvores estão vazias (raiz nula).
            if (a.root == null && b.root == null)
            {
                return true; // Se ambas as árvores estiverem vazias, elas são iguais.
            }
            if (a.root == null || b.root == null)
            {
                return false; // Se uma árvore estiver vazia e a outra não, elas não são iguais.
            }
            else
            {
                // Chama a função recursiva para verificar se as árvores são iguais a partir das raízes.
                return saoiguais(a.root, b.root);
            }
        }

        private static bool saoiguais(NohArvore n1, NohArvore n2)
        {
            // Verifica se ambos os nós são nulos (caso base da recursão).
            if (n1 == null && n2 == null)
            {
                return true; // Se ambos os nós forem nulos, eles são iguais.
            }
            if (n1 == null || n2 == null)
            {
                return false; // Se um nó for nulo e o outro não, eles não são iguais.
            }
            if (n1.getValor() != n2.getValor())
            {
                return false; // Se os valores dos nós não forem iguais, eles não são iguais.
            }
            // Verifica se as subárvores esquerda e direita são iguais chamando a função recursivamente.
            bool esq = saoiguais(n1.getNoEsquerda(), n2.getNoEsquerda());
            bool dir = saoiguais(n1.getNoDireita(), n2.getNoDireita());

            // Retorna true apenas se ambas as subárvores esquerda e direita forem iguais.
            return esq && dir;
        }


    } // fim da classe ArvoreBin

}

