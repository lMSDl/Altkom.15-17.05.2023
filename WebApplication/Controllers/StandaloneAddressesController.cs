using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace Controllers
{
    public class StandaloneAddressesController : EntityController<StandaloneAddress>
    {
        public StandaloneAddressesController(IService<StandaloneAddress> service) : base(service)
        {
        }
    }
}
