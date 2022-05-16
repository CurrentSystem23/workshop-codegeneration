using WorkshopTestProject.Common.DataAccess.Interfaces.Ado;
using WorkshopTestProject.Common.DTOs.core;
using WorkshopTestProject.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WorkshopTestProject.BusinessLogic
{
  /// <summary>
  /// The <see cref="BusinessLogic"/> class. Implements the <see cref="ILogic"/> interface.
  /// </summary>
  internal partial class Logic : ILogic
  {
    private readonly IDataAccess _dataAccess;
    private readonly ILogger<Logic> _logger;
    private readonly IMapper _mapper;


    public Logic(IDataAccess dataAccess, IMapper mapper)
    {
      _logger = null;
      _dataAccess = dataAccess;
      _mapper = mapper;
    }
  }
}
