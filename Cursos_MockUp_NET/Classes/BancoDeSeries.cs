using System;
using System.Collections.Generic;
using BancoSeries.Interfaces;

namespace BancoSeries
{
    public class BancoDeSeries: IGerenciador<Serie>
    {
        List<Serie> series = new List<Serie>();
        int ultimoID = -1;
        public int Count => series.Count;

        public void CriarSerie(string nome, string descricao, string anoDeInicio, bool finalizada)
        {
            Serie novaSerie = new Serie(nome, descricao, anoDeInicio, finalizada);
            series.Add(novaSerie);
        }

        public void Adicionar(Serie serie)
        {
            series.Add(serie);
        }

        public void Excluir(int id)
        {
            if (id >= series.Count || id < 0)
            {
                return;
            }
            series.Remove(series[id]);
        }

        public Serie Selecionar(int id)
        {
            if(id >= series.Count || id < 0)
            {
                return null;
            }
          return series[id];
        }

        public void Limpar()
        {
          series.Clear();
        }

        public int PegarProximoID()
        {
          ultimoID++;
          return ultimoID;
        }

        public string[] Listar()
        {
            string[] retorno = new string[series.Count];
            for(int i = 0; i < series.Count; i++)
            {
                retorno[i] = series[i].ToString();
            }

            return retorno;
        }

        public string ListarSerie(int id)
        {
            if (id >= series.Count || id < 0)
            {
                return "";
            }

            return series[id].ToStringComDescricao();
        }
    }
}
