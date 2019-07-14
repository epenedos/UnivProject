using System;
using System.Data;
using System.Data.SqlClient;

namespace CodeGenerator.Model
{
	/// <summary>
	/// Summary description for Model.
	/// </summary>
	public class ModelApi
	{
		
	    public Guid CurrentModel;
		public string CurrentModelName;
		public string ConnectionString;
		public ModelApi(string ConnectionString)
		{
			//
			// TODO: Add constructor logic here
			//
			this.ConnectionString = ConnectionString;
		}

		public DataTable listModels()
		{
			
			SqlDataAdapter da = new SqlDataAdapter("listModels",this.ConnectionString);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}
		public void Open(Guid ModelID)
		{
			this.CurrentModel=ModelID;
	


		}

		public bool New()
		{

			SqlConnection conn = new SqlConnection();
			conn.ConnectionString="Initial Catalog=CodeGen;Data Source=localhost;Integrated Security=SSPI;";
			conn.Open();
			//frmNewModel fnm = new frmNewModel();
			//frm.ShowDialog();
			//this.CurrentModelName  = frm.ModelName;
			
			SqlParameter [] arParms = new SqlParameter[2];
			
			arParms[0] = new SqlParameter("@ModelName", SqlDbType.VarChar ,50);
			arParms[0].Direction=ParameterDirection.Input;
			arParms[0].Value = this.CurrentModelName;
	
			arParms[1] = new SqlParameter("@ModelID", SqlDbType.UniqueIdentifier);
			arParms[1].Direction = ParameterDirection.Output;

			SqlCommand cmd;
			cmd =conn.CreateCommand();
			cmd.Connection = conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText="insModel";
			cmd.Parameters.Add(arParms[0]);
			cmd.Parameters.Add(arParms[1]);

			try 
			{
				int t;
				t = cmd.ExecuteNonQuery();
				this.CurrentModel = (Guid) arParms[1].Value;



				
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		public bool Refresh()
		{
			return false;
		}
	}
}
