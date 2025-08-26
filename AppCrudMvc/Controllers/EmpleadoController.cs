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
        //cuando tengo el motedo le doy en el nombre del metodo click derecho agregar vista, vista de razon vacia


        [HttpGet]
        public IActionResult Nuevo()
        {
           
            //aqui retorno la vista con la lista de empleados
            return View();
        }
        //esto lo que realiza es guardar el empleado en la base de datos

        [HttpPost]
        public async Task <IActionResult> Nuevo(Empleado empleado)
        {
            await _appDBContext.Empleados.AddAsync(empleado);
            await _appDBContext.SaveChangesAsync();
            //aqui retorno la vista con la lista de empleados
            return RedirectToAction(nameof(Lista));
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int Id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == Id);

            //aqui retorno la vista con la lista de empleados
            return View(empleado);
        }

        //esto lo que realiza es editar el empleado en la base de datos
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
             _appDBContext.Empleados.Update(empleado);
            await _appDBContext.SaveChangesAsync();
            //aqui retorno la vista con la lista de empleados
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int Id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == Id);

            _appDBContext.Empleados.Remove(empleado);
            await _appDBContext.SaveChangesAsync();
            //aqui retorno la vista con la lista de empleados
            return RedirectToAction(nameof(Lista));
        }


    }
}
