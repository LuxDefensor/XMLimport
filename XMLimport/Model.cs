using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XMLimport
{
    class Model
    {
        private string cs;
        private DataSet data;
        private SqlDataAdapter da;
        private int season;

        public DataSet Data
        {
            get
            {
                return data;
            }
        }

        public Model(string serverName, string database, string userID, string password, int season)
        {
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = serverName;
            csb.InitialCatalog = database;
            csb.UserID = userID;
            csb.Password = password;
            csb.ConnectTimeout = 600;
            cs = csb.ConnectionString;
            this.season = season;
        }

        #region Device and sensor research        
        public string DeviceCodeFromObject(string objectSpecCode)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ObjCode FROM [Object] ");
                sql.AppendFormat("WHERE ObjSpecCode='{0}' AND ObjType=98", objectSpecCode);
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch(Exception ex)
                {
                    throw new Exception("Код " + objectSpecCode + " не найден в БД Пирамиды" + Environment.NewLine + ex.Message, ex);
                }
                if (Convert.IsDBNull(result))
                    throw new Exception("Код " + objectSpecCode + " не найден в БД Пирамиды");
                else
                    return result.ToString();
            }
        }

        public Tuple<string, string> FullSubdevice(string objSpecCode)
        {
            Tuple<string, string> result = new Tuple<string, string>(string.Empty, string.Empty);
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("select OBJCODE, OBJITEM from object ");
                sql.AppendFormat("where OBJSPECCODE = '{0}'", objSpecCode);
                sql.Append("and OBJTYPE = 98 and CODETYPE = 0 ");
                cmd.CommandText = sql.ToString();
                SqlDataReader dr;
                try
                {
                    dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                }
                catch (Exception ex)
                {
                    throw new Exception("Код " + objSpecCode + " не найден в БД Пирамиды" + Environment.NewLine + ex.Message, ex);
                }
                if (dr.Read())
                {
                    if (Convert.IsDBNull(dr[0]))
                        throw new Exception("Код " + objSpecCode + " не найден в БД Пирамиды");
                    else
                        result = new Tuple<string, string>(dr[0].ToString(), dr[1].ToString());
                }
                else
                {
                    throw new Exception("Код " + objSpecCode + " не найден в БД Пирамиды");
                }
                return result;
            }
        }

        public string ItemCodeFromObject(string objectSpecCode, string deviceCode, string subdeviceCode)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("select OBJITEM ");
                sql.Append("from OBJECT inner join devices on OBJECT.OBJCODE = devices.code ");
                sql.Append("inner join SUBDEVICES s on s.STATIONID = DEVICES.ID ");
                sql.Append("inner join SENSORS on SENSORS.STATIONID = DEVICES.ID and s.ID = SENSORS.SUBDEVICEID and SENSORS.CODE = OBJITEM ");
                sql.AppendFormat("where DEVICES.CODE = {0} and s.CODE = {1} ", deviceCode, subdeviceCode);
                sql.AppendFormat("and CODETYPE = 0 and OBJSPECCODE = '{0}'", objectSpecCode);                
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Код " + objectSpecCode + " не найден в БД Пирамиды для точки " + objectSpecCode
                        + Environment.NewLine + ex.Message, ex);
                }
                if (Convert.IsDBNull(result))
                    throw new Exception("Код " + objectSpecCode + " не найден в БД Пирамиды");
                else
                    return result.ToString();
            }
        }

        public string SubeviceCodeFromObject(string objectSpecCode)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ObjItem FROM [Object] ");
                sql.AppendFormat("WHERE ObjSpecCode='{0}' AND ObjType=98", objectSpecCode);
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Код " + objectSpecCode + " не найден в БД Пирамиды", ex);
                }
                if (!Convert.IsDBNull(result))
                    return result.ToString();
                else
                    throw new Exception("Код " + objectSpecCode + " не найден в БД Пирамиды");
            }
        }

        public string DeviceID(string deviceCode)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("SELECT ID FROM Devices WHERE Code={0}", deviceCode);
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Код " + deviceCode + " не найден в БД Пирамиды", ex);
                }
                if (!Convert.IsDBNull(result))
                    return result.ToString();
                else
                    throw new Exception("Код " + deviceCode + " не найден в БД Пирамиды");
            }
        }

        public string SubdeviceID(string deviceID, string SubdeviceCode)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ID FROM Subdevices ");
                sql.AppendFormat("WHERE StationID={0} AND Code={1}", deviceID, SubdeviceCode);
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Код " + deviceID + " не найден в БД Пирамиды", ex);
                }
                if (!Convert.IsDBNull(result))
                    return result.ToString();
                else
                    throw new Exception("Код " + deviceID + " не найден в БД Пирамиды");
            }
        }
        #endregion

        #region Write data

        /// <summary>
        /// Writes data one by one directly into the table DATA
        /// using stored procedure and transactions with high isolation level
        /// </summary>
        /// <param name="parNumber"></param>
        /// <param name="dataDate"></param>
        /// <param name="objectCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="objType"></param>
        /// <param name="value"></param>
        /// <param name="p2kStatus"></param>
        /// <param name="p2kStatusH"></param>
        /// <param name="notUpdate"></param>
        /// <param name="appID"></param>
        public void WriteValue(int parNumber, DateTime dataDate, int objectCode, int itemCode, int objType,
            float value, int p2kStatus, int p2kStatusH, int notUpdate, int appID)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ADD_DATA_1";
                cmd.Transaction = tran;
                #region Create parameters

                cmd.Parameters.Add("@PARNUMBER", SqlDbType.Int);
                cmd.Parameters["@PARNUMBER"].SqlValue = parNumber;

                cmd.Parameters.Add("@DATA_DATE", SqlDbType.DateTime);
                cmd.Parameters["@DATA_DATE"].SqlValue = dataDate;

                cmd.Parameters.Add("@OBJECT", SqlDbType.Int);
                cmd.Parameters["@OBJECT"].SqlValue = objectCode;

                cmd.Parameters.Add("@ITEM", SqlDbType.Int);
                cmd.Parameters["@ITEM"].SqlValue = itemCode;

                cmd.Parameters.Add("@OBJTYPE", SqlDbType.Int);
                cmd.Parameters["@OBJTYPE"].SqlValue = objType;

                cmd.Parameters.Add("@VALUE0", SqlDbType.Float);
                cmd.Parameters["@VALUE0"].SqlValue = value;

                cmd.Parameters.Add("@VALUE1", SqlDbType.Float);
                cmd.Parameters["@VALUE1"].SqlValue = value;

                cmd.Parameters.Add("P2KSTATUS", SqlDbType.Int);
                cmd.Parameters["P2KSTATUS"].SqlValue = 0;

                cmd.Parameters.Add("@P2KSTATUSH", SqlDbType.Int);
                cmd.Parameters["@P2KSTATUSH"].SqlValue = 0;

                cmd.Parameters.Add("@RCVSTAMP", SqlDbType.DateTime);
                cmd.Parameters["@RCVSTAMP"].SqlValue = DateTime.Now;

                cmd.Parameters.Add("@NOT_UPDATE", SqlDbType.Int);
                cmd.Parameters["@NOT_UPDATE"].SqlValue = notUpdate;

                cmd.Parameters.Add("@APPID", SqlDbType.Int);
                cmd.Parameters["@APPID"].SqlValue = 0;

                #endregion

                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                        tran.Commit();
                    else
                    {
                        tran.Rollback();
                        throw new Exception(string.Format("Не удалось добавить получасовку {0} устройство {1}, канал {2}",
                        dataDate, objectCode, itemCode));
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception(string.Format("Не удалось добавить получасовку {0} устройство {1}, канал {2}",
                        dataDate, objectCode, itemCode), ex);
                }
            }
        }


        public void InitializeDataSet(int objectCode, int itemCode, DateTime dataDate)
        {
            int season = 4023;
            data = new DataSet("xmldata");
            data.Tables.Add("values");
            data.Tables[0].Columns.Add("Parnumber", typeof(int));
            data.Tables[0].Columns.Add("Object", typeof(int));
            data.Tables[0].Columns.Add("Item", typeof(int));
            data.Tables[0].Columns.Add("Value0", typeof(float));
            data.Tables[0].Columns.Add("Value1", typeof(float));
            data.Tables[0].Columns.Add("ObjType", typeof(System.Int16));
            data.Tables[0].Columns.Add("Data_Date", typeof(DateTime));
            data.Tables[0].Columns.Add("RcvStamp", typeof(DateTime));
            data.Tables[0].Columns.Add("Season", typeof(int));
            data.Tables[0].Columns.Add("P2KStatus", typeof(int));
            data.Tables[0].Columns.Add("P2KStatusH", typeof(int));
            data.Tables[0].Columns.Add("AppID", typeof(int));
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand.CommandText = "SELECT Parnumber, Object, Item, Value0, Value1, ObjType, Data_Date, RcvStamp, Season, P2KStatus, P2KStatusH, AppID " +
                "FROM Data WHERE Object=@Object AND Item=@Item AND Data_Date=@Data_Date AND Parnumber=@Parnumber AND Season=@Season";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@Object", objectCode);
            parameters[1] = new SqlParameter("@Item", itemCode);
            parameters[2] = new SqlParameter("@Data_Date", dataDate);
            parameters[3] = new SqlParameter("@Parnumber", 12);
            parameters[4] = new SqlParameter("@Season", season);
            parameters[5] = new SqlParameter("@Value", 0);
            parameters[6] = new SqlParameter("@RcvStamp", DateTime.Now);

            da.SelectCommand.Parameters.Add(parameters[0]);
            da.SelectCommand.Parameters.Add(parameters[1]);
            da.SelectCommand.Parameters.Add(parameters[2]);
            da.SelectCommand.Parameters.Add(parameters[3]);
            da.SelectCommand.Parameters.Add(parameters[4]);
            
            da.InsertCommand.CommandText = "INSERT INTO Data VALUES(@Parnumber, @Object, @Item, @Value0, @Value, 0, @Data_Date, @RcvStamp, " +
                "@Season, 0, 0, 0)";
            da.InsertCommand.Parameters.Add(parameters[0]);
            da.InsertCommand.Parameters.Add(parameters[1]);
            da.InsertCommand.Parameters.Add(parameters[2]);
            da.InsertCommand.Parameters.Add(parameters[3]);
            da.InsertCommand.Parameters.Add(parameters[4]);
            da.InsertCommand.Parameters.Add(parameters[5]);
            da.InsertCommand.Parameters.Add(parameters[6]);

            da.DeleteCommand.CommandText = "DELETE FROM Data " +
                "WHERE Object=@Object AND Item=@Item AND Data_Date=@Data_Date AND Parnumber=@Parnumber AND Season=@Season";
            da.DeleteCommand.Parameters.Add(parameters[0]);
            da.DeleteCommand.Parameters.Add(parameters[1]);
            da.DeleteCommand.Parameters.Add(parameters[2]);
            da.DeleteCommand.Parameters.Add(parameters[3]);
            da.DeleteCommand.Parameters.Add(parameters[4]);            

            da.UpdateCommand.CommandText = "UPDATE Data SET Value0=@Value, Value1=@Value, RcvStamp=@RcvStamp, ObjType=0, P2KStatus=0, P2KStatusH=0, AppID=0 " +
                "WHERE Object=@Object AND Item=@Item AND Parnumber=@Parnummber AND Season=@Season AND Data_Date=@Data_Date";
            da.DeleteCommand.Parameters.Add(parameters[0]);
            da.DeleteCommand.Parameters.Add(parameters[1]);
            da.DeleteCommand.Parameters.Add(parameters[2]);
            da.DeleteCommand.Parameters.Add(parameters[3]);
            da.DeleteCommand.Parameters.Add(parameters[4]);
            da.DeleteCommand.Parameters.Add(parameters[5]);
            da.DeleteCommand.Parameters.Add(parameters[6]);

            using (SqlConnection cn = new SqlConnection(cs))
            {
                da.SelectCommand.Connection = cn;
                try
                {
                    da.Fill(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("Проверка существующих данных" + Environment.NewLine + ex.Message, ex);
                }
            }

        }

        public void ClearDataSet()
        {
            if (data != null)
            {
                data.Clear();
                data.Tables.Clear();
                data = null;
            }
        }

        /// <summary>
        /// Writes one row to the dataset
        /// </summary>
        /// <param name="parNumber"></param>
        /// <param name="dataDate"></param>
        /// <param name="objectCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="objType"></param>
        /// <param name="value"></param>
        /// <param name="p2kStatus"></param>
        /// <param name="p2kStatusH"></param>
        /// <param name="notUpdate"></param>
        /// <param name="appID"></param>
        /// <param name="rewrite"></param>
        public void WriteOneRow(int parNumber, DateTime dataDate, int objectCode, int itemCode, int objType,
            float value, int p2kStatus, int p2kStatusH, int notUpdate, int appID, bool rewrite)
        {
            int season = 4023;
            DataRow[] existing = data.Tables[0].Select(string.Format("Parnumber={0} AND Object={1} AND Item={2} AND Data_Date='{3}'",
                parNumber, objectCode, itemCode, dataDate.ToString("yyyyMMdd HH:mm")));
            if (existing != null && existing.Count() == 1 && rewrite)
            {
                existing[0]["Value0"] = value;
                existing[0]["Value1"] = value;
                existing[0]["RcvStamp"] = DateTime.Now;
                da.UpdateCommand.Parameters["@Value"].Value = value;
                da.UpdateCommand.Parameters["@RcvStamp"].Value = value;
            }
            else
            {
                DataRow row = data.Tables[0].Rows.Add(parNumber, objectCode, itemCode, value, value, 0, dataDate, DateTime.Now,
                                                        season, 0, 0, 0);
                data.Tables[0].Rows.Add(row);
                da.InsertCommand.Parameters["@Value"].Value = value;
                da.InsertCommand.Parameters["@RcvStamp"].Value = value;
            }
            
        }

        /// <summary>
        /// Writes all data from dataset to the table DATA
        /// </summary>
        public void WriteAllRowsToDB()
        {
            if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
                    da.SelectCommand.Connection = cn;
                    da.UpdateCommand.Connection = cn;
                    da.InsertCommand.Connection = cn;
                    da.DeleteCommand.Connection = cn;
                    try
                    {
                        da.Update(data);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Ошибка записи данных в БД" + Environment.NewLine + ex.Message, ex);
                    }
                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// Writes one data into the temp table
        /// </summary>
        /// <param name="parNumber"></param>
        /// <param name="dataDate"></param>
        /// <param name="objectCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="objType"></param>
        /// <param name="value"></param>
        /// <param name="p2kStatus"></param>
        /// <param name="p2kStatusH"></param>
        /// <param name="notUpdate"></param>
        /// <param name="appID"></param>
        /// <param name="rewrite"></param>
        public void WriteOneRecord(int parNumber, DateTime dataDate, int objectCode, int itemCode, int objType,
            string value, int p2kStatus, int p2kStatusH, int appID, bool rewrite)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT Count(*) cnt FROM Data_Temp WHERE ");
                sql.AppendFormat("Parnumber={0} AND Object={1} AND Item={2} ",
                    parNumber, objectCode, itemCode);
                sql.AppendFormat("AND Data_Date='{0}'", dataDate.ToString("yyyyMMdd HH:mm"));
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql.ToString();
                object result = null;
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Значение для {0}.{1} за {2} не добавлено. Timeout={3}",
                        objectCode, itemCode, dataDate, cn.ConnectionTimeout), ex);
                }
                sql.Clear();
                if (result == null || Convert.IsDBNull(result) || (int)result == 0)
                {
                    if (!rewrite)
                    {
                        sql.Append("if not exists (select * from DATA ");
                        sql.AppendFormat("where parnumber = {0} and object = {1} ", parNumber, objectCode);
                        sql.AppendFormat("and item = {0} and data_date = '{1}') ", itemCode, dataDate.ToString("yyyyMMdd HH:mm"));
                    }
                    sql.Append("insert into data_temp(parnumber, object, item, value0, value1, ");
                    sql.Append("OBJTYPE, data_date, rcvstamp, season, p2kstatus, P2KSTATUSH, appid) ");
                    sql.AppendFormat("values ({0}, {1}, {2}, {3}, {4}, {5}, '{6}', '{7}', {8}, 0, 0, 0)",
                        parNumber, objectCode, itemCode, value, value, objType, dataDate.ToString("yyyyMMdd HH:mm"),
                        DateTime.Now.ToString("yyyyMMdd HH:mm:ss"), season);
                    cmd.CommandText = sql.ToString();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Значение для {0}.{1} за {2} не добавлено. Timeout={3}",
                            objectCode, itemCode, dataDate, cn.ConnectionTimeout), ex);
                    }
                }
            }
        }

        public void WriteAllFromTemp(bool rewrite)
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                StringBuilder sql = new StringBuilder();
                SqlTransaction tran = cn.BeginTransaction(IsolationLevel.Serializable);
                SqlCommand cmd = cn.CreateCommand();
                if (rewrite)
                {
                    //sql.Append("DELETE FROM Data WHERE EXISTS (SELECT * FROM Data_Temp t WHERE ");
                    //sql.Append("Data.Parnumber=t.Parnumber AND Data.Object=T.Object AND ");
                    //sql.Append("Data.Item=t.Item AND Data.Data_Date=t.Data_Date)");
                    sql.Append(@"delete from data
                                    where cast(data_date as nvarchar) +
                                          '_' +
                                          cast(object as nvarchar) +
                                          '_' +
                                          cast(item as nvarchar) +
                                          '_' +
                                          cast(parnumber as nvarchar) in
                                        (select cast(data_date as nvarchar) +
                                          '_' +
                                          cast(object as nvarchar) +
                                          '_' +
                                          cast(item as nvarchar) +
                                          '_' +
                                          cast(parnumber as nvarchar) idx
                                          from data_temp t)");
                }
                else
                {
                    sql.Append(@"delete from data_temp
                                    where cast(data_date as nvarchar) +
                                          '_' +
                                          cast(object as nvarchar) +
                                          '_' +
                                          cast(item as nvarchar) +
                                          '_' +
                                          cast(parnumber as nvarchar) in
                                        (select cast(data_date as nvarchar) +
                                          '_' +
                                          cast(object as nvarchar) +
                                          '_' +
                                          cast(item as nvarchar) +
                                          '_' +
                                          cast(parnumber as nvarchar) idx
                                          from data t)");
                }
                cmd.CommandText = sql.ToString();
                cmd.Transaction = tran;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Ошибка удаления существующих значений из таблицы Data. Timeout=" + cn.ConnectionTimeout, ex);
                }
                sql.Clear();
                sql.Append("INSERT INTO Data(parnumber, object, item, value0, value1, ");
                sql.Append("OBJTYPE, data_date, rcvstamp, season, p2kstatus, P2KSTATUSH, appid)");
                sql.Append("SELECT parnumber, object, item, value0, value1, ");
                sql.Append("OBJTYPE, data_date, rcvstamp, season, p2kstatus, P2KSTATUSH, appid FROM Data_Temp ");
                cmd.CommandText = sql.ToString();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Ошибка копирования данных из временной таблицы. Timeout=" + cn.ConnectionTimeout, ex);
                }
                sql.Clear();
                cmd.CommandText = "DELETE FROM Data_Temp";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Ошибка очистки временной таблицы. Timeout=" + cn.ConnectionTimeout, ex);
                }
                tran.Commit();

            }
        }

        public void ClearTempTable()
        {
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Data_Temp";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при очистке временной таблицы. Timeout=" + cn.ConnectionTimeout, ex);
                }
            }
        }
        #endregion

        #region Checking XML

        public bool CheckMeasuringPoint(string code)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ObjCode FROM [Object] ");
                sql.AppendFormat("WHERE ObjSpecCode='{0}' AND ObjType=98", code);
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при проверке кода " + code + Environment.NewLine + ex.Message, ex);
                }
                return !(Convert.IsDBNull(result) || result == null);
            }
        }

        public bool CheckMeasuringChannel(string objectSpecCode, string deviceCode, string subdeviceCode)
        {
            object result;
            using (SqlConnection cn = new SqlConnection(cs))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                StringBuilder sql = new StringBuilder();
                sql.Append("select OBJITEM ");
                sql.Append("from OBJECT inner join devices on OBJECT.OBJCODE = devices.code ");
                sql.Append("inner join SUBDEVICES s on s.STATIONID = DEVICES.ID ");
                sql.Append("inner join SENSORS on SENSORS.STATIONID = DEVICES.ID and s.ID = SENSORS.SUBDEVICEID and SENSORS.CODE = OBJITEM ");
                sql.AppendFormat("where DEVICES.CODE = {0} and s.CODE = {1} ", deviceCode, subdeviceCode);
                sql.AppendFormat("and CODETYPE = 0 and OBJSPECCODE = '{0}' ", objectSpecCode);
                cmd.CommandText = sql.ToString();
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при проверке кода " + objectSpecCode + Environment.NewLine + ex.Message, ex);
                }
                return !(Convert.IsDBNull(result) || result == null);
            }
        }

        #endregion

        #region Prepare table

        public void PrepareTable()
        {            
            using (SqlConnection cn = new SqlConnection(cs))
            {
                object result;
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "select count(*) res from sys.tables where name = 'data_temp'";
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка 1 при проверке таблицы Data_Temp", ex);
                }
                if (Convert.IsDBNull(result))
                {
                    throw new Exception("Ошибка 2 при проверке таблицы Data_Temp");
                }
                if ((int)result == 0)
                {
                    cmd.CommandText = "select top 1 * into data_temp from data";
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ошибка создании таблицы Data_Temp", ex);
                    }
                }
                cmd.CommandText = "delete from data_temp";
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при очистке таблицы Data_Temp", ex);
                }
            }
        }
        #endregion
    }
}
