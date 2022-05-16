namespace WorkshopTestProject.Common.DbSchemaInformation
{
  public static class WorkshopTestProjectDb
  {
    #region core
    public static SchemacoreClass core => new SchemacoreClass(nameof(WorkshopTestProjectDb));
    public class SchemacoreClass : IDbSchema
    {
      public string SchemaName { get; }
      public string FullName { get; }
      public SchemacoreClass(string owner)
      {
        SchemaName = "core";
        FullName = $"{owner}.{SchemaName}";
      }
      public override string ToString()
      {
        return FullName;
      }
      public TableCountryClass Country => new TableCountryClass(FullName);
      public class TableCountryClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableCountryClass(string owner)
        {
          TableName = "Country";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnCountryClass Country => new ColumnCountryClass(FullName);
        public class ColumnCountryClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnCountryClass(string owner)
          {
            ColumnName = "Country";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnCountryKeyClass CountryKey => new ColumnCountryKeyClass(FullName);
        public class ColumnCountryKeyClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnCountryKeyClass(string owner)
          {
            ColumnName = "CountryKey";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnCurrencyIdClass CurrencyId => new ColumnCurrencyIdClass(FullName);
        public class ColumnCurrencyIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnCurrencyIdClass(string owner)
          {
            ColumnName = "CurrencyId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableCurrencyClass Currency => new TableCurrencyClass(FullName);
      public class TableCurrencyClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableCurrencyClass(string owner)
        {
          TableName = "Currency";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnIsoClass Iso => new ColumnIsoClass(FullName);
        public class ColumnIsoClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIsoClass(string owner)
          {
            ColumnName = "Iso";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnCurrencyClass Currency => new ColumnCurrencyClass(FullName);
        public class ColumnCurrencyClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnCurrencyClass(string owner)
          {
            ColumnName = "Currency";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnCurrencyPartsClass CurrencyParts => new ColumnCurrencyPartsClass(FullName);
        public class ColumnCurrencyPartsClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnCurrencyPartsClass(string owner)
          {
            ColumnName = "CurrencyParts";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnRegionClass Region => new ColumnRegionClass(FullName);
        public class ColumnRegionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnRegionClass(string owner)
          {
            ColumnName = "Region";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableDomainTypeClass DomainType => new TableDomainTypeClass(FullName);
      public class TableDomainTypeClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableDomainTypeClass(string owner)
        {
          TableName = "DomainType";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnTypeClass Type => new ColumnTypeClass(FullName);
        public class ColumnTypeClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnTypeClass(string owner)
          {
            ColumnName = "Type";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDescriptionClass Description => new ColumnDescriptionClass(FullName);
        public class ColumnDescriptionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDescriptionClass(string owner)
          {
            ColumnName = "Description";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModeClass Mode => new ColumnModeClass(FullName);
        public class ColumnModeClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModeClass(string owner)
          {
            ColumnName = "Mode";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnStandardIdClass StandardId => new ColumnStandardIdClass(FullName);
        public class ColumnStandardIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnStandardIdClass(string owner)
          {
            ColumnName = "StandardId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnEditableClass Editable => new ColumnEditableClass(FullName);
        public class ColumnEditableClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnEditableClass(string owner)
          {
            ColumnName = "Editable";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableDomainValueClass DomainValue => new TableDomainValueClass(FullName);
      public class TableDomainValueClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableDomainValueClass(string owner)
        {
          TableName = "DomainValue";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnTypeIdClass TypeId => new ColumnTypeIdClass(FullName);
        public class ColumnTypeIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnTypeIdClass(string owner)
          {
            ColumnName = "TypeId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnValueCClass ValueC => new ColumnValueCClass(FullName);
        public class ColumnValueCClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnValueCClass(string owner)
          {
            ColumnName = "ValueC";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnValueNClass ValueN => new ColumnValueNClass(FullName);
        public class ColumnValueNClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnValueNClass(string owner)
          {
            ColumnName = "ValueN";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnValueDClass ValueD => new ColumnValueDClass(FullName);
        public class ColumnValueDClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnValueDClass(string owner)
          {
            ColumnName = "ValueD";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnValueFClass ValueF => new ColumnValueFClass(FullName);
        public class ColumnValueFClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnValueFClass(string owner)
          {
            ColumnName = "ValueF";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDivIdClass DivId => new ColumnDivIdClass(FullName);
        public class ColumnDivIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDivIdClass(string owner)
          {
            ColumnName = "DivId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDescriptionClass Description => new ColumnDescriptionClass(FullName);
        public class ColumnDescriptionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDescriptionClass(string owner)
          {
            ColumnName = "Description";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnUnitClass Unit => new ColumnUnitClass(FullName);
        public class ColumnUnitClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnUnitClass(string owner)
          {
            ColumnName = "Unit";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnTenantIdClass TenantId => new ColumnTenantIdClass(FullName);
        public class ColumnTenantIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnTenantIdClass(string owner)
          {
            ColumnName = "TenantId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableProductClass Product => new TableProductClass(FullName);
      public class TableProductClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableProductClass(string owner)
        {
          TableName = "Product";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnProductNameClass ProductName => new ColumnProductNameClass(FullName);
        public class ColumnProductNameClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnProductNameClass(string owner)
          {
            ColumnName = "ProductName";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPriceClass Price => new ColumnPriceClass(FullName);
        public class ColumnPriceClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPriceClass(string owner)
          {
            ColumnName = "Price";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableStockClass Stock => new TableStockClass(FullName);
      public class TableStockClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableStockClass(string owner)
        {
          TableName = "Stock";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnProductIdClass ProductId => new ColumnProductIdClass(FullName);
        public class ColumnProductIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnProductIdClass(string owner)
          {
            ColumnName = "ProductId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnQuantityClass Quantity => new ColumnQuantityClass(FullName);
        public class ColumnQuantityClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnQuantityClass(string owner)
          {
            ColumnName = "Quantity";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableTenantClass Tenant => new TableTenantClass(FullName);
      public class TableTenantClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableTenantClass(string owner)
        {
          TableName = "Tenant";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnTenantNameClass TenantName => new ColumnTenantNameClass(FullName);
        public class ColumnTenantNameClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnTenantNameClass(string owner)
          {
            ColumnName = "TenantName";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDescriptionClass Description => new ColumnDescriptionClass(FullName);
        public class ColumnDescriptionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDescriptionClass(string owner)
          {
            ColumnName = "Description";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableUserClass User => new TableUserClass(FullName);
      public class TableUserClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableUserClass(string owner)
        {
          TableName = "User";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnTenantIdClass TenantId => new ColumnTenantIdClass(FullName);
        public class ColumnTenantIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnTenantIdClass(string owner)
          {
            ColumnName = "TenantId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnLoginClass Login => new ColumnLoginClass(FullName);
        public class ColumnLoginClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnLoginClass(string owner)
          {
            ColumnName = "Login";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPasswordClass Password => new ColumnPasswordClass(FullName);
        public class ColumnPasswordClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPasswordClass(string owner)
          {
            ColumnName = "Password";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPasswordSaltClass PasswordSalt => new ColumnPasswordSaltClass(FullName);
        public class ColumnPasswordSaltClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPasswordSaltClass(string owner)
          {
            ColumnName = "PasswordSalt";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnEmailClass Email => new ColumnEmailClass(FullName);
        public class ColumnEmailClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnEmailClass(string owner)
          {
            ColumnName = "Email";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnStateClass State => new ColumnStateClass(FullName);
        public class ColumnStateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnStateClass(string owner)
          {
            ColumnName = "State";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnFailedLoginCountClass FailedLoginCount => new ColumnFailedLoginCountClass(FullName);
        public class ColumnFailedLoginCountClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnFailedLoginCountClass(string owner)
          {
            ColumnName = "FailedLoginCount";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnLastLoginClass LastLogin => new ColumnLastLoginClass(FullName);
        public class ColumnLastLoginClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnLastLoginClass(string owner)
          {
            ColumnName = "LastLogin";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnLastPasswordChangeClass LastPasswordChange => new ColumnLastPasswordChangeClass(FullName);
        public class ColumnLastPasswordChangeClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnLastPasswordChangeClass(string owner)
          {
            ColumnName = "LastPasswordChange";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDomainLoginClass DomainLogin => new ColumnDomainLoginClass(FullName);
        public class ColumnDomainLoginClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDomainLoginClass(string owner)
          {
            ColumnName = "DomainLogin";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnBusinessPartnerIdClass BusinessPartnerId => new ColumnBusinessPartnerIdClass(FullName);
        public class ColumnBusinessPartnerIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnBusinessPartnerIdClass(string owner)
          {
            ColumnName = "BusinessPartnerId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnConditionsIdClass ConditionsId => new ColumnConditionsIdClass(FullName);
        public class ColumnConditionsIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnConditionsIdClass(string owner)
          {
            ColumnName = "ConditionsId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnConditionsFixedClass ConditionsFixed => new ColumnConditionsFixedClass(FullName);
        public class ColumnConditionsFixedClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnConditionsFixedClass(string owner)
          {
            ColumnName = "ConditionsFixed";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPrivacyPolicyIdClass PrivacyPolicyId => new ColumnPrivacyPolicyIdClass(FullName);
        public class ColumnPrivacyPolicyIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPrivacyPolicyIdClass(string owner)
          {
            ColumnName = "PrivacyPolicyId";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPrivacyPolicyFixedClass PrivacyPolicyFixed => new ColumnPrivacyPolicyFixedClass(FullName);
        public class ColumnPrivacyPolicyFixedClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPrivacyPolicyFixedClass(string owner)
          {
            ColumnName = "PrivacyPolicyFixed";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPasswordLinkExtensionClass PasswordLinkExtension => new ColumnPasswordLinkExtensionClass(FullName);
        public class ColumnPasswordLinkExtensionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPasswordLinkExtensionClass(string owner)
          {
            ColumnName = "PasswordLinkExtension";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPasswordDateOfExpiryClass PasswordDateOfExpiry => new ColumnPasswordDateOfExpiryClass(FullName);
        public class ColumnPasswordDateOfExpiryClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPasswordDateOfExpiryClass(string owner)
          {
            ColumnName = "PasswordDateOfExpiry";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnNewEmailClass NewEmail => new ColumnNewEmailClass(FullName);
        public class ColumnNewEmailClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnNewEmailClass(string owner)
          {
            ColumnName = "NewEmail";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnEmailLinkExtensionClass EmailLinkExtension => new ColumnEmailLinkExtensionClass(FullName);
        public class ColumnEmailLinkExtensionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnEmailLinkExtensionClass(string owner)
          {
            ColumnName = "EmailLinkExtension";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnEmailDateOfExpiryClass EmailDateOfExpiry => new ColumnEmailDateOfExpiryClass(FullName);
        public class ColumnEmailDateOfExpiryClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnEmailDateOfExpiryClass(string owner)
          {
            ColumnName = "EmailDateOfExpiry";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableUserGroupClass UserGroup => new TableUserGroupClass(FullName);
      public class TableUserGroupClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableUserGroupClass(string owner)
        {
          TableName = "UserGroup";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnGroupClass Group => new ColumnGroupClass(FullName);
        public class ColumnGroupClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnGroupClass(string owner)
          {
            ColumnName = "Group";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDescriptionClass Description => new ColumnDescriptionClass(FullName);
        public class ColumnDescriptionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDescriptionClass(string owner)
          {
            ColumnName = "Description";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableUserRightClass UserRight => new TableUserRightClass(FullName);
      public class TableUserRightClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableUserRightClass(string owner)
        {
          TableName = "UserRight";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnRightClass Right => new ColumnRightClass(FullName);
        public class ColumnRightClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnRightClass(string owner)
          {
            ColumnName = "Right";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDescriptionClass Description => new ColumnDescriptionClass(FullName);
        public class ColumnDescriptionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDescriptionClass(string owner)
          {
            ColumnName = "Description";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableUserRightsRoleClass UserRightsRole => new TableUserRightsRoleClass(FullName);
      public class TableUserRightsRoleClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableUserRightsRoleClass(string owner)
        {
          TableName = "UserRightsRole";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedDateClass ModifiedDate => new ColumnModifiedDateClass(FullName);
        public class ColumnModifiedDateClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedDateClass(string owner)
          {
            ColumnName = "ModifiedDate";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnModifiedUserClass ModifiedUser => new ColumnModifiedUserClass(FullName);
        public class ColumnModifiedUserClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnModifiedUserClass(string owner)
          {
            ColumnName = "ModifiedUser";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnRoleClass Role => new ColumnRoleClass(FullName);
        public class ColumnRoleClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnRoleClass(string owner)
          {
            ColumnName = "Role";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnDescriptionClass Description => new ColumnDescriptionClass(FullName);
        public class ColumnDescriptionClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnDescriptionClass(string owner)
          {
            ColumnName = "Description";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableProductsInStockClass ProductsInStock => new TableProductsInStockClass(FullName);
      public class TableProductsInStockClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableProductsInStockClass(string owner)
        {
          TableName = "ProductsInStock";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnProductNameClass ProductName => new ColumnProductNameClass(FullName);
        public class ColumnProductNameClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnProductNameClass(string owner)
          {
            ColumnName = "ProductName";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPriceClass Price => new ColumnPriceClass(FullName);
        public class ColumnPriceClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPriceClass(string owner)
          {
            ColumnName = "Price";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnQuantityClass Quantity => new ColumnQuantityClass(FullName);
        public class ColumnQuantityClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnQuantityClass(string owner)
          {
            ColumnName = "Quantity";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableProductInStockClass ProductInStock => new TableProductInStockClass(FullName);
      public class TableProductInStockClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableProductInStockClass(string owner)
        {
          TableName = "ProductInStock";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnProductNameClass ProductName => new ColumnProductNameClass(FullName);
        public class ColumnProductNameClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnProductNameClass(string owner)
          {
            ColumnName = "ProductName";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPriceClass Price => new ColumnPriceClass(FullName);
        public class ColumnPriceClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPriceClass(string owner)
          {
            ColumnName = "Price";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnQuantityClass Quantity => new ColumnQuantityClass(FullName);
        public class ColumnQuantityClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnQuantityClass(string owner)
          {
            ColumnName = "Quantity";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
      public TableSpecialProductsClass SpecialProducts => new TableSpecialProductsClass(FullName);
      public class TableSpecialProductsClass : IDbTable
      {
        public string TableName { get; }
        public string FullName { get; }
        public TableSpecialProductsClass(string owner)
        {
          TableName = "SpecialProducts";
          FullName = $"{owner}.{TableName}";
        }
        public override string ToString()
        {
          return FullName;
        }
        public ColumnIdClass Id => new ColumnIdClass(FullName);
        public class ColumnIdClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnIdClass(string owner)
          {
            ColumnName = "Id";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnProductNameClass ProductName => new ColumnProductNameClass(FullName);
        public class ColumnProductNameClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnProductNameClass(string owner)
          {
            ColumnName = "ProductName";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
        public ColumnPriceClass Price => new ColumnPriceClass(FullName);
        public class ColumnPriceClass : IDbColumn
        {
          public string ColumnName { get; }
          public string FullName { get; }
          public ColumnPriceClass(string owner)
          {
            ColumnName = "Price";
            FullName = $"{owner}.{ColumnName}";
          }
          public override string ToString()
          {
            return FullName;
          }
        }
      }
    }
    #endregion
  }
}


