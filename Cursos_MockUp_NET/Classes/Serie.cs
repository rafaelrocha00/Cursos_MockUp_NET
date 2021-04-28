using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSeries
{
    public class Serie: Identificavel
    {
       string nome;
       string descricao;
       string anoDeInicio;
       bool finalizada;
       bool excluida;

        public Serie(string nome, string descricao, string anoDeInicio, bool finalizada)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.anoDeInicio = anoDeInicio;
            this.finalizada = finalizada;
        }

        public override string ToString()
        {
            string finalizadaS = finalizada ? "Finalizada" : "Em andamento";
            string final = $"#{id} | {nome} | {finalizadaS}";
            return final;
        }

        public string ToStringComDescricao()
        {
            string finalizadaS = finalizada ? "Finalizada" : "Em andamento";
            string final = $"#{nome} | {anoDeInicio} | {finalizadaS}";
            final += Environment.NewLine;
            final += descricao;
            return final;
        }
    }
}
