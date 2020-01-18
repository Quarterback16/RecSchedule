using System;
using System.Xml;

namespace RecSchedule.Model
{
	public class CountItem
	{
        public string Name { get; set; }
        public int Count { get; set; }

        public CountItem(
            string name,
            int count)
        {
            Name = name;
            Count = count;
        }

        public CountItem(
			XmlNode node)
		{
            foreach (XmlNode n in node.ChildNodes)
            {
                switch (n.Name)
                {
                    case "name":
                        Name = n.InnerText;
                        break;

                    case "count":
                        Count = Int32.Parse(n.InnerText);
                        break;

                    default:
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Count}";
        }
	}
}
