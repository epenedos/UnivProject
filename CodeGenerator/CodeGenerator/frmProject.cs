using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CodeGenerator;
using CodeGenerator.Model;



namespace CodeGenerator
{
	/// <summary>
	/// Summary description for frmProject.
	/// </summary>
	public class frmProject : System.Windows.Forms.Form
	{
		private ModelApi mdl;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.TreeView tvwProject;
		private System.ComponentModel.IContainer components;


		public frmProject(ModelApi mdl)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.mdl=mdl;
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProject));
			this.tvwProject = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// tvwProject
			// 
			this.tvwProject.BackColor = System.Drawing.Color.Silver;
			this.tvwProject.FullRowSelect = true;
			this.tvwProject.ImageList = this.imageList1;
			this.tvwProject.LabelEdit = true;
			this.tvwProject.Name = "tvwProject";
			this.tvwProject.SelectedImageIndex = 1;
			this.tvwProject.Size = new System.Drawing.Size(232, 384);
			this.tvwProject.TabIndex = 0;
			this.tvwProject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwProject_MouseDown);
			this.tvwProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwProject_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(20, 20);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Add Package";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Add Interface";
			// 
			// frmProject
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 382);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tvwProject});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProject";
			this.Text = "Project";
			this.ResumeLayout(false);

		}
		#endregion

		public void refresh_IM()
		{
			TreeNode tn = new TreeNode("Interfaces",5,5);
			tn.Tag="MENUINTERFACES";

			this.tvwProject.Nodes.Add(tn);
			TreeNode tnDI = new TreeNode("Data Interfaces",0,0);
			tnDI.Tag="DATAINTERFACES";
			TreeNode tnBI = new TreeNode("Business Interfaces",0,0);
			tnBI.Tag="BUSINESSINTERFACES";
			InterfaceModelApi im = new InterfaceModelApi(mdl);
			DataTable dtInt,dtMet;
			dtInt = im.listInterfaces();
			for (int curRow = 0;curRow < dtInt.Rows.Count;curRow++)
			{
				
				TreeNode tmpInt = new TreeNode(dtInt.Rows[curRow][2].ToString().Trim(),1,1);
				tmpInt.Tag="INTERFACE" + dtInt.Rows[curRow][1].ToString().Trim();
				dtMet = im.listMethods((Guid) dtInt.Rows[curRow][1]);
				for(int metRow=0;metRow <dtMet.Rows.Count;metRow++)
				{
					TreeNode tmpMet = new TreeNode(dtMet.Rows[metRow][3].ToString().Trim(),2,2);
					tmpMet.Tag="METHOD" + dtMet.Rows[metRow][2].ToString().Trim();
					tmpInt.Nodes.Add(tmpMet);
				}
				tnDI.Nodes.Add(tmpInt);
			}

			tn.Nodes.Add(tnDI);
			tn.Nodes.Add(tnBI);

		}


		public void refresh_CM()
		{
			TreeNode tn = new TreeNode("Components",3,3);
			tn.Tag="MENUCOMPONENTS";

			this.tvwProject.Nodes.Add(tn);
			TreeNode tnDA = new TreeNode("Data Access Components",0,0);
			tnDA.Tag="DATACOMPONENTS";
			TreeNode tnBR = new TreeNode("Business Rules Componentes",0,0);
			tnBR.Tag="BUSINESSRULESCOMPONENTS";
			TreeNode tnBF = new TreeNode("Business Facade Componentes",0,0);
			tnBF.Tag="BUSINESSFACADECOMPONENTS";


			InterfaceModelApi im = new InterfaceModelApi(mdl);
			DataTable dtInt,dtMet;
			dtInt = im.listInterfaces();
			for (int curRow = 0;curRow < dtInt.Rows.Count;curRow++)
			{
				
				TreeNode tmpInt = new TreeNode(dtInt.Rows[curRow][2].ToString().Trim(),1,1);
				tmpInt.Tag="INTERFACE" + dtInt.Rows[curRow][1].ToString().Trim();
				dtMet = im.listMethods((Guid) dtInt.Rows[curRow][1]);
				for(int metRow=0;metRow <dtMet.Rows.Count;metRow++)
				{
					TreeNode tmpMet = new TreeNode(dtMet.Rows[metRow][3].ToString().Trim(),2,2);
					tmpMet.Tag="METHOD" + dtMet.Rows[metRow][2].ToString().Trim();
					tmpInt.Nodes.Add(tmpMet);
				}
				tnDA.Nodes.Add(tmpInt);
			}

			tn.Nodes.Add(tnDA);
			tn.Nodes.Add(tnBR);
			tn.Nodes.Add(tnBF);
		}

		public void refresh_PM()
		{
			TreeNode tn = new TreeNode("Solution",7,7);
			tn.Tag="MENUPROJECTS";

			this.tvwProject.Nodes.Add(tn);
			TreeNode tnDA = new TreeNode("Data Access Projects",0,0);
			tnDA.Tag="DATAPROJECTS";
			TreeNode tnBR = new TreeNode("Business Rules Projects",0,0);
			tnBR.Tag="BUSINESSRULESPROJECTS";
			TreeNode tnBF = new TreeNode("Business Facade Projects",0,0);
			tnBF.Tag="BUSINESSFACADEPROJECTS";
			TreeNode tnCS = new TreeNode("Client Stub Projects",0,0);
			tnCS.Tag="CLIENTSTUBPROJECTS";


			InterfaceModelApi im = new InterfaceModelApi(mdl);
			DataTable dtInt,dtMet;
			dtInt = im.listInterfaces();
			for (int curRow = 0;curRow < dtInt.Rows.Count;curRow++)
			{
				
				TreeNode tmpInt = new TreeNode(dtInt.Rows[curRow][2].ToString().Trim(),1,1);
				tmpInt.Tag="INTERFACE" + dtInt.Rows[curRow][1].ToString().Trim();
				dtMet = im.listMethods((Guid) dtInt.Rows[curRow][1]);
				for(int metRow=0;metRow <dtMet.Rows.Count;metRow++)
				{
					TreeNode tmpMet = new TreeNode(dtMet.Rows[metRow][3].ToString().Trim(),2,2);
					tmpMet.Tag="METHOD" + dtMet.Rows[metRow][2].ToString().Trim();
					tmpInt.Nodes.Add(tmpMet);
				}
				tnDA.Nodes.Add(tmpInt);
			}

			tn.Nodes.Add(tnDA);
			tn.Nodes.Add(tnBR);
			tn.Nodes.Add(tnBF);
			tn.Nodes.Add(tnCS);
		}



		private void tvwProject_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		
		}

		private void tvwProject_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Right)
			{
				if (this.tvwProject.SelectedNode.Tag.ToString().StartsWith("INTERFACE"))
				{
					this.contextMenu1.MenuItems.Clear();
					MenuItem mnuAddMethod = new MenuItem("Add Method");
					MenuItem mnuDetails = new MenuItem("Details");
					MenuItem mnuImplement = new MenuItem("Implement Component Class");
					this.contextMenu1.MenuItems.Add(mnuAddMethod);
					this.contextMenu1.MenuItems.Add(mnuDetails);
					this.contextMenu1.MenuItems.Add("-");
					this.contextMenu1.MenuItems.Add(mnuImplement);
					Point pt = new Point(e.X,e.Y);
					this.contextMenu1.Show(this.tvwProject,pt );
				}
				
			}
		}

	}
}
