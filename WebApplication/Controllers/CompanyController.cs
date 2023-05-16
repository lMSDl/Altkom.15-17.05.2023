using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    public class CompanyController : EntityController<Company>
    {
        public CompanyController(IService<Company> service) : base(service)
        {
        }
    }
}
