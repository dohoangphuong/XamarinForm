using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Collections.Generic;
using MonoTouch.CoreText;

namespace BarChart
{
    public class XmlParserDelegate : NSXMLParserDelegate
    {
        protected XMLElement root;
        protected ArrayList elementStack;
        public XMLElement Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }

        public void ParserDidStartDocument(NSXMLParser parser)
        {
            elementStack = new ArrayList();
        }

        public void ParserDidStartElementNamespaceURIQualifiedNameAttributes(NSXMLParser parser, string elementName, string namespaceURI, string qName, NSDictionary attributeDict)
        {
            if (elementStack.Count == 0)
            {
                root = new XMLElement();
                root.Name = elementName;
                root.Attributes.AddEntriesFromDictionary(attributeDict);
                elementStack.Add(this.Root);
            }
            else
            {
                XMLElement el = elementStack.LastObject().AppendElement(elementName);
                el.Attributes.AddEntriesFromDictionary(attributeDict);
                elementStack.Add(el);
            }

        }

        public void ParserDidEndElementNamespaceURIQualifiedName(NSXMLParser parser, string elementName, string namespaceURI, string qName)
        {
            if (elementStack.Count > 0) elementStack.RemoveLastObject();
        }

        public void ParserFoundCharacters(NSXMLParser parser, string theString)
        {
            XMLElement el = elementStack.LastObject();
            if (el != null) el.InnerText = el.InnerText.TheStringByAppendingString(theString);
        }

    }
}
