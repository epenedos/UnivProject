using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeGen
{
	/// <summary>
	/// Summary description for frmNewProject.
	/// </summary>
	public class frmNewProject : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtProject;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNewProject()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtProject = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(440, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(344, 96);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 32);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Project Name:";
			// 
			// txtProject
			// 
			this.txtProject.Location = new System.Drawing.Point(264, 48);
			this.txtProject.MaxLength = 25;
			this.txtProject.Name = "txtProject";
			this.txtProject.Size = new System.Drawing.Size(240, 21);
			this.txtProject.TabIndex = 7;
			this.txtProject.Text = "";
			// 
			// frmNewProject
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(528, 142);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtProject,
																		  this.label1,
																		  this.btnCancel,
																		  this.btnOK});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmNewProject";
			this.Text = "New Project";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
