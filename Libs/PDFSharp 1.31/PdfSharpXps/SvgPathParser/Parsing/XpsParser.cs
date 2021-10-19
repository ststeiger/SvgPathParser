using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.IO;
using PdfSharp.Xps.XpsModel;

namespace PdfSharp.Xps.Parsing
{
    /// <summary>
    /// Simple XPS parser.
    /// The parser is not a syntax checker and therefore expects well-defined XPS XML to work properly.
    /// </summary>
    partial class XpsParser
    {

        XmlTextReader reader;



        public XpsParser(XmlTextReader rdr)
        {
            this.reader = rdr;
        }


        void UnexpectedAttribute(string name)
        {
            throw new System.NotImplementedException(name);
        }


        /// <summary>
        /// Parses a boolean value element.
        /// </summary>
        bool ParseBool(string value)
        {
            return Boolean.Parse(value);
        }

        /// <summary>
        /// Parses a double value element.
        /// </summary>
        internal static double ParseDouble(string value)
        {
            return Double.Parse(value.Replace(" ", ""), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Parses an enum value element.
        /// </summary>
        T ParseEnum<T>(string value) where T : struct
        {
            return (T)Enum.Parse(typeof(T), value);
        }


        /// <summary>
        /// Moves to next attribute of the current element.
        /// </summary>
        bool MoveToNextAttribute()
        {
            return this.reader.MoveToNextAttribute();
        }

        /// <summary>
        /// Moves to next element by skipping all white space.
        /// Returns true if XmlNodeType.Element is the current node type.
        /// </summary>
        bool MoveToNextElement()
        {
            bool success = this.reader.Read();
            if (success)
            {
                XmlNodeType type = this.reader.MoveToContent();
                Debug.Assert(type == XmlNodeType.Element || type == XmlNodeType.EndElement || type == XmlNodeType.None);
                success = type == XmlNodeType.Element;
            }
            return success;
        }

        /// <summary>
        /// Moves to first element after the current element with the specified name.
        /// </summary>
        void MoveBeyondThisElement() // string name, int depth)
        {
            if (!this.reader.IsEmptyElement && this.reader.NodeType != XmlNodeType.Comment)
            {
                if (this.reader.NodeType == XmlNodeType.XmlDeclaration)
                {
                    MoveToNextElement();
                    return;
                }
                else if (this.reader.NodeType == XmlNodeType.Attribute)
                {
                    this.reader.MoveToElement();
                    if (this.reader.IsEmptyElement)
                    {
                        MoveToNextElement();
                        return;
                    }
                }
                MoveToNextElement();
                while (this.reader.IsStartElement())
                    MoveBeyondThisElement();
            }
            MoveToNextElement(); // next element
        }

    }
}