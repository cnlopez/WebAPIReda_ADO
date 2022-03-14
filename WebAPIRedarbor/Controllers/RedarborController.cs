using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIRedarbor.BLL.Contracts;
using WebAPIRedarbor.Model;

namespace WebAPIRedarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedarborController : ControllerBase
    {
        private readonly IFunciones _funciones;
        public RedarborController(IFunciones funciones)
        {
            _funciones = funciones;
        }

        // GET: api/Redarbor
        [HttpGet]
        public ActionResult GetEmployee()
        {
            if (EmployeesExist())
            {
                return Ok(_funciones.GetEmployees());
            }
            else
            {
                return Ok("No existen empleados");
            }
        }

        // GET: api/Redarbor/5
        [HttpGet("{id}")]
        public ActionResult GetEmployee(int id)
        {
            if (EmployeeExists(id))
            {
                return Ok(_funciones.GetEmployee(id));
            }
            else
            {
                return Ok("El empleado no existe");
            }
        }

        // PUT: api/Redarbor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            _funciones.UpdateEmployee(id, employee);
            return Ok();
        }

        // POST: api/Redarbor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostEmployee(Employee employee)
        {
            _funciones.InsertEmployee(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Redarbor/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            _funciones.DeleteEmployee(id);
            return Ok();
        }
        private bool EmployeeExists(int id)
        {
            return _funciones.EmployeeExists(id);
        }
        private bool EmployeesExist()
        {
            return _funciones.EmployeesExist();
        }

    }
}
