//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using EnvDTE;

namespace CodeGen
{
	/// <summary>
	/// The interface for the Extender object. It implements three properties:
	/// [get/set]     Property Notes As String
	/// [get]         Property Created As Date
	/// [get]         Property LastAccessed As Date
	/// [get]         Property LastModified As Date
	/// </summary>
	[System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsDual)]
	public interface IProjectExtender
	{	
		string Notes
		{
			get;
			set;
		}
		
		string ProjectType
		{
			get;
			set;
		}


		System.DateTime Created
		{
			get;
		}

		System.DateTime LastAccessed
		{
			get;
		}

		System.DateTime LastModified
		{
			get;
		}

	};


	/// <summary>
	/// This is the Extender Object itself.
	/// </summary>
	[System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
	public class ProjExtender : IProjectExtender
	{
		/// <summary>
		/// Notes property stores its value in the Solution.Globals object and hence 
		/// is persisted with the solution.
		/// </summary>
		public string Notes
		{
			get
			{ 
				EnvDTE.Globals glob = Sol.Globals;
				if (!glob.get_VariableExists(NotesProperty))
				{
					glob[NotesProperty] = "";
					glob.set_VariablePersists(NotesProperty, true);
				}
            
				return glob[NotesProperty].ToString();
			}
			set
			{
				EnvDTE.Globals glob = Sol.Globals;
				glob[NotesProperty] = value;
				glob.set_VariablePersists(NotesProperty, true);
			}
		}		

		public string ProjectType
		{
			get
			{
				EnvDTE.Globals glob = Sol.Globals;
				if (!glob.get_VariableExists(NotesProperty))
				{
					glob[NotesProperty] = "";
					glob.set_VariablePersists(NotesProperty, true);
				}
            
				return glob[NotesProperty].ToString();
			}
			set
			{
				EnvDTE.Globals glob = Sol.Globals;
				glob[NotesProperty] = value;
				glob.set_VariablePersists(NotesProperty, true);
			}
		}

		/// <summary>
		/// Created property indicates when the Solution file was created.
		/// </summary>
		public System.DateTime Created
		{
			get
			{
				//Simply get the file creation date/time.
				return System.IO.File.GetCreationTime(Sol.FullName);
			}
		}

		/// <summary>
		/// LastAccessed property indicates when the Solution file was last accessed.
		/// </summary>
		public System.DateTime LastAccessed
		{
			get
			{
				//Simply get the last file access date/time.
				return System.IO.File.GetLastAccessTime(Sol.FullName);
			}
		}

		/// <summary>
		/// LastModified property indicates when the Solution file was saved.
		/// </summary>
		public System.DateTime LastModified
		{
			get
			{
				//Simply get the last file write date/time.
				return System.IO.File.GetLastWriteTime(Sol.FullName);
			}
		}

		/// <summary>
		/// Constructor does nothing. All initialization work is done in Init.
		/// </summary>
		public ProjExtender()
		{
		}

		/// <summary>
		/// Initializes the members of the SolnExtender class.
		/// </summary>
		/// <param name="sln">DTE.Solution object.</param>
		/// <param name="ExtenderCookie">Cookie value that identifies the Extender to its Site.</param>
		/// <param name="ExtenderSite">Site object for the Extender.</param>
		public void Init(EnvDTE.Solution sln, int ExtenderCookie, EnvDTE.IExtenderSite ExtenderSite)
		{
			Site = ExtenderSite;
			Cookie = ExtenderCookie;
			Sol = sln;
		}

		/// <summary>
		/// Tells the Site object we are going away.
		/// </summary>
		~ProjExtender()
		{
			// Wrap this call in a try-catch to avoid any failure code the
			// Site may return. For instance, since this object is GC'ed,
			// the Site may have already let go of its Cookie.
			try
			{
				if (Site != null)
					Site.NotifyDelete(Cookie);
			}
			catch 
			{
			}
		}

		//Data members of the class.
		int Cookie;
		EnvDTE.IExtenderSite Site;
		EnvDTE.Solution Sol;
		string NotesProperty = "ThisSolutionNotes";
	}
}
