using System;
using System.Data;
using System.Data.SqlClient;
using CodeGenerator.Model;

namespace CodeGenerator.Model
{
	/// <summary>
	/// Summary description for InterfaceModelApi.
	/// </summary>
	public class InterfaceModelApi
	{
		private ModelApi Model;
		public InterfaceModelApi(ModelApi Model)
		{
			//
			// TODO: Add constructor logic here
			//
			this.Model=Model;
		}
		public DataTable listInterfaces()
		{
			DataTable dt = new DataTable();
			SqlConnection conn = new SqlConnection(this.Model.ConnectionString );
			SqlCommand cmd;
			cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "listInterfaces";
			cmd.Parameters.Add("@ModelID",SqlDbType.UniqueIdentifier,0);
			cmd.Parameters["@ModelID"].Value=this.Model.CurrentModel;

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			
			conn.Open();
			da.Fill(dt);
			conn.Close();
			return dt;
		}
		public DataTable listMethods(Guid Interface)
		{
			DataTable dt = new DataTable();
			SqlConnection conn = new SqlConnection(this.Model.ConnectionString );
			SqlCommand cmd;
			cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "listMethods";
			cmd.Parameters.Add("@ModelID",SqlDbType.UniqueIdentifier,0);
			cmd.Parameters["@ModelID"].Value=this.Model.CurrentModel;
			cmd.Parameters.Add("@InterfaceID",SqlDbType.UniqueIdentifier,0);
			cmd.Parameters["@InterfaceID"].Value=Interface;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			
			conn.Open();
			da.Fill(dt);
			conn.Close();
			return dt;
		}

	}
}
