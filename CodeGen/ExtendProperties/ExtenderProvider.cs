//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using EnvDTE;

namespace CodeGen
{
	/// <summary>
	/// Extender Provider object. This is the "class factory" for the Extender and is registered
	/// under the CATIDs of the solution objects (vsCATIDSolution and vsCATIDSolutionBrowseObject)
	/// it is extending. See SolutionExtender.reg for the registration entries.
	/// </summary>
	[GuidAttribute("D629F716-77FE-49cd-8F9A-564111B80AFF"), ProgId("CodeGen.Extender")]	
	public class ExtenderProvider : Object, IExtenderProvider
	{
		/// <summary>
		/// Constructor does nothing special.
		/// </summary>
		public ExtenderProvider()
		{
		}

		//IExtenderProvider implementation

		/// <summary>
		/// Implementation of IExtenderProvider::CanExtend.
		/// </summary>
		/// <param name="ExtenderCATID">CATID of the object being extended.</param>
		/// <param name="ExtenderName">Name of the Extension.</param>
		/// <param name="ExtendeeObject">Object being extended.</param>
		/// <returns>true if can provide an extender for Extendee Object, false otherwise.</returns>
		public bool CanExtend(string ExtenderCATID, string ExtenderName, object ExtendeeObject)
		{
			//Extends the solution automation and browseobject unconditionally. 
			//The extension name is given by SlnAutExtension ("SolutionMisc").
			if (((ExtenderCATID.ToUpper() == EnvDTE.Constants.vsCATIDSolutionBrowseObject.ToUpper()) ||
				(ExtenderCATID.ToUpper() == EnvDTE.Constants.vsCATIDSolution.ToUpper())) &&
				ExtenderName.ToUpper() == SlnAutExtension.ToUpper())
			{
				return true;
			}
			else
			{
				if (ExtenderName.ToUpper() == SlnAutExtension.ToUpper())
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// Implementation of IExtenderProvider::GetExtender.
		/// </summary>
		/// <param name="ExtenderCATID">CATID of the object being extended.</param>
		/// <param name="ExtenderName">Name of the Extension.</param>
		/// <param name="ExtendeeObject">Object being extended.</param>
		/// <param name="ExtenderSite">Site object for the Extender.</param>
		/// <param name="cookie">Cookie value that identifies the Extender to its Site.</param>
		/// <returns>A newly created Extender object.</returns>
		public object GetExtender(string ExtenderCATID, string ExtenderName, object ExtendeeObject, EnvDTE.IExtenderSite ExtenderSite, int Cookie)
		{
			object Extender = null; //In case of failure.

			if (CanExtend(ExtenderCATID, ExtenderName, ExtendeeObject))
			{
				//Note: More complicated implementations can keep a map of Extendees and Extenders 
				//they have given out, so that if asked for again for the same Extendee Extender
				//you don't have to recreate it again. In our case, the Extenders are very
				//light-weight objects and have little direct interaction with the Extendee, so
				//we don't bother.
	
				SolnExtender slnext = new SolnExtender();
				
				EnvDTE.Solution sln = null;

				//Get the solution automation object.
				//We don't need to interact with the Extendee object much since we go
				//directly to the Solution automation object for our needs, but most
				//implementations would talk directly to the Extendee object to extend/shadow
				//its properties.
				sln = ExtendeeObject as EnvDTE.Solution;
				if (sln == null)
				{
					//Extending the Soltuion browse object (the object that's displayed
					//in the property browser when the Solution Node is selected in
					//the Solution Explorer). In this case, get the DTE.Solution object
					//directly from the object model.
					EnvDTE.DTE root = (EnvDTE.DTE) ExtenderSite.GetObject("");
					sln = root.Solution;
				}
            
				if (sln != null)
				{
					//Init our extender.
					slnext.Init(sln, Cookie, ExtenderSite);
					Extender = slnext;
				}
			}

			return Extender;
		}

		/// <summary>
		/// The Extension name for this Extender.
		/// </summary>
		private string SlnAutExtension = "SolutionMisc";
	}
}

	/// 
	
