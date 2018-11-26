using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using System.Xml;
using System.Globalization;


namespace DocToolkit
{
    /// <summary>
    /// Class allows to keep last window state in Config
    /// and restore it when form is loaded.
    /// 
    /// Source: Saving and Restoring the Location, Size and 
    ///         Windows State of a .NET Form
    ///         By Joel Matthias 
    ///         
    ///  Downloaded from http://www.codeproject.com
    ///  
    ///  Using:
    ///  1. Add class member to the owner form:
    ///  
    ///  private PersistWindowState persistState;
    ///  
    ///  2. Create it in the form constructor:
    ///  
    ///  persistState = new PersistWindowState("Software\\MyCompany\\MyProgram", this);
    ///  
    /// </summary>
    public class Config
    {
        #region Members

        private Form ownerForm;          // reference to owner form

        // Form state parameters:
        private int normalLeft;
        private int normalTop;
        private int normalWidth;
        private int normalHeight;
        // FormWindowState is enumeration from System.Windows.Forms Namespace
        // Contains 3 members: Maximized, Minimized and Normal.
        private FormWindowState windowState = FormWindowState.Normal;
        // if allowSaveMinimized is true, form closed in minimal state
        // is loaded next time in minimal state.
        private bool allowSaveMinimized = false;


		XmlDocument xmlDocument = new XmlDocument();
		private string root = "config";
		private string documentPath = Application.StartupPath + "\\SvgPaintCfg.xml";
		// Singleton
		private static Config _instance = null;
		public static Config Instance(Form ownerForm)
		{
			if (_instance == null)
				_instance = new Config(ownerForm);
			return _instance;
		}
		public static Config Instance()
		{
			return _instance;
		}

        #endregion

        #region Constructor

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="sRegPath"></param>
        /// <param name="owner"></param>
		protected Config(/*string path,*/ Form owner)
		{
			ownerForm = owner;

			// subscribe to parent form's events

			ownerForm.Closing += new System.ComponentModel.CancelEventHandler(OnClosing);
			ownerForm.Resize += new System.EventHandler(OnResize);
			ownerForm.Move += new System.EventHandler(OnMove);
			ownerForm.Load += new System.EventHandler(OnLoad);
			// ********************************************
			try 
			{
				xmlDocument.Load(documentPath);
			}
			catch 
			{
				xmlDocument.LoadXml("<"+root+"></"+root+">");
			}
			//  *******************************************
			// get initial width and height in case form is never resized
			normalWidth = ownerForm.Width;
			normalHeight = ownerForm.Height;
		}

        #endregion

        #region Properties

        /// <summary>
        /// AllowSaveMinimized property (default value false) 
        /// </summary>
        public bool AllowSaveMinimized
        {
            get
            {
                return allowSaveMinimized;
            }
            set
            {
                allowSaveMinimized = value;
            }
        }

        #endregion

        #region Event Handlers


        /// <summary>
        /// Parent form is resized.
        /// Keep current size.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResize(object sender, System.EventArgs e)
        {
            // save width and height
            if(ownerForm.WindowState == FormWindowState.Normal)
            {
                normalWidth = ownerForm.Width;
                normalHeight = ownerForm.Height;
            }
        }

        /// <summary>
        /// Parent form is moved.
        /// Keep current window position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMove(object sender, System.EventArgs e)
        {
            // save position
            if(ownerForm.WindowState == FormWindowState.Normal)
            {
                normalLeft = ownerForm.Left;
                normalTop = ownerForm.Top;
            }

            // save state
            windowState = ownerForm.WindowState;
        }

        /// <summary>
        /// Parent form is closing.
        /// Keep last state in Config.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // save position, size and state

			PutSetting("MainForm/Left", normalLeft);
			PutSetting("MainForm/Top", normalTop);
			PutSetting("MainForm/Width", normalWidth);
			PutSetting("MainForm/Height", normalHeight);

													 // check if we are allowed to save the state as minimized (not normally)
            if(!allowSaveMinimized)
            {
                if(windowState == FormWindowState.Minimized)
                    windowState = FormWindowState.Normal;
            }
            PutSetting("MainForm/WindowState", (int)windowState);
			//Save();
        }

        /// <summary>
        /// Parent form is loaded.
        /// Read last state from Config and set it to form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OnLoad(object sender, System.EventArgs e)
		{
			int left = GetSetting("MainForm/Left", ownerForm.Left);
			int top = GetSetting("MainForm/Right", ownerForm.Top);
			int width = GetSetting("MainForm/Width", ownerForm.Width);
			int height = GetSetting("MainForm/Height", ownerForm.Height);
			FormWindowState windowState = (FormWindowState)GetSetting("MainForm/WindowState", (int)ownerForm.WindowState);

			ownerForm.Location = new Point(left, top);
			ownerForm.Size = new Size(width, height);
			ownerForm.WindowState = windowState;
		}

        #endregion

		#region get/set data from/to config file

		public int GetSetting(string xPath, int defaultValue)
		{
			try
			{
				return Convert.ToInt32(GetSetting(xPath, 
					Convert.ToString(defaultValue,CultureInfo.InvariantCulture)),
					CultureInfo.InvariantCulture); 
			} 
			catch
			{
				return defaultValue;
			}
		}

		public void PutSetting(string xPath, int value)
		{ 
			try
			{
				PutSetting(xPath, Convert.ToString(value,CultureInfo.InvariantCulture)); 
			}
			catch
			{
			}
		}

		public float GetSetting(string xPath, float defaultValue)
		{
			try
			{
				return Convert.ToSingle(GetSetting(xPath, 
					Convert.ToString(defaultValue,CultureInfo.InvariantCulture)),
					CultureInfo.InvariantCulture); 
			} 
			catch
			{
				return defaultValue;
			}
		}

		public void PutSetting(string xPath, float value)
		{ 
			try
			{
				PutSetting(xPath, Convert.ToString(value,CultureInfo.InvariantCulture)); 
			}
			catch
			{
			}
		}

		public string GetSetting(string xPath,  string defaultValue)
		{
			XmlNode xmlNode = xmlDocument.SelectSingleNode(root + "/" + xPath );
			if (xmlNode != null) 
				return xmlNode.InnerText;
			else 
				return defaultValue;
		}

		public void PutSetting(string xPath,  string value)
		{
			XmlNode xmlNode = xmlDocument.SelectSingleNode(root+"/" + xPath);
			if (xmlNode == null) 
				xmlNode = createMissingNode(root+"/" + xPath);
			xmlNode.InnerText = value;
		}

		public XmlNode SelectSingleNode(string xPath)
		{
			return xmlDocument.SelectSingleNode(root+"/" + xPath);
		}

		private XmlNode createMissingNode(string xPath)
		{
			string[] xPathSections = xPath.Split('/');
			string currentXPath = "";
			XmlNode testNode = null;
			XmlNode currentNode = xmlDocument.SelectSingleNode(root);
			foreach (string xPathSection in xPathSections)
			{
				currentXPath += xPathSection;
				testNode = xmlDocument.SelectSingleNode(currentXPath);
				if (testNode == null)
				{
					currentNode.InnerXml += "<" + 
						xPathSection + "></" + 
						xPathSection + ">";
				}
				currentNode = xmlDocument.SelectSingleNode(currentXPath);
				currentXPath += "/";
			}
			return currentNode;
		}

		public bool Save()
		{
			try
			{
				xmlDocument.Save(documentPath);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка записи файла конфигурации: "+ex.ToString(), "Error");
				return false;
			}
		}

		#endregion

    }
}
