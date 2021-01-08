using System.Collections.Generic;
using TesteTecnicoCaminhao.Models;

namespace TesteTecnicoCaminhao.Interfaces
{
    public interface ITesteTecnicoCaminhao
    {
        void Create(Caminhao entity);
        void Delete(Caminhao entity);
        IEnumerable<Caminhao> GetAll();
        void Update(Caminhao entity);
    }
}
