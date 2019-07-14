using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeGen
{
	/// <summary>
	/// Summary description for AddInterface.
	/// </summary>
	public class frmAddInterface : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox tbxIntName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txbNotes;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddInterface()
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbxIntName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txbNotes = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Interface Name:";
			// 
			// tbxIntName
			// 
			this.tbxIntName.Location = new System.Drawing.Point(144, 32);
			this.tbxIntName.MaxLength = 50;
			this.tbxIntName.Name = "tbxIntName";
			this.tbxIntName.Size = new System.Drawing.Size(344, 21);
			this.tbxIntName.TabIndex = 1;
			this.tbxIntName.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(328, 232);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 32);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(416, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Notes:";
			// 
			// txbNotes
			// 
			this.txbNotes.Location = new System.Drawing.Point(144, 64);
			this.txbNotes.Multiline = true;
			this.txbNotes.Name = "txbNotes";
			this.txbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txbNotes.Size = new System.Drawing.Size(344, 152);
			this.txbNotes.TabIndex = 5;
			this.txbNotes.Text = "";
			// 
			// frmAddInterface
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(504, 278);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txbNotes,
																		  this.label2,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.tbxIntName,
																		  this.label1});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddInterface";
			this.ShowInTaskbar = false;
			this.Text = "Add Interface";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.tbxIntName.Text.Length ==0)
			{
				MessageBox.Show("The Interface must have a name","CodeGen");
			}
			
		}
	}
}
