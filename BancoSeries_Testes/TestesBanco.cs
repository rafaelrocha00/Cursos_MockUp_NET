using System;
using Xunit;
using BancoSeries.Interfaces;
using BancoSeries;
using Moq;


namespace BancoSeries_Testes
{
    public class TestesBanco
    {
        Mock<BancoDeSeries> banco;
        public TestesBanco()
        {
            banco = new Mock<BancoDeSeries>();
        }

        [Fact]
        public void Adicionar_UmaSerie()
        {
            Serie serieNova = AdicionarSerieValida();

            banco.Object.Adicionar(serieNova);

            Assert.Equal(serieNova, banco.Object.Selecionar(0));
        }

        [Fact]
        public void Excluir_UmaSerie()
        {
            AdicionarSerieValida();
            AdicionarSerieValida();

            banco.Object.Excluir(0);

            Assert.Equal(1, banco.Object.Count);
        }

        [Fact]
        public void Listar_TodasAsSeries()
        {
            AdicionarSerieValida();
            AdicionarSerieValida();
            AdicionarSerieValida();

            string[] resultado = banco.Object.Listar();

            Assert.Equal(3, resultado.Length);
            Assert.NotEqual("", resultado[0]);
        }

        [Fact]
        public void Ler_UmaSerie()
        {
            Serie serieNova = AdicionarSerieValida();
            Serie resultado = banco.Object.Selecionar(0);

            Assert.NotNull(resultado);
            Assert.Equal(resultado, serieNova);
        }

        [Fact]
        public void ChecarIDs_ProximoId()
        {
            AdicionarSerieValida();

            Assert.Equal(0, banco.Object.PegarProximoID());
        }

        [Fact]
        public void ChecarListagem_UmaSerie()
        {
            Serie serieNova = AdicionarSerieValida();

            Assert.Equal(serieNova.ToStringComDescricao(), banco.Object.ListarSerie(0));
        }

        [Fact]
        public void ChecarListagem_SerieNaoExistente()
        {
            Assert.Equal("", banco.Object.ListarSerie(0));
        }

        public Serie AdicionarSerieValida()
        {
            Serie serieNova = new Serie("serie teste", "um teste", "2000", true);
            banco.Object.Adicionar(serieNova);
            return serieNova;
        }
    }
}
