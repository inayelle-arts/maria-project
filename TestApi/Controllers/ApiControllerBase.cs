using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using TestApi.Controllers.Response;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        public CommandBase Command => RouteData.Values["command"] as CommandBase;

        public ResponseResultSet<Empty> InvalidCommand()
        {
            return new ResponseResultSet<Empty>()
            {
                Status = ResponseStatus.Failed,
                Message = "Invalid Command"
            };
        }

    }
}
