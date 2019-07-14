using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CodeGenerator.Model;

namespace CodeGenerator
{
	/// <summary>
	/// Summary description for frmOpenModel.
	/// </summary>
	public class frmOpenModel : System.Windows.Forms.Form
	{
		public Guid ModelID;
		private System.Windows.Forms.TreeView treeView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOpenModel(ModelApi mdl)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			DataTable dt = mdl.listModels();
			for (int curRow = 0;curRow < dt.Rows.Count;curRow++)
			{
				TreeNode tn = new TreeNode(dt.Rows[curRow][1].ToString().Trim());
				tn.Tag=dt.Rows[curRow][0];
				this.treeView1.Nodes.Add(tn);
			}
			
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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.FullRowSelect = true;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(16, 24);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.ShowLines = false;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(376, 136);
			this.treeView1.Sorted = true;
			this.treeView1.TabIndex = 0;
			this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// frmOpenModel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(408, 182);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.treeView1});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmOpenModel";
			this.ShowInTaskbar = false;
			this.Text = "Open Model";
			this.ResumeLayout(false);

		}
		#endregion

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
		
		}

		private void treeView1_DoubleClick(object sender, System.EventArgs e)
		{
			this.ModelID=(Guid) treeView1.SelectedNode.Tag;
			this.DialogResult=DialogResult.OK;
		}

		

		
	}
}
