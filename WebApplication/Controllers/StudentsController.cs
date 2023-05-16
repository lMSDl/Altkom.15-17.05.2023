using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Inheritance;
using Services.Interfaces;

namespace Controllers
{
    public class StudentsController : EntityController<Student>
    {
        public StudentsController(IService<Student> service) : base(service)
        {
        }
    }
}
