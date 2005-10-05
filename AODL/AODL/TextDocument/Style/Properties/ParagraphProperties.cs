using System;
using System.Xml;
using AODL.TextDocument.Style;

namespace AODL.TextDocument.Style.Properties
{
	/// <summary>
	/// Represent access to the possible attributes of of an paragraph-propertie element.
	/// </summary>
	public class ParagraphProperties : IProperty
	{
		private ParagraphStyle _paragraphStyle;
		/// <summary>
		/// The ParagraphStyle object to this object belongs.
		/// </summary>
		public ParagraphStyle Paragraphstyle
		{
			get { return this._paragraphStyle; }
			set { this._paragraphStyle = value; }
		}

		private XmlNode _node;
		/// <summary>
		/// The represented XmlNode.
		/// </summary>
		public XmlNode Node
		{
			get { return this._node; }
			set { this._node = value; }
		}

		/// <summary>
		/// Margin left. in cm an object .MarginLeft = "1cm";
		/// </summary>
		public string MarginLeft
		{
			get { return this._node.SelectSingleNode("@fo:margin-left", 
					  this.Paragraphstyle.Paragraph.Document.NamespaceManager).InnerText; }
			set { this._node.SelectSingleNode("@fo:margin-left",
					  this.Paragraphstyle.Paragraph.Document.NamespaceManager).InnerText = value; }
		}

		/// <summary>
		/// Set paragraph alignment - object.Alignment = TextAlignments.right.ToString()
		/// </summary>
		public string Alignment
		{
			get 
			{ 
				XmlNode xn = this._node.SelectSingleNode("@fo:text-align",
					this.Paragraphstyle.Paragraph.Document.NamespaceManager);
				if(xn != null)
					return xn.InnerText;
				return null;
			}
			set
			{
				XmlNode xn = this._node.SelectSingleNode("@fo:text-align",
					this.Paragraphstyle.Paragraph.Document.NamespaceManager);
				if(xn == null)
					this.CreateAttribute("text-align", value, "fo");
				this._node.SelectSingleNode("@fo:text-align",
					this.Paragraphstyle.Paragraph.Document.NamespaceManager).InnerText = value;
			}
		}

		/// <summary>
		/// Create a new ParagraphProperties object.
		/// </summary>
		/// <param name="pstyle">The ParagraphStyle object to this object belongs.</param>
		public ParagraphProperties(ParagraphStyle pstyle)
		{
			this.Paragraphstyle = pstyle;
			this.NewXmlNode(pstyle.Paragraph.Document);
		}

		/// <summary>
		/// Create a XmlAttribute for propertie XmlNode.
		/// </summary>
		/// <param name="name">The attribute name.</param>
		/// <param name="text">The attribute value.</param>
		/// <param name="prefix">The namespace prefix.</param>
		private void CreateAttribute(string name, string text, string prefix)
		{
			XmlAttribute xa = this.Paragraphstyle.Paragraph.Document.CreateAttribute(name, prefix);
			xa.Value		= text;
			this.Node.Attributes.Append(xa);
		}

		/// <summary>
		/// Create the XmlNode.
		/// </summary>
		/// <param name="td">The TextDocument.</param>
		private void NewXmlNode(TextDocument td)
		{
			this.Node		= td.CreateNode("paragraph-properties", "style");
			XmlAttribute xa = td.CreateAttribute("margin-left", "fo");
			xa.Value		= "0cm";

			this.Node.Attributes.Append(xa);
		}
	}
}