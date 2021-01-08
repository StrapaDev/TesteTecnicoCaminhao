using System;
using System.Collections.Generic;
using System.Linq;
using TesteTecnicoCaminhao.Interfaces;
using TesteTecnicoCaminhao.Models;

namespace TesteTecnicoCaminhaoTest
{
    public class TesteTecnicoCaminhaoFake : ITesteTecnicoCaminhao
    {
        private readonly List<Caminhao> _caminhao;
        public TesteTecnicoCaminhaoFake()
        {
            _caminhao = new List<Caminhao>()
            {
                new Caminhao() { Id = 1, AnoFabricacao = 2021, AnoModelo = 2022, Modelo = "FM" },
                new Caminhao() { Id = 2, AnoFabricacao = 2021, AnoModelo = 2021, Modelo = "FH" },
                new Caminhao() { Id = 3, AnoFabricacao = 2021, AnoModelo = 2022, Modelo = "FM" },
                new Caminhao() { Id = 4, AnoFabricacao = 2021, AnoModelo = 2021, Modelo = "FH" },
                new Caminhao() { Id = 5, AnoFabricacao = 2021, AnoModelo = 2022, Modelo = "FM" }
            };
        }

        public IEnumerable<Caminhao> GetAll()
        {
            return _caminhao;
        }

        public Caminhao Create(Caminhao novoItem)
        {
            novoItem.Id = GeraId();
            _caminhao.Add(novoItem);
            return novoItem;
        }

        public Caminhao GetById(int id)
        {
            return _caminhao.Where(a => a.Id == id).FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var item = _caminhao.First(a => a.Id == id);
            _caminhao.Remove(item);
        }

        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

        void ITesteTecnicoCaminhao.Create(Caminhao entity)
        {
            entity.Id = GeraId();
            _caminhao.Add(entity);
        }

        public void Delete(Caminhao entity)
        {
            _caminhao.Remove(entity);
        }

        public void Update(Caminhao entity)
        {
            throw new NotImplementedException();
        }
    }
}
