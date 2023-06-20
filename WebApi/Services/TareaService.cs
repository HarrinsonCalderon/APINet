using webapi;
using webapi.Models;

namespace WebApi.Services
{
    public class TareaService:ITareaService
    {
        TareasContext context;

        public TareaService(TareasContext tareasContext){
            context = tareasContext;
        }
        
        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }
        public async Task Save(Tarea tarea)
        {
            context.Add(tarea);
            await context.SaveChangesAsync();
        }
        public async Task Update(Guid Id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(Id);
            if (tareaActual != null)
            {
                tareaActual.Categoria = tarea.Categoria;
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.FechaCreacion = tarea.FechaCreacion;
                tareaActual.Resumen = tarea.Resumen;
                context.SaveChanges();
            }

        }
        public async Task Delete(Guid Id)
        {
            var tareaActual = context.Tareas.Find(Id);
            if (tareaActual != null)
            {
                context.Remove(tareaActual);
                context.SaveChanges();
            }

        }

    }
    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid Id, Tarea tarea);
        Task Delete(Guid Id);
    }
}
