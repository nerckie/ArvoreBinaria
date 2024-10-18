using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caArvoreBinaria
{
    class Program : ArvoreBin
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Arvore Binaria:");

            ArvoreBin arvore1 = new ArvoreBin(); // cria a árvore -> root = null
            ArvoreBin arvore2 = new ArvoreBin(); // cria a árvore -> root = null

            ArvoreBin arvore3 = new ArvoreBin(); // cria a árvore -> root = null
            ArvoreBin arvore4 = new ArvoreBin(); // cria a árvore -> root = null

            ArvoreBin arvore5 = new ArvoreBin(); // cria a árvore -> root = null
            ArvoreBin arvore6 = new ArvoreBin(); // cria a árvore -> root = null

            arvore2.inserir(10);
            arvore2.inserir(8);
            arvore2.inserir(12);

            arvore1.inserir(20);
            arvore1.inserir(18);
            arvore1.inserir(25);
            arvore1.inserir(10);
            arvore1.inserir(12);
            arvore1.inserir(30);
            arvore1.inserir(27);
            arvore1.inserir(32);
            arvore1.inserir(5);

            arvore3.inserir(10);
            arvore3.inserir(15);
           // arvore3.inserir(8);
            arvore3.inserir(16);
            arvore3.imprimirArvore();
            arvore3.remover(16);
            Console.ReadLine();
            arvore3.imprimirArvore();
            Console.ReadLine();
            //Console.WriteLine("");
            //arvore1.imprimirArvore();
            //Console.WriteLine("");
            //arvore2.imprimirArvore();

            ////arvore1.remover(20);
            //arvore1.imprimirArvore();

            //Console.WriteLine("a altura da arvore é " + arvore3.altura());
            //Console.WriteLine("a sua arvore tem " + arvore1.numNoh() + " nó(s)"); ;
            Console.WriteLine("a sua arvore tem " + arvore3.numFol() + " folha(s)"); ;

            arvore5.inserir(5);
            arvore5.inserir(3);
            arvore5.inserir(7);

            arvore6.inserir(5);
            arvore6.inserir(3);
            arvore6.inserir(6);

            arvore5.imprimirArvore();
            Console.WriteLine("");
            arvore6.imprimirArvore();

            bool igual = saoiguais(arvore5, arvore6);
            if (igual)
            {
                Console.WriteLine("As árvores são iguais.");
            }
            else
            {
                Console.WriteLine("As árvores não são iguais.");
            }

            Console.Read();


        } // fim do Main()
    }
}
