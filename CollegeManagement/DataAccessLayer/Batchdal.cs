using CollegeManagement.DataObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CollegeManagement.DataAccessLayer
{
    public class Batchdal
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString);

        public void AddNewInfoDAL(BatchDataObject aDao)
        {
            SqlCommand con = new SqlCommand("sp_Insert_Batch",conn);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@BName", aDao.BName);
            conn.Open();
            con.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet LoadAllDataDAL()
        {
            SqlCommand con = new SqlCommand("sp_LoadAllData_Batch", conn);
            con.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(con);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public DataSet LoadDataByMasterIdDAL(int MasterId)
        {
            SqlCommand con = new SqlCommand("sp_Get_BatchMaterDataById", conn);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@MasterId",MasterId);
            SqlDataAdapter da = new SqlDataAdapter(con);
            DataSet dss = new DataSet();
            da.Fill(dss);
            return dss;
        }

        public void UpdateInfoDAL(BatchDataObject aDao)
        {
            SqlCommand con = new SqlCommand("sp_Update_BatchByMasterId", conn);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@Batch_Id", aDao.Batch_Id);
            con.Parameters.AddWithValue("@BName", aDao.BName);
            conn.Open();
            con.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteInfoDAL(int Batch_Id)
        {
            SqlCommand con = new SqlCommand("sp_Delete_BatchByMasterId", conn);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@Batch_Id", Batch_Id);
            conn.Open();
            con.ExecuteNonQuery();
            conn.Close();
        }
    }
}