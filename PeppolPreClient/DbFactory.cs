using System;
using System.Data;

namespace X.Data.DB
{
    // Aliases
    using XrDbConnection = System.Data.SqlClient.SqlConnection;
    using XrDbType = System.Data.SqlDbType;
    using XrDbCommand = System.Data.SqlClient.SqlCommand;
    using XrDbParameter = System.Data.SqlClient.SqlParameter;
    using XrDbDataReader = System.Data.SqlClient.SqlDataReader;
    using XrDbDataAdapter = System.Data.SqlClient.SqlDataAdapter;
    using System.Collections.Generic;

    /// <summary>
    /// Data Types
    /// </summary>
    public enum XDbType
    {
        BigInt = System.Data.SqlDbType.BigInt,
        Binary = System.Data.SqlDbType.Binary,
        Bit = System.Data.SqlDbType.Bit,
        Char = System.Data.SqlDbType.Char,
        DateTime = System.Data.SqlDbType.DateTime,
        Decimal = System.Data.SqlDbType.Decimal,
        Float = System.Data.SqlDbType.Float,
        Image = System.Data.SqlDbType.Image,
        Int = System.Data.SqlDbType.Int,
        Money = System.Data.SqlDbType.Money,
        NChar = System.Data.SqlDbType.NChar,
        NText = System.Data.SqlDbType.NText,
        NVarChar = System.Data.SqlDbType.NVarChar,
        Real = System.Data.SqlDbType.Real,
        SmallDateTime = System.Data.SqlDbType.SmallDateTime,
        SmallInt = System.Data.SqlDbType.SmallInt,
        SmallMoney = System.Data.SqlDbType.SmallMoney,
        Text = System.Data.SqlDbType.Text,
        Timestamp = System.Data.SqlDbType.Timestamp,
        TinyInt = System.Data.SqlDbType.TinyInt,
        UniqueIdentifier = System.Data.SqlDbType.UniqueIdentifier,
        VarBinary = System.Data.SqlDbType.VarBinary,
        VarChar = System.Data.SqlDbType.VarChar,
        Variant = System.Data.SqlDbType.Variant
    }

    /// <summary>
    /// SQL Specific Data Types
    /// </summary>
    public enum XSqlClientType
    {
        BigInt = System.Data.SqlDbType.BigInt,
        Binary = System.Data.SqlDbType.Binary,
        Bit = System.Data.SqlDbType.Bit,
        Char = System.Data.SqlDbType.Char,
        DateTime = System.Data.SqlDbType.DateTime,
        Decimal = System.Data.SqlDbType.Decimal,
        Float = System.Data.SqlDbType.Float,
        Image = System.Data.SqlDbType.Image,
        Int = System.Data.SqlDbType.Int,
        Money = System.Data.SqlDbType.Money,
        NChar = System.Data.SqlDbType.NChar,
        NText = System.Data.SqlDbType.NText,
        NVarChar = System.Data.SqlDbType.NVarChar,
        Real = System.Data.SqlDbType.Real,
        SmallDateTime = System.Data.SqlDbType.SmallDateTime,
        SmallInt = System.Data.SqlDbType.SmallInt,
        SmallMoney = System.Data.SqlDbType.SmallMoney,
        Text = System.Data.SqlDbType.Text,
        Timestamp = System.Data.SqlDbType.Timestamp,
        TinyInt = System.Data.SqlDbType.TinyInt,
        UniqueIdentifier = System.Data.SqlDbType.UniqueIdentifier,
        VarBinary = System.Data.SqlDbType.VarBinary,
        VarChar = System.Data.SqlDbType.VarChar,
        Variant = System.Data.SqlDbType.Variant
    }

    /// <summary>
    /// OLE DB Specific Data Types
    /// </summary>
    public enum XOleDbType
    {
        BigInt = System.Data.OleDb.OleDbType.BigInt,
        Binary = System.Data.OleDb.OleDbType.Binary,
        Boolean = System.Data.OleDb.OleDbType.Boolean,
        BSTR = System.Data.OleDb.OleDbType.BSTR,
        Char = System.Data.OleDb.OleDbType.Char,
        Currency = System.Data.OleDb.OleDbType.Currency,
        Date = System.Data.OleDb.OleDbType.Date,
        DBDate = System.Data.OleDb.OleDbType.DBDate,
        DBTime = System.Data.OleDb.OleDbType.DBTime,
        DBTimeStamp = System.Data.OleDb.OleDbType.DBTimeStamp,
        Decimal = System.Data.OleDb.OleDbType.Decimal,
        Double = System.Data.OleDb.OleDbType.Double,
        Empty = System.Data.OleDb.OleDbType.Empty,
        Error = System.Data.OleDb.OleDbType.Error,
        Filetime = System.Data.OleDb.OleDbType.Filetime,
        Guid = System.Data.OleDb.OleDbType.Guid,
        IDispatch = System.Data.OleDb.OleDbType.IDispatch,
        Integer = System.Data.OleDb.OleDbType.Integer,
        IUnknown = System.Data.OleDb.OleDbType.IUnknown,
        LongVarBinary = System.Data.OleDb.OleDbType.LongVarBinary,
        LongVarChar = System.Data.OleDb.OleDbType.LongVarChar,
        LongVarWChar = System.Data.OleDb.OleDbType.LongVarWChar,
        Numeric = System.Data.OleDb.OleDbType.Numeric,
        PropVariant = System.Data.OleDb.OleDbType.PropVariant,
        Single = System.Data.OleDb.OleDbType.Single,
        SmallInt = System.Data.OleDb.OleDbType.SmallInt,
        TinyInt = System.Data.OleDb.OleDbType.TinyInt,
        UnsignedBigInt = System.Data.OleDb.OleDbType.UnsignedBigInt,
        UnsignedInt = System.Data.OleDb.OleDbType.UnsignedInt,
        UnsignedSmallInt = System.Data.OleDb.OleDbType.UnsignedSmallInt,
        UnsignedTinyInt = System.Data.OleDb.OleDbType.UnsignedTinyInt,
        VarBinary = System.Data.OleDb.OleDbType.VarBinary,
        VarChar = System.Data.OleDb.OleDbType.VarChar,
        Variant = System.Data.OleDb.OleDbType.Variant,
        VarNumeric = System.Data.OleDb.OleDbType.VarNumeric,
        VarWChar = System.Data.OleDb.OleDbType.VarWChar,
        WChar = System.Data.OleDb.OleDbType.WChar
    }


    /// <summary>
    /// Summary description for DbFactory.
    /// </summary>
    public class DbFactory
    {
        public DbFactory()
        {
        }

        static Dictionary<Type, X.Data.DB.XDbType> dTypeMap;
        static DbFactory()
        {
            dTypeMap = new Dictionary<Type, X.Data.DB.XDbType>();
            dTypeMap[typeof(int)] = X.Data.DB.XDbType.Int;
            dTypeMap[typeof(string)] = X.Data.DB.XDbType.NVarChar;
            dTypeMap[typeof(long)] = X.Data.DB.XDbType.BigInt;
            dTypeMap[typeof(bool)] = X.Data.DB.XDbType.Bit;
            dTypeMap[typeof(DateTime)] = X.Data.DB.XDbType.DateTime;
            dTypeMap[typeof(char)] = X.Data.DB.XDbType.NChar;
        }

        private static X.Data.DB.XDbType GetDbType(Type type)
        {
            X.Data.DB.XDbType xDbType;
            if (dTypeMap.TryGetValue(type, out xDbType))
            {
                return xDbType;
            }
            throw new NotSupportedException("Type : " + type.ToString() + " does not have a mapping.");
        }

        /// <summary>
        /// Returns a DataBase Connection
        /// </summary>
        /// <param name="sConnectionString">The Connection String</param>
        /// <returns>The DataBase Connection</returns>
        public static System.Data.IDbConnection GetConnection(string sConnectionString)
        {
            return new XrDbConnection(sConnectionString);
        }

        /// <summary>
        /// Returns an Initialized DataBase Stored Procedure Command
        /// </summary>
        /// <param name="sConnectionString">The Connection String</param>
        /// <param name="sCommandText">The Command Text</param>
        /// <returns>The Initialized Stored Procedure DataBase Command</returns>
        public static System.Data.IDbCommand GetCommand(string sConnectionString, string sCommandText)
        {
            XrDbCommand oCmd = new XrDbCommand();

            oCmd.Connection = (XrDbConnection)GetConnection(sConnectionString);
            oCmd.CommandText = sCommandText;
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;

            return oCmd;
        }

        /// <summary>
        /// Returns an Initialized DataBase Stored Procedure Command
        /// </summary>
        /// <param name="oConn">A DataBase Connection</param>
        /// <param name="sCommandText">The Command Text</param>
        /// <returns>The Initialized Stored Procedure DataBase Command</returns>
        public static System.Data.IDbCommand GetCommand(System.Data.IDbConnection oConn, string sCommandText)
        {
            XrDbCommand oCmd = new XrDbCommand();

            oCmd.Connection = (XrDbConnection)oConn;
            oCmd.CommandText = sCommandText;
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;

            return oCmd;
        }

        /// <summary>
        /// Returns an Initialized DataBase Function Command
        /// </summary>
        /// <param name="sConnectionString">The Connection String</param>
        /// <param name="sCommandText">Usually the DataBase Function Name</param>
        /// <param name="eReturnType">Return type</param>
        /// <param name="iLength">Return length</param>
        /// <returns>The DataBase Function Command</returns>
        public static System.Data.IDbCommand GetFunctionCommand(string sConnectionString, string sCommandText, X.Data.DB.XDbType eReturnType, int iLength)
        {
            System.Data.IDbCommand oFuncCmd = X.Data.DB.DbFactory.GetCommand(sConnectionString, sCommandText);
            X.Data.DB.DbFactory.AddParameter(oFuncCmd, "RETURN_VALUE", null, eReturnType, iLength, System.Data.ParameterDirection.ReturnValue);

            return oFuncCmd;
        }

        /// <summary>
        /// Executes a DataBase Function Command
        /// </summary>
        /// <param name="oFuncCmd">The DataBase Function Command</param>
        /// <returns>The DataBase Function Return Value</returns>
        public static object ExecFunctionCommand(System.Data.IDbCommand oFuncCmd)
        {
            try
            {
                oFuncCmd.Connection.Open();
                oFuncCmd.ExecuteNonQuery();
                oFuncCmd.Connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Failed to Execute DB function " + oFuncCmd.CommandText, e);
            }

            return X.Data.DB.DbFactory.GetParameterValue(oFuncCmd, "RETURN_VALUE");
        }


        /// <summary>
        /// Returns an Initialized DataBase Stored Procedure Command
        /// </summary>
        /// <param name="sConnectionString">The Connection String</param>
        /// <param name="sCommandText">The DataBase Stored Procedure</param>
        /// <returns>The DataBase Stored Procedure Command</returns>
        public static System.Data.IDbCommand GetProcedureCommand(string sConnectionString, string sCommandText)
        {
            System.Data.IDbCommand oCmd = X.Data.DB.DbFactory.GetCommand(sConnectionString, sCommandText);
            X.Data.DB.DbFactory.AddParameter(oCmd, "RETURN_VALUE", null, X.Data.DB.XDbType.Int, 4, System.Data.ParameterDirection.ReturnValue);

            // No timeout
            oCmd.CommandTimeout = 0;

            return oCmd;
        }

        /// <summary>
        /// Executes a DataBase Stored Procedure Command
        /// </summary>
        /// <param name="oFuncCmd">The DataBase Function Command</param>
        /// <returns>The DataBase Stored Procedure returns true or false</returns>
        public static bool ExecProcedureCommand(System.Data.IDbCommand oCmd)
        {
            long lRet = 0;
            bool bLocal = false;

            if (oCmd.Connection.State != System.Data.ConnectionState.Open)
            {
                oCmd.Connection.Open();
                bLocal = true;
            }

            oCmd.ExecuteNonQuery();

            if (bLocal)
                oCmd.Connection.Close();

            lRet = (int)X.Data.DB.DbFactory.GetParameterValue(oCmd, "RETURN_VALUE");

            if (lRet > 0)
                return false;

            return true;
        }

        /// <summary>
        /// Executes a DataBase Stored Procedure Command Scalar. Gets the first column of the first 
        /// row in the result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="oFuncCmd">The DataBase Function Command</param>
        /// <returns>The DataBase Stored Procedure returns true or false</returns>
        public static bool ExecProcedureCommandScalar(System.Data.IDbCommand oCmd, out object oScalar)
        {
            long lRet = 0;
            bool bLocal = false;

            if (oCmd.Connection.State != System.Data.ConnectionState.Open)
            {
                oCmd.Connection.Open();
                bLocal = true;
            }

            oScalar = oCmd.ExecuteScalar();

            if (bLocal)
                oCmd.Connection.Close();

            lRet = (int)X.Data.DB.DbFactory.GetParameterValue(oCmd, "RETURN_VALUE");

            if (lRet > 0)
                return false;

            return true;
        }

        /// <summary>
        /// The method returns a data reader. The user of this data reader has to call the method Close on the data reader interface when finished
        /// </summary>
        /// <param name="oCmd">The Database Command</param>
        /// <returns>The Database Data Reader</returns>
        public static System.Data.IDataReader ExecDataReader(System.Data.IDbCommand oCmd)
        {
            if (oCmd.Connection.State != System.Data.ConnectionState.Open)
            {
                oCmd.Connection.Open();
            }

            return oCmd.ExecuteReader();
        }

        /// <summary>
        /// Returns an Initialized DataAdapter
        /// </summary>
        /// <param name="sConnectionString">The Connection String</param>
        /// <param name="sCommandText">The Command Text</param>
        /// <param name="lUserID">The UserID</param>
        /// <param name="lOwnerID">The OwnerID</param>
        /// <param name="lLanguageID">The LanguageID</param>
        /// <param name="lRoleID">The RoleID</param>
        /// <returns>The Initialized DataAdapter</returns>
        public static System.Data.IDbDataAdapter GetListDbDataAdapter(string sConnectionString, string sCommandText, long lUserID, long lOwnerID, long lLanguageID, long lRoleID)
        {
            return GetListDbDataAdapter(GetConnection(sConnectionString), sCommandText, lUserID, lOwnerID, lLanguageID, lRoleID);
        }

        /// <summary>
        /// Returns an Initialized DataAdapter
        /// </summary>
        /// <param name="oConn">A DataBase Connection</param>
        /// <param name="sCommandText">The Command Text</param>
        /// <param name="lUserID">The UserID</param>
        /// <param name="lOwnerID">The OwnerID</param>
        /// <param name="lLanguageID">The LanguageID</param>
        /// <param name="lRoleID">The RoleID</param>
        /// <returns>The Initialized DataAdapter</returns>
        public static System.Data.IDbDataAdapter GetListDbDataAdapter(System.Data.IDbConnection oConn, string sCommandText, long lUserID, long lOwnerID, long lLanguageID, long lRoleID)
        {
            // Copied SelectCommand from generated AdoDataSetCommand (changed param values)
            XrDbDataAdapter oDataAdapter = new XrDbDataAdapter();
            XrDbCommand oCmd = new XrDbCommand();
            oCmd.Connection = (XrDbConnection)oConn;
            oCmd.CommandText = sCommandText;
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;

            AddStandardParameters(oCmd, lUserID, lOwnerID, lLanguageID, lRoleID);

            oDataAdapter.SelectCommand = oCmd;

            oDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {new System.Data.Common.DataTableMapping("Table", "List", new System.Data.Common.DataColumnMapping[] {new System.Data.Common.DataColumnMapping("l_value", "l_value"),
																																																   new System.Data.Common.DataColumnMapping("s_text", "s_text")})});
            return oDataAdapter;
        }

        /// <summary>
        /// Add your parameters in correct order by using this adapters (Select)Command in AddParameter and addSystemParameters
        /// </summary>
        /// <param name="sConnectionString"></param>
        /// <param name="sCommandText"></param>
        /// <param name="sTable"></param>
        /// <returns></returns>
        public static System.Data.IDbDataAdapter GetDbDataAdapter(string sConnectionString, string sCommandText, string sTable)
        {
            // Copied SelectCommand from generated AdoDataSetCommand (changed param values)
            XrDbDataAdapter daDataAdapter = new XrDbDataAdapter();
            XrDbCommand oCmd = new XrDbCommand();
            XrDbConnection oConn = (XrDbConnection)GetConnection(sConnectionString);
            oCmd.Connection = oConn;
            oCmd.CommandText = sCommandText;
            oCmd.CommandType = System.Data.CommandType.StoredProcedure;

            daDataAdapter.SelectCommand = oCmd;

            daDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", sTable) });

            return daDataAdapter;
        }

        /// <summary>
        /// Adds the standard parameters to the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="lUserID">The UserID</param>
        /// <param name="lOwnerID">The OwnerID</param>
        /// <param name="lLanguageID">The LanguageID</param>
        /// <param name="lRoleID">The RoleID</param>
        public static void AddStandardParameters(System.Data.IDbCommand oCmd, long lUserID, long lOwnerID, long lLanguageID, long lRoleID)
        {
            AddParameter(oCmd, "@prUser", lUserID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@prOwner", lOwnerID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@prLanguage", lLanguageID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@prRole", lRoleID, XDbType.BigInt, 8, ParameterDirection.Input);
        }

        /// <summary>
        /// Adds the standard parameters to the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="lUserID">The UserID</param>
        /// <param name="lOwnerID">The OwnerID</param>
        /// <param name="lLanguageID">The LanguageID</param>
        /// <param name="lRoleID">The RoleID</param>
        /// <param name="cOwnerSet">The OwnerSet</param>
        public static void AddStandardParameters(System.Data.IDbCommand oCmd, long lUserID, long lOwnerID, long lLanguageID, long lRoleID, char cOwnerSet)
        {
            AddParameter(oCmd, "@prUser", lUserID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@prOwner", lOwnerID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@prLanguage", lLanguageID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@prRole", lRoleID, XDbType.BigInt, 8, ParameterDirection.Input);
            AddParameter(oCmd, "@pcOwnerSet", cOwnerSet, XDbType.NChar, 1, ParameterDirection.Input);
        }

        /// <summary>
        /// Inserv_ts a new Parameter at the given Index for the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="iParameterIndex">The Index</param>
        /// <param name="sParameterName">Paramter Name</param>
        /// <param name="oParameterValue">Parameter Value</param>
        /// <param name="DbType">Parameter Type</param>
        /// <param name="iSize">Data Size</param>
        /// <param name="direction">Parameter Direction</param>
        public static void InsertParameter(System.Data.IDbCommand oCmd, int iParameterIndex, string sParameterName, object oParameterValue, XDbType DbType, int iSize, System.Data.ParameterDirection direction)
        {
            XrDbCommand o = (XrDbCommand)oCmd;
            XrDbParameter oParam = CreateParameter(sParameterName, oParameterValue, DbType, iSize, direction);
            o.Parameters.Insert(iParameterIndex, oParam);
        }

        /// <summary>
        /// Inserv_ts a new Parameter at the given Index for the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="iParameterIndex">The Index</param>
        /// <param name="sParameterName">Paramter Name</param>
        /// <param name="oParameterValue">Parameter Value</param>
        /// <param name="DbType">Parameter Type</param>
        public static void InsertParameter(System.Data.IDbCommand oCmd, int iParameterIndex, string sParameterName, object oParameterValue, XDbType DbType)
        {
            XrDbCommand o = (XrDbCommand)oCmd;
            XrDbParameter oParam = CreateParameter(sParameterName, oParameterValue, DbType, 0, System.Data.ParameterDirection.Input);
            o.Parameters.Insert(iParameterIndex, oParam);
        }

        /// <summary>
        /// Adds a new Parameter to the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="sParameterName">Parameter Name</param>
        /// <param name="oParameterValue">Parameter Value</param>
        /// <param name="DbType">Parameter Type</param>
        /// <param name="iSize">Data Size</param>
        /// <param name="pdDirection">Parameter Direction</param>
        public static void AddParameter(System.Data.IDbCommand oCmd, string sParameterName, object oParameterValue, XDbType DbType, int iSize, System.Data.ParameterDirection pdDirection)
        {
            XrDbCommand o = (XrDbCommand)oCmd;
            XrDbParameter oParam = CreateParameter(sParameterName, oParameterValue, DbType, iSize, pdDirection);

            // Replace or Add
            if (o.Parameters.Contains(sParameterName))
            {
                o.Parameters[sParameterName] = oParam;
            }
            else
            {
                o.Parameters.Add(oParam);
            }
        }

        /// <summary>
        /// Adds a new Parameter to the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="sParameterName">Parameter Name</param>
        /// <param name="oParameterValue">Parameter Value</param>
        /// <param name="DbType">Parameter Type</param>
        public static void AddParameter(System.Data.IDbCommand oCmd, string sParameterName, object oParameterValue, XDbType DbType)
        {
            AddParameter(oCmd, sParameterName, oParameterValue, DbType, 0, ParameterDirection.Input);
        }

        /// <summary>
        /// Adds a new Parameter to the Command
        /// </summary>
        /// <param name="oCmd">The Command</param>
        /// <param name="sParameterName">Parameter Name</param>
        /// <param name="oParameterValue">Parameter Value</param>
        public static void AddParameter(System.Data.IDbCommand oCmd, string sParameterName, object oParameterValue)
        {
            Type tParameterValueType = oParameterValue.GetType();
            X.Data.DB.XDbType xDbType = GetDbType(tParameterValueType);
            AddParameter(oCmd, sParameterName, oParameterValue, xDbType, 0, ParameterDirection.Input);
        }

        protected static XrDbParameter CreateParameter(string sParameterName, object oParameterValue, XDbType DbType, int iSize, System.Data.ParameterDirection direction)
        {
            XrDbParameter oParam;

            if (iSize != 0)
                oParam = new XrDbParameter(sParameterName, (XrDbType)DbType, iSize);
            else
                oParam = new XrDbParameter(sParameterName, (XrDbType)DbType);

            oParam.Direction = direction;
            oParam.Value = oParameterValue;

            return oParam;
        }

        /// <summary>
        /// Returns the Parameter Value
        /// </summary>
        /// <param name="oCmd">Command</param>
        /// <param name="sParameterName">Parameter Name</param>
        /// <returns>Parameter Value</returns>
        public static object GetParameterValue(System.Data.IDbCommand oCmd, string sParameterName)
        {
            return ((XrDbParameter)oCmd.Parameters[sParameterName]).Value;
        }

        /// <summary>
        /// Set the Parameter Value
        /// </summary>
        /// <param name="oCmd">Command</param>
        /// <param name="sParameterName">Parameter Name</param>
        /// <param name="oParameterValue">Parameter Value</param>
        public static void SetParameterValue(System.Data.IDbCommand oCmd, string sParameterName, object oParameterValue)
        {
            ((XrDbParameter)oCmd.Parameters[sParameterName]).Value = oParameterValue;
        }

        /// <summary>
        /// Returns the DB Specific Command Parameter PlaceHolder
        /// </summary>
        /// <param name="sParameterName">Parameter Name</param>
        /// <param name="oConn"></param>
        /// <returns>The PlaceHolder</returns>
        public static string GetParameterPlaceHolder(string sParameterName, System.Data.IDbConnection oConn)
        {
            // OLE DB Specific
            if (oConn is System.Data.OleDb.OleDbConnection)
                return "?";

            return sParameterName;
        }

        /// <summary>
        /// Fills The DataSet
        /// </summary>
        /// <param name="da">DataAdapter</param>
        /// <param name="dsDataSet">DataSet</param>
        /// <param name="sTable">Table Name</param>
        public static void FillDataSet(System.Data.IDbDataAdapter da, System.Data.DataSet dsDataSet, string sTable)
        {
            ((XrDbDataAdapter)da).Fill(dsDataSet, sTable);
        }

        /// <summary>
        /// Data Exception
        /// </summary>
        /// <param name="ex">The Exception</param>
        /// <returns>True when Exception is a Data Exception</returns>
        public static bool IsDataException(System.Exception ex)
        {
            if (ex is System.Data.SqlClient.SqlException || ex is System.Data.OleDb.OleDbException)
                return true;

            return false;
        }
    }
}
