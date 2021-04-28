using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSeries.Interfaces
{
    public interface IGerenciador<T>
    {
        void Adicionar(T item);
        void Excluir(int id);
        T Selecionar(int id);  
        void Limpar();
        int PegarProximoID();

        string[] Listar();
    }
}
