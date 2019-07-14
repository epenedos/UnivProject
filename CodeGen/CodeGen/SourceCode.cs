using System;
using System.Data;
using System.Data.SqlClient;
using EnvDTE;
using Extensibility;
using VSLangProj;
using Microsoft.CSharp;
using Microsoft.VisualStudio.VCCodeModel;

namespace CodeGen
{
	/// <summary>
	/// Summary description for SourceCode.
	/// </summary>
	public class SourceCode
	{
		_DTE appOb;
		public SourceCode(_DTE appOb)
		{
			this.appOb=appOb;
		}

		public bool addMethodFromSP(string metName,string spname,CodeInterface intObj,ref CodeFunction cf)
		{
			this.addMethod(metName,intObj,ref cf);
			cf.Comment=spname;
			return true;
		}
		public bool addMethod(string metName,CodeInterface intObj,ref CodeFunction cf)
		{
			cf = intObj.AddFunction(metName,EnvDTE.vsCMFunction.vsCMFunctionFunction ,"int",0,EnvDTE.vsCMAccess.vsCMAccessDefault );
			cf.Comment=metName;
			return true;
		}
		public bool appDTParameter(ref CodeFunction cf)
		{
			cf.AddParameter("ReturnedDataTable","ref System.Data.DataTable",-1);
			return true;
		}
		public bool appParameters(ref CodeFunction cf,SqlParameterCollection spc)
		{
			CodeParameter cp = null;
			string pname;
			foreach(SqlParameter p in spc)
			{
				pname=p.ParameterName.Remove(0,1);
				if (p.Direction != System.Data.ParameterDirection.ReturnValue )
				{
					if (p.Direction==ParameterDirection.Output)
					{
						cp = cf.AddParameter(pname ,"out " + HandleTypes(p.SqlDbType) ,-1);
					}
					else
					{
						if (p.Direction==ParameterDirection.InputOutput )
						{
							cp = cf.AddParameter(pname,"ref " + HandleTypes(p.SqlDbType ) ,-1);
						}
						else
						{
							cp = cf.AddParameter(pname, HandleTypes(p.SqlDbType) ,-1);
						}
					}
				}
			}
			return true;
		}
		public bool ImpInterface(string intType,Project intPrj,CodeInterface intObj,ref CodeClass intCla)
		{
			Project prjObj = null;
			if (!prjCreate(intType,ref prjObj))
			{
				return false;
			}
			// add the necessary references
			VSProject vsPrj = (VSProject) prjObj.Object;
			Reference vsref = vsPrj.References.AddProject(intPrj);
			
			
			
			string claName;
			claName = intObj.Name;
			CodeInterface[] Ints = new CodeInterface[1];
			Ints[0] = intObj;
	
			prjObj.ProjectItems.AddFromTemplate("C:\\Program Files\\Microsoft Visual Studio .NET\\VC#\\CSharpProjectItems\\NewCSharpFile.cs",claName+".cs");
			
			
			ProjectItem pi = prjObj.ProjectItems.Item(claName+".cs");
			CodeNamespace cn = pi.FileCodeModel.AddNamespace(intType,0);
			TextPoint tp = cn.GetStartPoint(EnvDTE.vsCMPart.vsCMPartHeader);
			EditPoint ep = tp.CreateEditPoint();
			ep.StartOfDocument();
			ep.Insert("using " + intObj.Namespace.FullName  + ";\n");
			CodeClass cc = cn.AddClass(intObj.Name ,0,null,null ,EnvDTE.vsCMAccess.vsCMAccessPublic );
			tp = cc.GetStartPoint(EnvDTE.vsCMPart.vsCMPartName);
			ep = tp.CreateEditPoint();
			ep.EndOfLine();
			ep.Insert(" : " + intObj.FullName );
			cc.Comment=intObj.Comment;
			foreach (CodeElement ce in intObj.Members)
			{
				if (ce.Kind == EnvDTE.vsCMElement.vsCMElementFunction )
				{
					CodeFunction cf = (CodeFunction) ce;
					CodeFunction cf1 = cc.AddFunction(cf.Name,cf.FunctionKind ,cf.Type,0,cf.Access,0);
					CodeParameter cep1 = null;
					foreach(CodeElement cep in cf.Parameters )
					{
						CodeParameter cp = (CodeParameter) cep;
						cep1 = cf1.AddParameter(cp.Name,cp.Type,-1);
						
					}

				}
			}


			intCla = cc;
			return true;
			
		}
		public bool AddInterface(string intName,string intNotes,string intType,ref CodeInterface intObj)
		{
			Project prjObj = null;
			if (!prjCreate(intType,ref prjObj))
			{
				return false;
			}
			prjObj.ProjectItems.AddFromTemplate("C:\\Program Files\\Microsoft Visual Studio .NET\\VC#\\CSharpProjectItems\\NewCSharpFile.cs",intName+".cs");
			ProjectItem pi = prjObj.ProjectItems.Item(intName+".cs");
			
			CodeNamespace cn = pi.FileCodeModel.AddNamespace(intType,0);
			TextPoint tp = cn.GetStartPoint(EnvDTE.vsCMPart.vsCMPartHeader);
			EditPoint ep = tp.CreateEditPoint();
			ep.StartOfDocument();
			ep.Insert("using System;\n");



			CodeInterface ci = cn.AddInterface(intName,0,null,EnvDTE.vsCMAccess.vsCMAccessPublic  );
			ci.Comment=intNotes;
			appOb.Solution.SolutionBuild.Build(false);
			
		
			intObj = ci;
			return true;
		}
		public bool prjCreate(string prjName,ref Project prjObj)
		{
			if (!prjExists(prjName,ref prjObj))
			{
				Solution sol = appOb.Solution;
				sol.AddFromTemplate("C:\\Program Files\\Microsoft Visual Studio .NET\\VC#\\CSharpProjects\\CSharpDLL.vsz","c:\\CodeGen\\" + prjName,prjName,false);
				prjExists(prjName,ref prjObj);
				prjObj.ProjectItems.Item("Class1.cs").Delete();
			}
			return true;
		}
		public bool prjExists(string prjName,ref Project prjObj)
		{
			Projects prjs = appOb.Solution.Projects;
			foreach(Project prj in prjs)
			{
				if(prj.Name==prjName)
				{
					prjObj=prj;
					return true;
				}
			}
			return false;
		}
		private string HandleTypes(System.Data.SqlDbType myType)
		{
			switch(myType)
			{
				case System.Data.SqlDbType.VarChar :
					return "string";
				case System.Data.SqlDbType.UniqueIdentifier :
					return "Guid";
				default:
					return myType.ToString();

			}

		}
		public void TryToShow(object obj)
		{
			try
			{
				CodeElement ce = (CodeElement) obj;
			
				if (ce!=null)
				{
					ce.ProjectItem.Open("{00000000-0000-0000-0000-000000000000}");
					ce.StartPoint.TryToShow(EnvDTE.vsPaneShowHow.vsPaneShowCentered,null );
				}
			}
			catch (InvalidCastException error) 
			{
			}

		}
		public void UpdateTreeBranch(System.Windows.Forms.TreeNode tn)
		{
			Project prj = appOb.Solution.Projects.Item("Data_Components");
			System.Windows.Forms.TreeNode node;
			foreach (CodeElement ce in prj.CodeModel.CodeElements )
			{
				if ( ce.Kind==EnvDTE.vsCMElement.vsCMElementClass)
				{
					CodeClass cc = (CodeClass) ce;
					node = new System.Windows.Forms.TreeNode(ce.Name,6,6);

				}
			}
		}
	}
}
