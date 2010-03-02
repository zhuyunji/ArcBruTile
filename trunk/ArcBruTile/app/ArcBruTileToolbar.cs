﻿using System;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.esriSystem;
using System.Configuration;
using log4net.Config;
using System.IO;
using System.Reflection;
using log4net;

namespace BruTileArcGIS
{
    /// <summary>
    /// Summary description for MplToolbar.
    /// </summary>
    [Guid("059B9A69-335D-41EA-B511-4D3F985D27CC")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcBruTileToolbar")]
    public sealed class ArcBruTileToolbar : BaseToolbar
    {
        private static readonly log4net.ILog logger = LogManager.GetLogger("ArcBruTileSystemLogger");

        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Unregister(regKey);
        }

        #endregion
        #endregion

        /// <summary>
        /// Initialiseert een nieuwe instantie van de toolbar.
        /// </summary>
        public ArcBruTileToolbar()
        {
            //init log4net
            // Configure logfiles
            XmlConfigurator.Configure(new FileInfo(Assembly.GetExecutingAssembly().Location + ".config"));
            logger.Info("Startup ArcBruTile");
            //Menu sectie
            AddItem("BruTileArcGIS.BruTileMenuDef");

            //Status sectie
            BeginGroup();
            AddItem("AddOsmLayerCommand");
            AddItem("AddBingLayerCommand");
            AddItem("BrutileArcGIS.commands.AddGeoserverLayerCommand");
        }

        /// <summary>
        /// Caption of the MPL toolbar
        /// </summary>
        public override string Caption
        {
            get
            {
                return "BruTile";
            }
        }

        /// <summary>
        /// Name of the MPL toolbar
        /// </summary>
        public override string Name
        {
            get
            {
                return "BruTile toolbar";
            }
        }
    }
}
