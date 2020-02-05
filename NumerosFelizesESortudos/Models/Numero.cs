using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumerosFelizesESortudos.Models
{
    public class Numero
    {
        private int NumeroEscolhido;

        public string Classificacao
        {
            get
            {
                string retorno = "";

                if (IsNumeroSortudo(NumeroEscolhido))
                    retorno += "Número Sortudo ";
                else
                    retorno += "Número NÃO-sortudo ";

                if (IsNumeroFeliz(NumeroEscolhido))
                    retorno += " e Feliz!";
                else
                    retorno += "e NÃO-feliz.";                
                
                return retorno;
            }
        }   

        public Numero(int numeroEscolhido)
        {
            NumeroEscolhido = numeroEscolhido;
        }


        public bool IsNumeroFeliz(int numero)
        {
            List<int> numerosSeparados = new List<int>();
            int numeroDividir = numero;            

            for (int i=1; i <= 100; i++)
            {
                numerosSeparados = SepararNumeros(numeroDividir);
                numerosSeparados = GetPotenciaNumerosList(numerosSeparados);

                numeroDividir = SomarNumerosByArray(numerosSeparados);

                if (numeroDividir == 1)
                    return true;
            }

            return false;
        }

        private List<int> SepararNumeros(int numero)
        {
            List<int> numerosSeparados = new List<int>();

            char[] numeros = numero.ToString().ToCharArray();

            foreach(char n in numeros)
            {
                int numParse = Int32.Parse(n.ToString());
                numerosSeparados.Add(numParse);
            }

            return numerosSeparados;
        }

        private int SomarNumerosByArray(List<int> numerosSeparados)
        {
            int soma = 0;

            foreach (int numero in numerosSeparados)
            {
                soma += numero;
            }

            return soma;
        }

        private List<int> GetPotenciaNumerosList(List<int> numerosSeparados)
        {
            List<int> retorno = new List<int>();

            foreach(int numero in numerosSeparados)
            {
                int potencia = numero * numero;
                retorno.Add(potencia);
            }

            return retorno; 
        }

        public bool IsNumeroSortudo(int numero)
        {
            if (numero%2 == 0)
                return false;

            //Para a lista de comparacao ter o tamanho adequado a cada numero;
            List<int> numerosParaVerificacao = NumerosAteONumeroEscolhido(numero);

            List<int> numerosSortudos = GetNumerosSortudos(numerosParaVerificacao);

            if (numerosSortudos.Contains(numero))
                return true;

            return false;
        }

        private List<int> GetNumerosSortudos(List<int> numerosParaVerificacao)
        {
            List<int> aux = new List<int>();

            foreach(int num in numerosParaVerificacao)
            {
                if (num % 2 != 0) //excluir os pares
                    aux.Add(num); 
            }

            int cont = 1;
            int numBase = aux[cont];

            while (aux.Count >= numBase) 
            {
                numerosParaVerificacao = new List<int>();

                for(int i=0; i<aux.Count; i++)
                {
                    if ((i+1) % numBase != 0) 
                        numerosParaVerificacao.Add(aux[i]);
                }

                aux = numerosParaVerificacao;
                
                numBase = aux[++cont];
            }

            return numerosParaVerificacao;
        }

        private List<int> NumerosAteONumeroEscolhido(int numero)
        {
            List<int> retorno = new List<int>();

            for (int i=1; i <= numero; i++)
            {
                retorno.Add(i);
            }

            return retorno;
        }
    }
}
