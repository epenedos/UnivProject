using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Extensibility;
using System.Runtime.InteropServices;
using EnvDTE;

namespace CodeGen
{
	/// <summary>
	/// Summary description for CodeWindow.
	/// </summary>
	public class CodeWindow : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.ToolBar tlbModel;
		public System.Windows.Forms.TreeView tvwModel;
		private System.Windows.Forms.ImageList imgList;
		public System.Windows.Forms.ContextMenu ctxMenu;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.ComponentModel.IContainer components;
		public _DTE appOb;
		private TreeNode tnModel;
		public SourceCode sc;
		public CodeWindow()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		

			// TODO: Add any initialization after the InitForm call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CodeWindow));
			this.tlbModel = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.tvwModel = new System.Windows.Forms.TreeView();
			this.ctxMenu = new System.Windows.Forms.ContextMenu();
			this.SuspendLayout();
			// 
			// tlbModel
			// 
			this.tlbModel.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2});
			this.tlbModel.DropDownArrows = true;
			this.tlbModel.ImageList = this.imgList;
			this.tlbModel.Name = "tlbModel";
			this.tlbModel.ShowToolTips = true;
			this.tlbModel.Size = new System.Drawing.Size(248, 39);
			this.tlbModel.TabIndex = 0;
			this.tlbModel.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbModel_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 8;
			this.toolBarButton1.Tag = "NEWMODEL";
			this.toolBarButton1.Text = "New Model";
			this.toolBarButton1.ToolTipText = "Create a new Model";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Text = "Syncronize Model View";
			// 
			// imgList
			// 
			this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvwModel
			// 
			this.tvwModel.BackColor = System.Drawing.SystemColors.Window;
			this.tvwModel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwModel.ImageIndex = 1;
			this.tvwModel.ImageList = this.imgList;
			this.tvwModel.Location = new System.Drawing.Point(0, 39);
			this.tvwModel.Name = "tvwModel";
			this.tvwModel.Size = new System.Drawing.Size(248, 217);
			this.tvwModel.TabIndex = 1;
			this.tvwModel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwModel_MouseDown);
			this.tvwModel.Click += new System.EventHandler(this.tvwModel_Click);
			this.tvwModel.DoubleClick += new System.EventHandler(this.tvwModel_DoubleClick);
			this.tvwModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwModel_AfterSelect);
			this.tvwModel.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwModel_AfterLabelEdit);
			// 
			// ctxMenu
			// 
			this.ctxMenu.Popup += new System.EventHandler(this.ctxMenu_Popup);
			// 
			// CodeWindow
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tvwModel,
																		  this.tlbModel});
			this.Name = "CodeWindow";
			this.Size = new System.Drawing.Size(248, 256);
			this.ResumeLayout(false);

		}
		#endregion

		

		private void tlbModel_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if ((string) e.Button.Tag == "NEWMODEL")
			{
				sc = new SourceCode(appOb);
				appOb.Solution.Create("c:\\CodeGen\\Eduardo","Eduardo");
				this.tvwModel.Nodes.Clear();
				tnModel = new TreeNode("Eduardo",0,0);
				CreateTree(tnModel);
				this.tvwModel.Nodes.Add(tnModel);
			}
		
			if ((string) e.Button.Tag == "REFRESH")
			{
				
			}
		
		}

		private void CreateTree(TreeNode tnModel)
		{
			TreeNode temp = new TreeNode("Data Catalog",1,2);
			temp.Tag="DATACATALOG";
			tnModel.Nodes.Add(temp);

			temp = new TreeNode("Interfaces",1,1);
			temp.Tag="INTERFACES";
			
			TreeNode temp1 = new TreeNode("Data Interfaces",1,2);
			temp1.Tag="DATAINTERFACES";
			temp.Nodes.Add(temp1);
			
			temp1 = new TreeNode("Business Interfaces",1,2);
			temp1.Tag="BUSINTERFACES";
			temp.Nodes.Add(temp1);
			tnModel.Nodes.Add(temp);

			temp = new TreeNode("Components",1,2);
			temp.Tag="COMPONENTS";

			temp1 = new TreeNode("Data Components",1,2);
			temp1.Tag="DATACOMPONENTS";
			temp.Nodes.Add(temp1);
			
			temp1 = new TreeNode("Business Rules Components",1,2);
			temp1.Tag="BUSRULESCOMPONENTS";
			temp.Nodes.Add(temp1);
			
			temp1 = new TreeNode("Business Facade Components",1,2);
			temp1.Tag="BUSFACADECOMPONENTS";
			temp.Nodes.Add(temp1);

			tnModel.Nodes.Add(temp);
			

		}

		private void tvwModel_Click(object sender, System.EventArgs e)
		{
			
		}

		private void tvwModel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tvwModel.SelectedNode = tvwModel.GetNodeAt(e.X,e.Y);
			if(e.Button==MouseButtons.Right)
			{
				PopUps pu = new PopUps(ref sc,ref this.tvwModel,ref this.ctxMenu, e );	
			}

		}
	


		private void ctxMenu_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void tvwModel_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			
		}

		private void tvwModel_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		
		}

		private void tvwModel_DoubleClick(object sender, System.EventArgs e)
		{
			sc.TryToShow(tvwModel.SelectedNode.Tag);

			
		}


	}
}