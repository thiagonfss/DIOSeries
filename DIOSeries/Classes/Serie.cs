using DIOSeries.Enum;
using System;

namespace DIOSeries.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        //Metodo (Constructor)
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            //Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline
            // o environment basicamente identifica qual o sistem operacional está 
            //utilizando e insere a quebra de linha automaticamente.
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano;
            retorno += "Excluído: : " + this.Excluido;
            return retorno;

        }

        //encapsulamentos: 
        //retornaTitulo ele retona o titulo do objeto
        //retornaId
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        internal int retornaId()
        {
            return this.Id;
        }

        public void excluir()
        {
            this.Excluido = true;
        }
    }
}
