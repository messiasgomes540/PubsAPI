using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicePubs
{
    /// <summary>
    /// Summary description for ServicePubs
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicePubs : System.Web.Services.WebService
    {

        [WebMethod]
        public string Ativo()
        {
            return "ativado";
        }

        [WebMethod]
        public string PublisherInsert(
            string pub_id, string pub_name, string city,
            string state, string country)
        {
            string aSQLProc = "sp_publishers_insert";
            string aSQLConecStr = "Data Source=.;Initial Catalog=Pubs;Persist Security Info=True;User ID=sa;Password=sa";

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand(aSQLProc, aSQLCon);
            aSQL.CommandType = CommandType.StoredProcedure;

            aSQL.Parameters.AddWithValue("@pub_id", pub_id);
            aSQL.Parameters.AddWithValue("@pub_name", pub_name);
            aSQL.Parameters.AddWithValue("@city", city);
            aSQL.Parameters.AddWithValue("@state", state);
            aSQL.Parameters.AddWithValue("@country", country);

            string result = "ok";
            try
            { aSQL.ExecuteNonQuery(); }
            catch (Exception ex)
            { result = ex.Message; }

            return result;
            }

        [WebMethod]
        public string PublisherUpdate(
            string pub_id, string pub_name, string city,
            string state, string country)
        {
            string aSQLProc = "sp_publishers_update";

            string aSQLConecStr = "Data Source=.;Initial Catalog=Pubs;Persist Security Info=True;User ID=sa;Password=sa";

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand(aSQLProc, aSQLCon);
            aSQL.CommandType = CommandType.StoredProcedure;

            aSQL.Parameters.AddWithValue("@pub_id", pub_id);
            aSQL.Parameters.AddWithValue("@pub_name", pub_name);
            aSQL.Parameters.AddWithValue("@city", city);
            aSQL.Parameters.AddWithValue("@state", state);
            aSQL.Parameters.AddWithValue("@country", country);

            string result = "ok";
            try
            { aSQL.ExecuteNonQuery(); }
            catch (Exception ex)
            { result = ex.Message; }

            return result;
        }
        [WebMethod]
        public string PublisherDelete(
            string pub_id)
        {
            string aSQLProc = "sp_publishers_delete";
            string aSQLConecStr = "Data Source=.;Initial Catalog=Pubs;Persist Security Info=True;User ID=sa;Password=sa";

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();
            // Executando o comando
            SqlCommand aSQL = new SqlCommand(aSQLProc, aSQLCon);
            aSQL.CommandType = CommandType.StoredProcedure;
            aSQL.Parameters.AddWithValue("@pub_id", pub_id);

            string result = "ok";
            try
            { aSQL.ExecuteNonQuery(); }
            catch (Exception ex)
            { result = ex.Message; }

            return result;

        }
        [WebMethod]
        public DataSet PublisherSelect(
           string pub_name)
        {
            string aSQLProc = "sp_publishers_select";
            string aSQLConecStr = "Data Source=.;Initial Catalog=Pubs;Persist Security Info=True;User ID=sa;Password=sa";

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand(aSQLProc, aSQLCon);
            aSQL.CommandType = CommandType.StoredProcedure;
            aSQL.Parameters.AddWithValue("@pub_name", pub_name);

            // Cria objeto DataAdapter para execução do comando e 
            // geração de dados para o Dataset
            SqlDataAdapter da = new SqlDataAdapter(aSQL);

            // Cria o objeto Dataset para armazernar o resultada da 
            // consulta SQL a ser executada
            DataSet ds = new DataSet();

            // Executa o comando SQL e tranfere o resultado para o DataSet
            da.Fill(ds);

            return ds;
        }
    }
    }
