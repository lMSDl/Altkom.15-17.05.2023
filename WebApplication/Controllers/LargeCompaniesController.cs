using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Inheritance;
using Services.Interfaces;

namespace Controllers
{
    public class LargeCompaniesController : EntityController<LargeCompany>
    {
        public LargeCompaniesController(IService<LargeCompany> service) : base(service)
        {
        }
    }
}
