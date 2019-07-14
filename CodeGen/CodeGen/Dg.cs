using System;
using System.Data;
using System.Data.SqlClient;


namespace CodeGen
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Dg
	{
		private string connectionstring;
		public Dg(string connectionstring)
		{
			//
			// TODO: Add constructor logic here
			//
			this.connectionstring=connectionstring;
		}
		
		public DataTable GetSPList()
		{
			DataTable dt = new DataTable("SPList");
			SqlConnection conn = new SqlConnection(connectionstring);
			SqlCommand cmd = new SqlCommand();
			SqlDataAdapter da = new SqlDataAdapter("select name from sysobjects where " +
				"uid = user_id() and type = 'P' and " +
				"name not like 'dt_%'",conn);
			conn.Open();
			da.Fill(dt);
			conn.Close();

			return dt;

		}

		public SqlParameterCollection getSPParameters(string spname)
		{
			SqlParameterCollection spc;
			SqlConnection conn = new SqlConnection(connectionstring);
			conn.Open();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection=conn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText= spname;
			SqlCommandBuilder.DeriveParameters(cmd);
			spc = cmd.Parameters;
			conn.Close();
			return spc;

		}
		public void genStoredProcedure(string spname,ref SqlParameterCollection spc)
		{
			spc = getSPParameters(spname);
		}

		public string genSignature(string spname,SqlParameterCollection spc)
		{
			string tmp="public ";
			tmp = tmp + "int";
			tmp = tmp + " " + spname + "(";
			int i = 0;
			foreach(SqlParameter p in spc)
			{
				i++;
				tmp = tmp + p.DbType.ToString().Trim() + 
					" " + p.ParameterName.Remove(0,1); 
				if (spc.Count==i) 
					tmp = tmp  + ")\n"; 
				else
					tmp = tmp + ",\n";
			}
			return tmp;
		}

		
		public string genMethodCode(string methodname,string spname)
		{
			string tmpSQL="";
			SqlParameterCollection spc;
			spc = this.getSPParameters(spname);
			tmpSQL = tmpSQL + this.genSignature(spname,spc);
			tmpSQL = tmpSQL + this.genMethodCode(spname,spname);
			return tmpSQL;	
		}
		public string genParmsCode(SqlParameterCollection  spc)
		{
			string tmp="";
			string parm ="";
			tmp = "// Begin parameters section \n\n";
			tmp = tmp + "SqlParameter [] arParms = new SqlParameter[" + spc.Count.ToString().Trim() +"];\n\n";
			int i = 0;
			foreach(SqlParameter p in spc)
			{
				parm = "arParms[" + i.ToString() + "]";
				tmp = tmp + parm + " = new SqlParameter(" + p.ParameterName + ",SqlDbType." +p.SqlDbType +"," +p.Size +   "); \n";
				tmp = tmp + parm + ".Direction = ParameterDirection." +p.Direction + ";\n";
				tmp = tmp + parm + ".Value = " + p.ParameterName.ToString().Trim().Remove(0,1) + ";\n\n";
				i++;
			}
			tmp = tmp + "// End parameters section \n\n";

			return tmp;
		}

		
	}
}
