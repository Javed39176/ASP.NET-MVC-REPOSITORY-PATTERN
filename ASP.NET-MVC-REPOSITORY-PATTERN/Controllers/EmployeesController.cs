using System.Net;
using System.Web.Mvc;
using ASP.NET_MVC_REPOSITORY_PATTERN.Models;
using ASP.NET_MVC_REPOSITORY_PATTERN.DAL;

namespace ASP.NET_MVC_REPOSITORY_PATTERN.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employyeRepository;
        public EmployeesController()
        {
            this._employyeRepository = new EmployeeRepository(new MyDatabaseEntities());
        }
        public EmployeesController(IEmployeeRepository employyeRepository)
        {
            this._employyeRepository = employyeRepository;
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View(_employyeRepository.GetEmployees());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employyeRepository.GetEmployeeByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employyeRepository.InsertEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employyeRepository.GetEmployeeByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "EmployeeId,EmpCode,EmpName,EmpGender,EmpCountry")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employyeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employyeRepository.GetEmployeeByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employyeRepository.DeleteEmployee((int)id);
            return RedirectToAction("Index");
        }
    }
}
