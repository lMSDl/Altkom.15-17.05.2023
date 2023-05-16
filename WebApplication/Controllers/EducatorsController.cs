using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Inheritance;
using Services.Interfaces;

namespace Controllers
{
    public class EducatorsController : EntityController<Educator>
    {
        public EducatorsController(IService<Educator> service) : base(service)
        {
        }
    }
}
