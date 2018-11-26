using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Permissions;
using System.Globalization;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.IO;

using SVGLib;

namespace Draw
{
	/// <summary>
	/// List of graphic objects
	/// </summary>
    [Serializable]
    public class GraphicsList// : ISerializable
    {
        private ArrayList graphicsList;

        private const string entryCount = "Count";
        private const string entryType = "Type";

        public GraphicsList()
        {
            graphicsList = new ArrayList();
        }

        public GraphicsList(XmlTextReader reader)
        {
            graphicsList = new ArrayList();
/*
            int n = info.GetInt32(entryCount);
            string typeName;
            object drawObject;

            for ( int i = 0; i < n; i++ )
            {
                typeName = info.GetString(
                    String.Format(CultureInfo.InvariantCulture,
                        "{0}{1}",
                    entryType, i));

                drawObject = Assembly.GetExecutingAssembly().CreateInstance(
                    typeName);

                ((DrawObject)drawObject).LoadFromStream(info, i);
        
                graphicsList.Add(drawObject);
            }
*/
        }

        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        //[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
		public string GetXmlString(SizeF scale)
		{
			string sXML = "";
			/*foreach ( DrawObject o in graphicsList )
			{
				sXML += o.GetXmlStr(scale);
			}*/
			int n = graphicsList.Count;
			for (int i = n - 1; i >= 0; i-- )
			{
				DrawObject o = (DrawObject)graphicsList[i];
				sXML += o.GetXmlStr(scale);
			}
			return sXML;
		}

        public void Draw(Graphics g)
        {
            int n = graphicsList.Count;
            DrawObject o;

            // Enumerate list in reverse order
            // to get first object on the top
            for (int i = n - 1; i >= 0; i-- )
			//for (int i = 0; i < graphicsList.Count; i++ )
			{
				o = (DrawObject)graphicsList[i];

				o.Draw(g);

				if ( o.Selected == true )
				{
					o.DrawTracker(g);
				}
			}
        }

        /// <summary>
        /// Clear all objects in the list
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool Clear()
        {
            bool result = (graphicsList.Count > 0);
            graphicsList.Clear();
            return result;
        }

        /// <summary>
        /// Count and this [nIndex] allow to read all graphics objects
        /// from GraphicsList in the loop.
        /// </summary>
        public int Count
        {
            get
            {
                return graphicsList.Count;
            }
        }

        public DrawObject this [int index]
        {
            get
            {
                if ( index < 0  ||  index >= graphicsList.Count )
                    return null;

                return ((DrawObject)graphicsList[index]);
            }
        }

        /// <summary>
        /// SelectedCount and GetSelectedObject allow to read
        /// selected objects in the loop
        /// </summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;
                foreach (DrawObject o in graphicsList)
                {
                    if ( o.Selected )
                        n++;
                }
                return n;
            }
        }
        public DrawObject GetSelectedObject(int index)
        {
            int n = -1;
            foreach (DrawObject o in graphicsList)
            {
                if ( o.Selected )
                {
                    n++;

                    if ( n == index )
                        return o;
                }
            }
            return null;
        }

        public void Add(DrawObject obj)
        {
            // insert to the top of z-order
            graphicsList.Insert(0, obj);
        }

        public void SelectInRectangle(RectangleF rectangle)
        {
            UnselectAll();

            foreach (DrawObject o in graphicsList)
            {
                if ( o.IntersectsWith(rectangle) )
                    o.Selected = true;
            }

        }

        public void UnselectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = false;
            }
        }

        public void SelectAll()
        {
            foreach (DrawObject o in graphicsList)
            {
                o.Selected = true;
            }
        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool DeleteSelection()
        {
            bool result = false;

            int n = graphicsList.Count;

            for ( int i = n-1; i >= 0; i-- )
            {
                if ( ((DrawObject)graphicsList[i]).Selected )
                {
                    graphicsList.RemoveAt(i);
                    result = true;
                }
            }

            return result;
        }


        /// <summary>
        /// Move selected items to front (beginning of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        public bool MoveSelectionToFront()
        {
            int n;
            int i;
            ArrayList tempList;

            tempList = new ArrayList();
            n = graphicsList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for ( i = n - 1; i >= 0; i-- )
            {
                if ( ((DrawObject)graphicsList[i]).Selected )
                {
                    tempList.Add(graphicsList[i]);
                    graphicsList.RemoveAt(i);
                }
            }

            // Read temporary list in direct order and insert every item
            // to the beginning of the source list
            n = tempList.Count;

            for ( i = 0; i < n; i++ )
            {
                graphicsList.Insert(0, tempList[i]);
            }

            return ( n > 0 );
        }

        /// <summary>
        /// Move selected items to back (end of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        public bool MoveSelectionToBack()
        {
            int n;
            int i;
            ArrayList tempList;

            tempList = new ArrayList();
            n = graphicsList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for ( i = n - 1; i >= 0; i-- )
            {
                if ( ((DrawObject)graphicsList[i]).Selected )
                {
                    tempList.Add(graphicsList[i]);
                    graphicsList.RemoveAt(i);
                }
            }

            // Read temporary list in reverse order and add every item
            // to the end of the source list
            n = tempList.Count;

            for ( i = n - 1; i >= 0; i-- )
            {
                graphicsList.Add(tempList[i]);
            }

            return ( n > 0 );
        }

        /// <summary>
        /// Get properties from selected objects and fill GraphicsProperties instance
        /// </summary>
        /// <returns></returns>
        private GraphicsProperties GetProperties()
        {
            GraphicsProperties properties = new GraphicsProperties();

            int n = SelectionCount;

            if ( n < 1 )
                return properties;

            DrawObject o = GetSelectedObject(0);

            int firstColor = o.stroke.ToArgb();
            float firstPenWidth = o.stroke_width;

            bool allColorsAreEqual = true;
            bool allWidthAreEqual = true;

            for ( int i = 1; i < n; i++ )
            {
                if ( GetSelectedObject(i).stroke.ToArgb() != firstColor )
                    allColorsAreEqual = false;

                if ( GetSelectedObject(i).stroke_width != firstPenWidth )
                    allWidthAreEqual = false;
            }

            if ( allColorsAreEqual )
            {
                properties.ColorDefined = true;
                properties.Color = Color.FromArgb(firstColor);
            }

            if ( allWidthAreEqual )
            {
                properties.PenWidthDefined = true;
                properties.PenWidth = firstPenWidth;
            }

            return properties;
        }
		public DrawObject GetFirstSelected()
		{
			foreach ( DrawObject o in graphicsList )
			{
				if ( o.Selected )
					return o;
			}
			return null;
		}
        /// <summary>
        /// Apply properties for all selected objects
        /// </summary>
        private void ApplyProperties(GraphicsProperties properties)
        {
            foreach ( DrawObject o in graphicsList )
            {
                if ( o.Selected )
                {
                    if ( properties.ColorDefined )
                    {
                        o.stroke = properties.Color;
                        DrawObject.LastUsedColor = properties.Color;
                    }

                    if ( properties.PenWidthDefined )
                    {
                        o.stroke_width = properties.PenWidth;
                        DrawObject.LastUsedPenWidth = properties.PenWidth;
                    }
                }
            }
        }

        /// <summary>
        /// Show Properties dialog. Return true if list is changed
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public virtual bool ShowPropertiesDialog(IWin32Window parent)
        {
            if ( SelectionCount < 1 )
                return false;
			DrawObject o = GetFirstSelected();
			if (o == null)
				return false;
			return o.ShowPropertiesDialog(parent);
        }
		public void Resize(SizeF newscale,SizeF oldscale)
		{
			foreach (DrawObject o in graphicsList)
				o.Resize(newscale,oldscale);
		}
		// **************   Read from SVG
		public void AddFromSvg(SvgElement ele)
		{
			while (ele != null)
			{
				DrawObject o = this.CreateDrawObject(ele);
				if (o != null)
					Add(o);
				SvgElement child = ele.getChild();
				while (child != null)
				{
					AddFromSvg(child);
					child = child.getNext();
				}
				ele = ele.getNext();
			}
		}
		DrawObject CreateDrawObject(SvgElement svge)
		{
			DrawObject o = null;
			switch (svge.getElementType())
			{
				case SvgElement._SvgElementType.typeLine:
					o = DrawLine.Create((SvgLine )svge);
					break;
				case SvgElement._SvgElementType.typeRect:
					o = DrawRectangle.Create((SvgRect )svge);
					break;
				case SvgElement._SvgElementType.typeEllipse:
					o = DrawEllipse.Create((SvgEllipse )svge);
					break;
				case SvgElement._SvgElementType.typePolyline:
					o = DrawPolygon.Create((SvgPolyline )svge);
					break;
				case SvgElement._SvgElementType.typeImage:
					o = DrawImage.Create((SvgImage )svge);
					break;
				case SvgElement._SvgElementType.typeText:
					o = DrawText.Create((SvgText )svge);
					break;
				case SvgElement._SvgElementType.typeGroup:
					o = CreateGroup((SvgGroup )svge);
					break;
				default:
					break;
			}
			return o;
		}
		DrawObject CreateGroup(SvgGroup svg)
		{
			DrawObject o = null;
				SvgElement child = svg.getChild();
				if (child != null)
					AddFromSvg(child);
			return o;
		}
		// *************************************************
	}
}
