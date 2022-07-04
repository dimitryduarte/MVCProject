using Moq;
using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProvaCandidato.Test.Repositories
{
    [Collection("Testing BaseRepository of web")]
    public class BaseRepositoryTest
    {
        public BaseRepositoryTest() { }

        [Theory]
        [InlineData(1, "Luke Skywalker", 1, true)]
        [InlineData(2, "Leia Organa", 2, false)]
        public void Should_Return_Success_GetClienteById(int Id, string nome, int cidadeId, bool ativo)
        {
            //Arrange
            var data = new List<Cliente> { new Cliente { Codigo = Id, Nome = nome, DataNascimento = DateTime.Now.AddDays(-10), CidadeId = cidadeId, Ativo = ativo } }.AsQueryable();

            var mockSet = new Mock<DbSet<Cliente>>();

            mockSet.As<IQueryable<Cliente>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ContextoPrincipal>();
            mockContext.Setup(m => m.Set<Cliente>()).Returns(mockSet.Object);

            var repository = new ClienteRepository(mockContext.Object);

            //Act
            var cliente = repository.GetById(Id);
            //ESSA VERSÃO DO MOQ NÃO FUNCIONA COM O FIND DO ENTITY 6 (TEM QUE USAR O WHERE)

            //Assert
            Assert.NotNull(cliente);
            Assert.Equal(Id, cliente.Codigo);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(cidadeId, cliente.CidadeId);
            Assert.Equal(ativo, cliente.Ativo);
        }

        [Theory]
        [InlineData(1, "São Paulo")]
        [InlineData(2, "Rio de Janeiro")]
        public void Should_Return_Success_GetCidadeById(int Id, string nome)
        {
            //Arrange
            var data = new List<Cidade> { new Cidade { Codigo = Id, Nome = nome } }.AsQueryable();

            var mockSet = new Mock<DbSet<Cidade>>();

            mockSet.As<IQueryable<Cidade>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cidade>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cidade>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cidade>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ContextoPrincipal>();
            mockContext.Setup(m => m.Set<Cidade>()).Returns(mockSet.Object);

            var repository = new BaseRepository<Cidade>(mockContext.Object);

            //Act
            var cidade = repository.GetById(Id);
            //ESSA VERSÃO DO MOQ NÃO FUNCIONA COM O FIND DO ENTITY 6 (TEM QUE USAR O WHERE)

            //Assert
            Assert.NotNull(cidade);
            Assert.Equal(Id, cidade.Codigo);
            Assert.Equal(nome, cidade.Nome);
        }

        [Theory]
        [InlineData(1, "Luke Skywalker", 1, true)]
        [InlineData(2, "Leia Organa", 2, false)]
        public void Should_Return_Success_GetAllCliente(int Id, string nome, int cidadeId, bool ativo)
        {
            //Arrange
            var data = new List<Cliente> { new Cliente { Codigo = Id, Nome = nome, DataNascimento = DateTime.Now.AddDays(-10), CidadeId = cidadeId, Ativo = ativo },
                                            new Cliente { Codigo = Id, Nome = nome, DataNascimento = DateTime.Now.AddDays(-10), CidadeId = cidadeId, Ativo = ativo },
                                            new Cliente { Codigo = Id, Nome = nome, DataNascimento = DateTime.Now.AddDays(-10), CidadeId = cidadeId, Ativo = ativo },
                                            new Cliente { Codigo = Id, Nome = nome, DataNascimento = DateTime.Now.AddDays(-10), CidadeId = cidadeId, Ativo = ativo },
                                            new Cliente { Codigo = Id, Nome = nome, DataNascimento = DateTime.Now.AddDays(-10), CidadeId = cidadeId, Ativo = ativo }}.AsQueryable();

            var mockSet = new Mock<DbSet<Cliente>>();

            mockSet.As<IQueryable<Cliente>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cliente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ContextoPrincipal>();
            mockContext.Setup(m => m.Set<Cliente>()).Returns(mockSet.Object);

            var repository = new BaseRepository<Cliente>(mockContext.Object);

            //Act
            var cliente = repository.GetAll();

            //Assert
            Assert.NotEmpty(cliente);
        }

        [Theory]
        [InlineData(1, "São Paulo")]
        [InlineData(2, "Rio de Janeiro")]
        public void Should_Return_Success_GetAllCidade(int Id, string nome)
        {
            //Arrange
            var data = new List<Cidade> { new Cidade { Codigo = Id, Nome = nome },
                                            new Cidade { Codigo = Id, Nome = nome },
                                            new Cidade { Codigo = Id, Nome = nome },
                                            new Cidade { Codigo = Id, Nome = nome },
                                            new Cidade { Codigo = Id, Nome = nome }}.AsQueryable();

            var mockSet = new Mock<DbSet<Cidade>>();

            mockSet.As<IQueryable<Cidade>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cidade>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cidade>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cidade>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ContextoPrincipal>();
            mockContext.Setup(m => m.Set<Cidade>()).Returns(mockSet.Object);

            var repository = new BaseRepository<Cidade>(mockContext.Object);

            //Act
            var cidade = repository.GetAll();

            //Assert
            Assert.NotEmpty(cidade);
        }
    }
}
