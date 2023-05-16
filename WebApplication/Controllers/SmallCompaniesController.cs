using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Inheritance;
using Services.Interfaces;

namespace Controllers
{
    public class SmallCompaniesController : EntityController<SmallCompany>
    {
        public SmallCompaniesController(IService<SmallCompany> service) : base(service)
        {
        }
    }
}
