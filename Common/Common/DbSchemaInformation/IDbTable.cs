namespace WorkshopTestProject.Common.DbSchemaInformation
{
  public interface IDbTable
  {
    string TableName { get; }
    string FullName { get; }
  }
}
