using Microsoft.AspNetCore.Mvc;

//aqui llamo al contexto de la base de datos y al modelo empleado
using AppCrudMvc.Data;
using AppCrudMvc.Models;
using Microsoft.EntityFrameworkCore;


namespace AppCrudMvc.Controllers
{
    public class EmpleadoController : Controller
    {
        //aqui creo una variable de tipo AppDBContext para poder acceder a la base de datos
        private readonly AppDBContext _appDBContext;

        //aqui creo el constructor de la clase que recibe el contexto de la base de datos
        public EmpleadoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }


        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            //aqui obtengo la lista de empleados de la base de datos
            List<Empleado> lista = await _appDBContext.Empleados.ToListAsync();
            //aqui retorno la vista con la lista de empleados
            return View(lista);
        }
    }
}
