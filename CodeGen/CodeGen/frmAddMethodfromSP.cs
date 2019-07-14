using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CodeGen
{
	/// <summary>
	/// Summary description for frmAddMethodfromSP.
	/// </summary>
	public class frmAddMethodfromSP : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.TextBox txtName;
		public System.Windows.Forms.ComboBox cbxSP;
		private System.Windows.Forms.Label label2;
		public SqlParameterCollection spc;
		Dg db;
		public System.Windows.Forms.CheckBox cbxRDT;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAddMethodfromSP()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddMethodfromSP));
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.cbxSP = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxRDT = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "Method Name:";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(168, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(328, 21);
			this.txtName.TabIndex = 2;
			this.txtName.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(424, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(328, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 32);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// cbxSP
			// 
			this.cbxSP.Location = new System.Drawing.Point(168, 56);
			this.cbxSP.Name = "cbxSP";
			this.cbxSP.Size = new System.Drawing.Size(328, 21);
			this.cbxSP.TabIndex = 8;
			this.cbxSP.SelectedIndexChanged += new System.EventHandler(this.cbxSP_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Stored Procedure:";
			// 
			// cbxRDT
			// 
			this.cbxRDT.Location = new System.Drawing.Point(168, 96);
			this.cbxRDT.Name = "cbxRDT";
			this.cbxRDT.Size = new System.Drawing.Size(144, 24);
			this.cbxRDT.TabIndex = 11;
			this.cbxRDT.Text = "Return DataTable ?";
			// 
			// frmAddMethodfromSP
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(512, 164);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cbxRDT,
																		  this.label2,
																		  this.cbxSP,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.txtName,
																		  this.label1});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAddMethodfromSP";
			this.ShowInTaskbar = false;
			this.Text = "Add Method from Stored Procedure";
			this.Load += new System.EventHandler(this.frmAddMethodfromSP_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAddMethodfromSP_Load(object sender, System.EventArgs e)
		{
			string connectionstring = "Initial Catalog=CodeGen;Data Source=localhost;Integrated Security=SSPI;";

			db = new Dg(connectionstring);
			DataTable dt = db.GetSPList();			
			foreach (DataRow dr in dt.Rows)
			{
				this.cbxSP.Items.Add(dr[0]);
			}
		
		}

		private void btnOK_Click(object sender, System.EventArgs  e)
		{
			spc = db.getSPParameters(this.cbxSP.SelectedItem.ToString());
		}

		private void cbxSP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.txtName.Text.Trim().Length > 0)
			{
				this.txtName.Text=this.cbxSP.SelectedItem.ToString();
			}
		}
	}
}
