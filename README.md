# ESFA-DC-DatabaseTesting

## Introduction

Provides a means of testing a database project using C#. Includes functionality to validate the schema of the created database objects against expected schema.

## Usage

In your test fixture (or other suitable place) setup the library:

```c#
string connectionString = ConfigurationManager.ConnectionStrings["Auditing"].ConnectionString;
IDbConnectorConfiguration dbConnectorConfiguration = new DbConnectorConfiguration(connectionString);
IDbConnector dbConnector = new DbConnector(dbConnectorConfiguration);
SchemaTests = new SchemaTests(dbConnector);
```

Add the SQL Client NuGet package 

```c#
System.Data.SqlClient
```

In your test project define the expected columns for the database table e.g.

```c#
ExpectedColumn[] expectedColumns = {
    new ExpectedColumn { OrdinalPosition = 1, ColumnName = "ID", DataType = "bigint", NumericPrecision = 19, NumericScale = 0, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 2, ColumnName = "JobId", DataType = "bigint", NumericPrecision = 19, NumericScale = 0, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 3, ColumnName = "DateTimeUtc", DataType = "datetime", DatetimePrecision = 3, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 4, ColumnName = "Filename", DataType = "nvarchar", CharacterMaximumLength = -1, IsNullable = "YES" },
    new ExpectedColumn { OrdinalPosition = 5, ColumnName = "Source", DataType = "nvarchar", CharacterMaximumLength = -1, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 6, ColumnName = "UserId", DataType = "nvarchar", CharacterMaximumLength = -1, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 7, ColumnName = "Event", DataType = "int", NumericPrecision = 10, NumericScale = 0, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 8, ColumnName = "ExtraInfo", DataType = "nvarchar", CharacterMaximumLength = -1, IsNullable = "NO" },
    new ExpectedColumn { OrdinalPosition = 9, ColumnName = "UkPrn", DataType = "nvarchar", CharacterMaximumLength = -1, IsNullable = "YES" }
};
```

Then validate that the database object matches the expected model.

```c#
_fixture.SchemaTests.AssertTableColumnsExist("dbo", "Audit", expectedColumns, true);
```

Optionally, it's possible to inversely check that columns don't exist (e.g. testing scenarios where columns are removed/replaced/renamed)

```c#
ExpectedColumn[] expectedColumns = {
    new ExpectedColumn { ColumnName = "xxxxxx" }
};
_fixture.SchemaTests.AssertTableColumnsExist("dbo", "Audit", expectedColumns, false);
```

