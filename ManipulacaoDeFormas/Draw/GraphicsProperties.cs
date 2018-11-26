using System;
using System.Windows.Forms;
using System.Drawing;


namespace Draw
{
	/// <summary>
	/// Helper class used to show properties
	/// for one or more graphic objects
	/// </summary>
	public class GraphicsProperties
	{
        private Color color;
        private float penWidth;
        private bool colorDefined;
        private bool penWidthDefined;
		private bool fillDefined;
		private Color fillColor;
		private bool isFill=false;

        public GraphicsProperties()
        {
            color = Color.Black;
            penWidth = 1;
            colorDefined = false;
            penWidthDefined = false;
			fillDefined = false;
			FillColor = Color.White;
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
		public bool IsFill
		{
			get
			{
				return isFill;
			}
			set
			{
				isFill = value;
			}
		}
		public Color FillColor
		{
			get
			{
				return fillColor;
			}
			set
			{
				fillColor = value;
			}
		}

        public float PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                penWidth = value;
            }
        }

        public bool ColorDefined
        {
            get
            {
                return colorDefined;
            }
            set
            {
                colorDefined = value;
            }
        }

        public bool PenWidthDefined
        {
            get
            {
                return penWidthDefined;
            }
            set
            {
                penWidthDefined = value;
            }
        }
		public bool FillDefined
		{
			get
			{
				return fillDefined;
			}
			set
			{
				fillDefined = value;
			}
		}
	}
}
