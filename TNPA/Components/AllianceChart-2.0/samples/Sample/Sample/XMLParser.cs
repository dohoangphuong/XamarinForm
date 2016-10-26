using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Collections.Generic;
using MonoTouch.CoreText;

namespace Default.Namespace
{
    public class XMLParser
    {
        public static XMLElement Parse(NSData data)
        {
            XmlParserDelegate parserDelegate = new XmlParserDelegate();
            NSXMLParser parser = new NSXMLParser(data);
            parser.SetDelegate(parserDelegate);
            parser.Parse();
            XMLElement root = parserDelegate.Root();
            return root;
        }

    }
}

