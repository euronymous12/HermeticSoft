using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace HS_Aquiles_ERP
{
    public class HSCRUD
    {
        public DataTable ExecDT(string query, string conexion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            dt.Load(command.ExecuteReader());
            connection.Close();
            dt.TableName = "Table";
            return dt;
        }

        public DataSet ExecDS(string query, string conexion)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            connection.Open();
            da.Fill(ds);
            connection.Close();
            return ds;
        }

        public DataTable ExecPDT(string query, DataSet ds, string[] udtName, string conexion)
        {
            DataTable dt = new DataTable();
            int i;
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            for (i = 0; i < ds.Tables.Count; i++)
            {
                SqlParameter p = new SqlParameter("@p" + i.ToString(), SqlDbType.Structured);
                p.TypeName = udtName[i];
                p.Value = ds.Tables[i];
                command.Parameters.Add(p);
            }
            SqlDataAdapter da = new SqlDataAdapter(command);
            connection.Open();
            da.Fill(dt);
            connection.Close();
            dt.TableName = "Table";
            return dt;
        }

        public DataSet ExecPDS(string query, DataSet ds, string[] udtName, string conexion)
        {
            DataSet dt = new DataSet();
            int i;
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            for (i = 0; i < ds.Tables.Count; i++)
            {
                SqlParameter p = new SqlParameter("@p" + i.ToString(), SqlDbType.Structured);
                p.TypeName = udtName[i];
                p.Value = ds.Tables[i];
                command.Parameters.Add(p);
            }
            SqlDataAdapter da = new SqlDataAdapter(command);
            connection.Open();
            da.Fill(dt);
            connection.Close();
            return dt;
        }

        public void Insert(string table, string[] fields, object[] values, string conexion)
        {
            string query = "INSERT INTO " + table + " (\n";
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            int i;
            for (i = 0; i < fields.Length; i++)
            {
                if (fields.Length - 1 != i)
                    query += "    " + fields[i] + ",\n";
                else
                    query += "    " + fields[i] + "\n)\nVALUES (\n";
            }
            for (i = 0; i < values.Length; i++)
            {
                if (fields.Length - 1 != i)
                    query += "    @p" + i.ToString() + " ,\n";
                else
                    query += "    @p" + i.ToString() + " \n)";
                SqlParameter p = new SqlParameter("@p" + i.ToString(), values[i] == null ? (object)DBNull.Value : values[i]);
                command.Parameters.Add(p);
            }
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(string table, string[] fields, object[] values, string condition, string conexion)
        {
            string query = "UPDATE " + table + " SET\n";
            int i;
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            for (i = 0; i < fields.Length; i++)
            {
                if (fields.Length - 1 != i)
                    query += "    " + fields[i] + " = " + "@p" + i.ToString() + ",\n";
                else
                    query += "    " + fields[i] + " = " + "@p" + i.ToString() + "\nWHERE " + condition;
                SqlParameter p = new SqlParameter("@p" + i.ToString(), values[i] == null ? (object)DBNull.Value : values[i]);
                command.Parameters.Add(p);
            }
            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(string table, string condition, string conexion)
        {
            string query = "DELETE FROM " + table + " WHERE " + condition;
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public object GetSingleResult(string query, object[] parameters, string conexion)
        {
            DataTable dt = new DataTable();
            object result = new object();
            SqlConnection connection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(query, connection);
            for (int i = 0; i < parameters.Length; i++)
            {
                SqlParameter p = new SqlParameter("@p" + i.ToString(), parameters[i] == null ? (object)DBNull.Value : parameters[i]);
                command.Parameters.Add(p);
            }
            connection.Open();
            dt.Load(command.ExecuteReader());
            connection.Close();
            dt.TableName = "Table";
            result = dt.Rows[0][0];
            return result;
        }

        public string Encode(string str)
        {
            byte[] bs = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(bs);
        }

        public string Decode(string str)
        {          
            byte[] bs = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(bs);          
        }
    }
}