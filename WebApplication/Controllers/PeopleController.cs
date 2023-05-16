using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    public class PeopleController : EntityController<Person>
    {
        public PeopleController(IService<Person> service) : base(service)
        {
        }
    }
}
