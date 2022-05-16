namespace WorkshopTestProject.Common.DbSchemaInformation
{
  public interface IDbColumn
  {
    string ColumnName { get; }
    string FullName { get; }
  }
}
