/*
 * $Id: DocumentStyles.cs,v 1.2 2005/11/20 17:31:20 larsbm Exp $
 */

using System;
using System.Xml;
using System.Reflection;
using System.IO;

namespace AODL.TextDocument
{
	/// <summary>
	/// DocumentStyles global Document Style
	/// </summary>
	public class DocumentStyles
	{
		/// <summary>
		/// The file name.
		/// </summary>
		public static readonly string FileName	= "styles.xml";

		private XmlDocument _styles;
		/// <summary>
		/// Gets or sets the styles.
		/// </summary>
		/// <value>The styles.</value>
		public XmlDocument Styles
		{
			get { return this._styles; }
			set { this._styles = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentStyles"/> class.
		/// </summary>
		public DocumentStyles()
		{
		}

		/// <summary>
		/// Load the style from assmebly resource.
		/// </summary>
		public void New()
		{
			try
			{
				Assembly ass		= Assembly.GetExecutingAssembly();
				Stream str			= ass.GetManifestResourceStream("AODL.Resources.OD.styles.xml");
				this.Styles			= new XmlDocument();
				this.Styles.Load(str);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Loads from file.
		/// </summary>
		/// <param name="file">The file.</param>
		public void LoadFromFile(string file)
		{
			try
			{
				this.Styles		= new XmlDocument();
				this.Styles.Load(file);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}

/*
 * $Log: DocumentStyles.cs,v $
 * Revision 1.2  2005/11/20 17:31:20  larsbm
 * - added suport for XLinks, TabStopStyles
 * - First experimental of loading dcuments
 * - load and save via importer and exporter interfaces
 *
 * Revision 1.1  2005/11/06 14:55:25  larsbm
 * - Interfaces for Import and Export
 * - First implementation of IExport OpenDocumentTextExporter
 *
 */