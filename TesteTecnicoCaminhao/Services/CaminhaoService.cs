using System.Collections.Generic;
using System.Linq;
using TesteTecnicoCaminhao.Interfaces;
using TesteTecnicoCaminhao.Models;

namespace TesteTecnicoCaminhao.Services
{
    public class CaminhaoService : ITesteTecnicoCaminhao
    {
        private readonly Contexto _context;
        //public CaminhaoService() => _context = new Contexto();

        public CaminhaoService(Contexto context)
        {
            _context = context;
        }

        public void Create(Caminhao entity)
        {
            _context.Caminhoes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Caminhao entity)
        {
            _context.Caminhoes.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Caminhao> GetAll()
        {
            return _context.Caminhoes.ToList();
        }

        public void Update(Caminhao entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public Caminhao GetById(int id)
        {
            if (id == 0)
                return new Caminhao();
            return _context.Caminhoes.Find(id);
        }
    }
}
