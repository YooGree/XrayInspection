using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XrayInspection
{
    public class AIDBManager
    {
        public static string ConnectionString = CommonFuction.GetAppSetting("AIDBConnectionString");

        SqlConnection conn;
        SqlCommand cmd;

        public bool Open()
        {
            if (conn == null && ConnectionString != null)
            {
                conn = new SqlConnection(ConnectionString);
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception e)
                {
                    LogFactory.Log(e);
                    //System.Windows.Forms.MessageBox.Show("ERROR");
                    return false;
                }
            }
            return true;
        }


        public bool Close()
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    LogFactory.Log(e);
                    //System.Windows.Forms.MessageBox.Show("ERROR");
                    return false;
                }
            }
            return true;
        }

        public bool CallNonQuery(string sql)
        {
            try
            {
                if (Open() == false)
                    return false;

                cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                Close();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return false;
            }
        }

        public bool CallSelectQuery(string sql, ref DataSet ds)
        {
            if (Open() == false)
                return false;

            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                adapter.SelectCommand = new SqlCommand(sql, conn);
                adapter.Fill(ds);
                Close();
                return true;
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return false;
            }
        }

        /// <summary>
        /// VenderID로 VenderName 반환
        /// </summary>
        /// <param name="_venderID"></param>
        /// <returns></returns>
        public string FindVenderName(string _venderID)
        {
            if (string.IsNullOrWhiteSpace(_venderID))
                return "";

            List<SqlParameter> prams = new List<SqlParameter>() { new SqlParameter("@VENDERID", _venderID) };
            var VenderNameList = CallSelectProcedure(ProcedureName.FindVenderName, prams.ToArray());
            if (VenderNameList.Count > 0)
                return VenderNameList[0][ColumnName.VENDERNAME].ToString();
            else
                return "";
        }

        /// <summary>
        /// durableProductID 로 product 정보 반환
        /// </summary>
        /// <param name="_durableProductID"></param>
        /// <returns></returns>
        public string FindProductInfo(string _durableProductID, string _colName)
        {
            if (string.IsNullOrWhiteSpace(_durableProductID))
                return "";

            List<SqlParameter> prams = new List<SqlParameter>() { new SqlParameter("@DURABLEPRODUCTID", _durableProductID) };
            var DescriptionList = CallSelectProcedure(ProcedureName.SelectDURABLEPRODUCTbyID, prams.ToArray());
            if (DescriptionList.Count > 0)
                return DescriptionList[0][_colName].ToString();
            else
                return "";

        }

        public List<Dictionary<string, object>> CallSelectProcedure(string ProceduresName, SqlParameter[] SqlParams = null)
        {
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(ProceduresName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if(SqlParams != null)
                cmd.Parameters.AddRange(SqlParams);
            cmd.CommandTimeout = 600;
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> readMaps = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string fieldName = reader.GetName(i);
                    object value = reader.GetValue(i);
                    readMaps.Add(fieldName, value);
                }
                ret.Add(readMaps);
            }

            conn.Close();
            return ret;
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : 프로시저가 Select 이면서 결과가 한개만 반환될 때 Dictionary 형식으로 반환
        /// </summary>
        /// <param name="ProceduresName"></param>
        /// <param name="SqlParams"></param>
        /// <returns></returns>
        public Dictionary<string, object> CallSingleSelectProcedure(string ProceduresName, List<SqlParameter> SqlParams = null)
        {
            List<Dictionary<string, object>> List;

            if (SqlParams != null)
                List = CallSelectProcedure(ProceduresName, SqlParams.ToArray());
            else
                List = CallSelectProcedure(ProceduresName);

            var Result = List.FirstOrDefault();
            return Result;
        }

        //sql parameter List 객체로 변경 2019-04-29 정송은
        public List<Dictionary<string, object>> CallSelectProcedure(string ProceduresName, List<SqlParameter> SqlParams)
        {
            return CallSelectProcedure(ProceduresName, SqlParams.ToArray());
        }

        public DataSet CallSelectProcedure_ds(string ProceduresName, params SqlParameter[] SqlParams)
        {
            DataSet ret = new DataSet();
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(ProceduresName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SqlParams);
            cmd.CommandTimeout = 600;
             conn.Open();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ret);
            }
            catch(Exception e)
            {
                LogFactory.Log(e);
            }

            conn.Close();
            
            return ret;
        }

        //sql parameter List 객체로 변경 2019-04-29 정송은
        public DataSet CallSelectProcedure_ds(string ProceduresName, List<SqlParameter> SqlParams)
        {
            return CallSelectProcedure_ds(ProceduresName, SqlParams.ToArray());
        }

        public int CallNonSelectProcedure(string ProceduresName, params SqlParameter[] SqlParams)
        {
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(ProceduresName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SqlParams);
            conn.Open();
            int ret = cmd.ExecuteNonQuery();
            conn.Close();
            return ret;
        }

        public DataSet ExecuteSql(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                adapter.SelectCommand = new SqlCommand(sql, conn);
                adapter.Fill(ds);
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return null;
            }
            return ds;
        }

        /// <summary>
        /// 인자를 넣은 DIctionary를 매개변수 배열로 반환
        /// 
        /// ex)var param = new Dictionary<string, string>();
        ///    param.Add("@Id", "asd");
        ///    dbManager.GetSqlParameters(param);
        ///    
        /// </summary>
        /// <param name="args">인자를 넣은 DIctionary, 사용법은 설명 참고 </param>
        /// <returns></returns>
        public SqlParameter[] GetSqlParameters(Dictionary<string, object> args)
        {
            var SqlParameters = args.Select(x => new SqlParameter(x.Key, x.Value)).ToArray();
            return SqlParameters;
        }

        public DataTable ExecuteProcedure(string prcName, Dictionary<string, object> args = null)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(prcName, conn);
            DataTable dt = new DataTable();

            try
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if(args != null)
                {
                    foreach (var x in args)
                    {
                        adapter.SelectCommand.Parameters.Add(new SqlParameter(x.Key, x.Value));
                    }
                }

                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return null;
            }
            return dt;
        }

        public bool CheckConnectState()
        {
            if (conn.State == ConnectionState.Closed)
                return false;
            else if (conn.State == ConnectionState.Open)
                return true;
            return false;
        }

        public  List<T> CallSelectQuery<T>(string Query) where T : new()
        {
            List<T> ret = new List<T>();
            try
            {
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(Query, conn);
               // cmd.Parameters.AddRange(SqlParams);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int intvalue;
                float floatvalue;

                while (reader.Read())
                {
                    try
                    {
                        T newObj = new T();
                        PropertyInfo[] properties = typeof(T).GetProperties();
                        bool isAddList = false;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string fieldName = reader.GetName(i);
                            object value = reader.GetValue(i);
                            PropertyInfo pi = properties.FirstOrDefault(s => s.Name == fieldName);
                            if (pi == null)
                                continue;
                            if (pi.CanWrite && pi.PropertyType == typeof(TimeSpan) && value.GetType() == typeof(long))
                            {
                                value = TimeSpan.FromTicks((long)value);
                            }
                            else if (value.GetType().Name.Equals("Int32"))
                            {
                                value = Convert.ToInt32(value);
                            }
                            else if (value.GetType() == typeof(DateTime))
                            {
                                value = Convert.ToDateTime(value);
                            }
                            else if (pi == null || pi.CanWrite == false)
                                continue;

                            else if (pi.PropertyType != value.GetType())
                            {
                                if (pi.PropertyType == typeof(int) && int.TryParse(value.ToString(), out intvalue))
                                {
                                    pi.SetValue(newObj, intvalue, null);
                                    continue;
                                }
                                if (pi.PropertyType == typeof(float) && float.TryParse(value.ToString(), out floatvalue))
                                {
                                    pi.SetValue(newObj, floatvalue, null);
                                    continue;
                                }
                                else
                                    continue;
                            }
                            pi.SetValue(newObj, value, null);
                            isAddList = true;
                        }
                        if (isAddList)
                            ret.Add(newObj);
                    }
                    catch (Exception ee)
                    {
                        LogFactory.Log(ee);
                    }
                }
                conn.Close();
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
            }
            return ret;
        }


        public List<T> CallSelectProcedure<T>(string ProceduresName) where T : new()
        {
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(ProceduresName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 600;
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<T> ret = new List<T>();
            int intvalue;
            float floatvalue;

            while (reader.Read())
            {
                try
                {
                    T newObj = new T();
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    bool isAddList = false;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string fieldName = reader.GetName(i);
                        object value = reader.GetValue(i);
                        PropertyInfo pi = properties.FirstOrDefault(s => s.Name == fieldName);
                        if (pi == null)
                            continue;
                        if (pi.CanWrite && pi.PropertyType == typeof(TimeSpan) && value.GetType() == typeof(long))
                        {
                            value = TimeSpan.FromTicks((long)value);
                        }
                        else if (value.GetType().Name.Equals("Int32"))
                        {
                            value = Convert.ToInt32(value);
                        }
                        else if (value.GetType() == typeof(DateTime))
                        {
                            value = Convert.ToDateTime(value);
                        }
                        else if (pi == null || pi.CanWrite == false)
                            continue;

                        else if (pi.PropertyType != value.GetType())
                        {
                            if (pi.PropertyType == typeof(int) && int.TryParse(value.ToString(), out intvalue))
                            {
                                pi.SetValue(newObj, intvalue, null);
                                continue;
                            }
                            if (pi.PropertyType == typeof(float) && float.TryParse(value.ToString(), out floatvalue))
                            {
                                pi.SetValue(newObj, floatvalue, null);
                                continue;
                            }
                            else
                                continue;
                        }
                        pi.SetValue(newObj, value, null);
                        isAddList = true;
                    }
                    if (isAddList)
                        ret.Add(newObj);
                }
                catch (Exception ee)
                {
                    LogFactory.Log(ee);
                }
            }

            conn.Close();
            return ret;
        }
    }
}
