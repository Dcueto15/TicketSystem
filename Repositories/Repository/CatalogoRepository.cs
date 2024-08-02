using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketSystem.Models;
using TicketSystem.Repositories.IRepository;

namespace TicketSystem.Data.Repositories
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Catalogo>> GetAllCatalogosAsync()
        {
            try
            {
                return await _context.Catalogos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve catalogs", ex);
            }
        }

        public async Task<Catalogo> GetCatalogoByIdAsync(int id)
        {
            try
            {
                var catalogo = await _context.Catalogos.FindAsync(id);
                if (catalogo == null)
                    throw new KeyNotFoundException("Catalog not found");
                return catalogo;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve catalog", ex);
            }
        }

        public async Task AddCatalogoAsync(Catalogo catalogo)
        {
            try
            {
                await _context.Catalogos.AddAsync(catalogo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add catalog", ex);
            }
        }

        public async Task UpdateCatalogoAsync(Catalogo catalogo)
        {
            try
            {
                _context.Catalogos.Update(catalogo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update catalog", ex);
            }
        }


        public async Task DeleteCatalogoAsync(int id)
        {
            try
            {
                var catalogo = await GetCatalogoByIdAsync(id);
                if (catalogo == null)
                    throw new KeyNotFoundException("Catalog to delete not found");

                _context.Catalogos.Remove(catalogo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete catalog", ex);
            }
        }
    }
}