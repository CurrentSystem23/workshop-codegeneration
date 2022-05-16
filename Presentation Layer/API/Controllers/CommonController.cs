using WorkshopTestProject.Common.Constants;
//using WorkshopTestProject.Common.Enums;
using WorkshopTestProject.Common.Interfaces;
//using WorkshopTestProject.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WorkshopTestProject.API.Controllers
{
  /// <summary>
  /// The <see cref="CommonController"/> class with API-functions related to courses.
  /// </summary>
  [Route("[controller]")]
  [ApiController]
  public class CommonController : ControllerBase
  {
    private readonly ILogic _logic;

    /// <summary>
    /// The constructor for the controller
    /// <param name="logic">The businesslogic interface</param>
    /// </summary>
    public CommonController(ILogic logic)
    {
      _logic = logic;
    }
  }
}