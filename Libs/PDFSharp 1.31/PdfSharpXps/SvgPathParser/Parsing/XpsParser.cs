
using System.Diagnostics;
using System.Globalization;



namespace PdfSharp.Xps.Parsing
{


    /// <summary>
    /// Simple XPS parser.
    /// The parser is not a syntax checker and therefore expects well-defined XPS XML to work properly.
    /// </summary>
    public partial class XpsParser
    {

        System.Xml.XmlTextReader reader;



        public XpsParser(System.Xml.XmlTextReader rdr)
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
            return bool.Parse(value);
        }

        /// <summary>
        /// Parses a double value element.
        /// </summary>
        internal static double ParseDouble(string value)
        {
            return double.Parse(value.Replace(" ", ""), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Parses an enum value element.
        /// </summary>
        T ParseEnum<T>(string value) where T : struct
        {
            return (T)System.Enum.Parse(typeof(T), value);
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
                System.Xml.XmlNodeType type = this.reader.MoveToContent();
                Debug.Assert(type == System.Xml.XmlNodeType.Element || type == System.Xml.XmlNodeType.EndElement || type == System.Xml.XmlNodeType.None);
                success = type == System.Xml.XmlNodeType.Element;
            }

            return success;
        }

        /// <summary>
        /// Moves to first element after the current element with the specified name.
        /// </summary>
        void MoveBeyondThisElement() // string name, int depth)
        {
            if (!this.reader.IsEmptyElement && this.reader.NodeType != System.Xml.XmlNodeType.Comment)
            {
                if (this.reader.NodeType == System.Xml.XmlNodeType.XmlDeclaration)
                {
                    MoveToNextElement();
                    return;
                }
                else if (this.reader.NodeType == System.Xml.XmlNodeType.Attribute)
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
        } // End Sub MoveBeyondThisElement 


    }


}