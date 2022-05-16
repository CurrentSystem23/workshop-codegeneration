using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using WorkshopTestProject.Common.DTOs;

namespace WorkshopTestProject.DataAccess.SQL.BaseClasses
{
  public class Dao
  {
    public virtual bool BeforeSave(SqlConnection connection, SqlCommand command, IDtoBase dto)
    {
      return true;
    }
    public virtual bool AfterSave(SqlConnection connection, SqlCommand command, IDtoBase dto)
    {
      return true;
    }
  }
}


