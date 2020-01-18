using RecSchedule.Helpers;
using System.Collections;
using System.Xml;
using System.Xml.XPath;

namespace RecSchedule
{
	public class XmlCache : ICache
	{
		protected XPathDocument EpXmlDoc;
		protected XPathNavigator Nav;

		public int CacheHits { get; set; }

		public int CacheMisses { get; set; }

		public bool IsDirty { get; set; }

		public XmlDocument XmlDoc { get; set; }

		public Hashtable TheHt { get; set; }

		public string Filename { get; set; }

		public string Name { get; set; }

		public XmlCache(
			string entityName)
		{
			CacheMisses = 0;
			CacheHits = 0;
			IsDirty = false;

			Name = entityName;
			TheHt = new Hashtable();
		}

		public string StatsMessage()
		{
			return $"{Name} Cache hits {CacheHits} misses {CacheMisses}";
		}

		public static void WriteElement(
			XmlTextWriter writer,
			string name,
			string text)
		{
			writer.WriteStartElement(name);
			writer.WriteString(text);
			writer.WriteEndElement();
		}
	}
}
