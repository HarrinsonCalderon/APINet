using webapi;
using webapi.Models;

namespace WebApi.Services
{
    public class CategoriaService:ICategoriaService
    {
        TareasContext context;

        public CategoriaService(TareasContext dbcontext)
        {
            context= dbcontext;
        }
            


        public IEnumerable<Categoria> Get()
        {
               return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();    
        }
        public async Task Update(Guid Id, Categoria categoria)
        {
            var categoriaActual=context.Categorias.Find(Id);
            if (categoriaActual!=null)
            {
                categoriaActual.Nombre=categoria.Nombre;
                categoriaActual.Descripcion =categoria.Descripcion;
                categoriaActual.Peso    = categoria.Peso;
                context.SaveChanges();  
            }

        }
    public async Task Delete(Guid Id)
    {
        var categoriaActual = context.Categorias.Find(Id);
        if (categoriaActual != null)
        {
                context.Remove(categoriaActual);
            context.SaveChanges();
        }

    }
}
    }

    public interface ICategoriaService
    {
   
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid Id, Categoria categoria);
    Task Delete(Guid Id);

    }

