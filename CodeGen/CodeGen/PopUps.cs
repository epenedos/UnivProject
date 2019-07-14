using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Office.Core;
using Extensibility;
using System.Runtime.InteropServices;
using EnvDTE;

namespace CodeGen
{
	/// <summary>
	/// Summary description for PopUps.
	/// </summary>
	public class PopUps
	{
		public SourceCode sc;
		private TreeView tv;
		#region Main Function
		public PopUps(ref SourceCode sc,ref TreeView tv, ref ContextMenu cm,MouseEventArgs e)
		{
			this.sc=sc;
			this.tv=tv;
			if (tv.SelectedNode.Tag.ToString().StartsWith("DATAINTERFACES"))
			{
				cm.MenuItems.Clear();
				MenuItem mnuAddDInterface = new MenuItem("Add Data Interface");
					
				MenuItem mnuImpDClasses = new MenuItem("Implement Data Component Class");
					
				mnuAddDInterface.Click += new System.EventHandler(this.mnuAddDInterface_Click);
				mnuImpDClasses.Click += new System.EventHandler(this.mnuImpDClasses_Click);
					
				cm.MenuItems.Add(mnuAddDInterface);
				cm.MenuItems.Add("-");
				cm.MenuItems.Add(mnuImpDClasses);
					
				Point pt = new Point(e.X,e.Y);
				cm.Show(tv,pt );

			}

			if (tv.SelectedNode.Tag.ToString().StartsWith("BUSINTERFACES"))
			{
				cm.MenuItems.Clear();
				MenuItem mnuAddBInterface = new MenuItem("Add Business Interface");
					
				MenuItem mnuImpBClasses = new MenuItem("Implement Business Component Class");
					
				mnuAddBInterface.Click += new System.EventHandler(this.mnuAddBInterface_Click);
				mnuImpBClasses.Click += new System.EventHandler(this.mnuImpBClasses_Click);
					
				cm.MenuItems.Add(mnuAddBInterface);
				cm.MenuItems.Add("-");
				cm.MenuItems.Add(mnuImpBClasses);
				
				Point pt = new Point(e.X,e.Y);
				cm.Show(tv,pt );
			}
			if (tv.SelectedNode.Parent.Tag.ToString().StartsWith("DATAINTERFACES"))
			{
				cm.MenuItems.Clear();
				MenuItem mnuAddMSP = new MenuItem("Add Method from Stored Procedure");
					
				MenuItem mnuAddM = new MenuItem("Add Method");
					
				mnuAddMSP.Click += new System.EventHandler(this.mnuAddMSP_Click);
				mnuAddM.Click += new System.EventHandler(this.mnuAddM_Click);
					
				cm.MenuItems.Add(mnuAddMSP);
				cm.MenuItems.Add("-");
				cm.MenuItems.Add(mnuAddM);
				
				Point pt = new Point(e.X,e.Y);
				cm.Show(tv,pt );
			}

		}
		#endregion
		private void mnuAddM_Click(object sender, System.EventArgs e)
		{
		}
		private void mnuAddMSP_Click(object sender, System.EventArgs e)
		{
			frmAddMethodfromSP frmMSP = new frmAddMethodfromSP();
			if (frmMSP.ShowDialog() == DialogResult.OK)
			{
				string metName = frmMSP.txtName.Text.ToString();
				string spname = frmMSP.cbxSP.SelectedItem.ToString();
				CodeInterface ci = (CodeInterface) tv.SelectedNode.Tag;
				CodeFunction cf=null;
				sc.addMethodFromSP (metName,spname,ci,ref cf);
				sc.appParameters(ref cf,frmMSP.spc);
				if (frmMSP.cbxRDT.Checked)
				{
					sc.appDTParameter(ref cf);
				}
				TreeNode addTemp = new TreeNode("",6,6);
				addTemp.Text= metName;
				addTemp.Tag=cf;
				tv.SelectedNode.Nodes.Add (addTemp);
				
				tv.SelectedNode.ExpandAll();

			}
		}
		private void mnuImpBClasses_Click(object sender, System.EventArgs e)
		{   
			
			
			CodeClass cc = null;
			TreeNode tn = tv.SelectedNode;
			foreach(TreeNode t in tn.Nodes )
			{
				Project intPrj = null;
				sc.prjExists("Business_Interfaces",ref intPrj);
				sc.ImpInterface("Business_Components",intPrj ,(CodeInterface) t.Tag, ref cc);
		
			} 
		}
		private void mnuAddBInterface_Click(object sender, System.EventArgs e)
		{   
			frmAddInterface frmAI = new frmAddInterface();
			if (frmAI.ShowDialog() == DialogResult.OK )
			{
				
				string intName,intNotes;
				intName = frmAI.tbxIntName.Text.Trim().Replace(" ","_");
				intNotes = frmAI.txbNotes.Text.Trim();
				CodeInterface ci=null;
				sc.AddInterface(intName,intNotes,"Business_Interfaces",ref ci);
				TreeNode addTemp = new TreeNode("",4,4);
				addTemp.Text= intName;
				addTemp.Tag=ci;
				tv.SelectedNode.Nodes.Add (addTemp);
				tv.SelectedNode.ExpandAll();
			}
		}

		private void mnuImpDClasses_Click(object sender, System.EventArgs e)
		{   
			
			
			CodeClass cc = null;
			TreeNode tn = tv.SelectedNode;
			foreach(TreeNode t in tn.Nodes )
			{
				Project intPrj = null;
				sc.prjExists("Data_Interfaces",ref intPrj);
				sc.ImpInterface("Data_Components",intPrj ,(CodeInterface) t.Tag, ref cc);

		
			}
		}
			
		private void mnuAddDInterface_Click(object sender, System.EventArgs e)
		{   
			frmAddInterface frmAI = new frmAddInterface();
			if (frmAI.ShowDialog() == DialogResult.OK )
			{
				
				string intName,intNotes;
				intName = frmAI.tbxIntName.Text.Trim().Replace(" ","_");
				intNotes = frmAI.txbNotes.Text.Trim();
				CodeInterface ci=null;
				sc.AddInterface(intName,intNotes,"Data_Interfaces",ref ci);
				TreeNode addTemp = new TreeNode("",4,4);
				addTemp.Text= intName;
				addTemp.Tag=ci;
				tv.SelectedNode.Nodes.Add (addTemp);
				tv.SelectedNode.ExpandAll();
			}
		}

		private void treeRefresh(TreeNode tn)
		{
			tn.Nodes.Clear();
			
		}
	}
}
