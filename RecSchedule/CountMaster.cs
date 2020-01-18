using RecSchedule.Model;
using System.Xml;

namespace RecSchedule
{
	public class CountMaster : XmlCache
	{
        public CountMaster(
            string logFileName) : base("Counts")
        {
            Filename = logFileName;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(logFileName);
            var listNode = XmlDoc.ChildNodes[2];  //  my convention is to always have a comment in ur xml file
            foreach (XmlNode node in listNode.ChildNodes)
                AddXmlCount(node);
        }
        private void AddXmlCount(
            XmlNode node)
        {
            AddCount(
                new CountItem(node));
        }

        private void AddCount(
            CountItem item)
        {
            PutItem(item);
        }

        public void PutItem(
            CountItem item)
        {
            var name = item.Name;
            if (!TheHt.ContainsKey(name))
            {
                TheHt.Add(
                    key: name,
                    value: item);
                IsDirty = true;
            }
            else
                TheHt[name] = item;
        }

        public void Dump2Xml()
        {
            if ((TheHt.Count > 0) && IsDirty)
            {
                var writer = new XmlTextWriter(
                    filename: $"{Filename}",
                    encoding: null)
                {
                    Formatting = Formatting.Indented
                };
                writer.WriteStartDocument();

                writer.WriteComment("Comments: " + Name);
                writer.WriteStartElement("counter-list");

                var myEnumerator = TheHt.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    var item = (CountItem) myEnumerator.Value;
                    WriteCountNode(writer, item);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        private void WriteCountNode(
            XmlTextWriter writer, 
            CountItem item)
        {
            writer.WriteStartElement("counter-item");
            WriteElement(writer, "name", item.Name);
            WriteElement(writer, "count", item.Count.ToString());
            writer.WriteEndElement();
        }
    }
}
