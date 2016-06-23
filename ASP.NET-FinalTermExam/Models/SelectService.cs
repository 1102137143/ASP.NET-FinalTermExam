using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ASP.NET_FinalTermExam.Models
{
    public class SelectService
    {
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        /// <summary>
        /// 取得職稱
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> getTitle()
        {
            DataTable dt = new DataTable();
            string sql = @"select CodeId as SelectId,CodeVal as SelectName
                           from CodeTable
                           where CodeType='Title'";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得職稱ByID
        /// </summary>
        /// <returns></returns>
        public string getTitleById(string id)
        {
            DataTable dt = new DataTable();
            string sql = @"select CodeId as SelectId,CodeVal as SelectName
                           from CodeTable
                           where CodeType='Title' AND CodeId=@id";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt).FirstOrDefault().Text;
        }

        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["SelectName"].ToString(),
                    Value = row["SelectId"].ToString()
                });
            }
            return result;
        }
    }
}