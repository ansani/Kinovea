﻿#region License
/*
Copyright © Joan Charmant 2012.
joan.charmant@gmail.com 
 
This file is part of Kinovea.

Kinovea is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License version 2 
as published by the Free Software Foundation.

Kinovea is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Kinovea. If not, see http://www.gnu.org/licenses/.
*/
#endregion
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Kinovea.ScreenManager
{
    public class ExporterTrajectoryText
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public void Export(string path, Metadata metadata)
        {
            string kvaString = metadata.ToXmlString(1);
            XmlDocument kvaDoc = new XmlDocument();
			kvaDoc.LoadXml(kvaString);
			
			string stylesheet = Application.StartupPath + "\\xslt\\kva2txt-en.xsl";
			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(stylesheet);
			
			try
			{
			    using(StreamWriter sw = new StreamWriter(path))
        		{
		           	xslt.Transform(kvaDoc, null, sw);
				}
			}
			catch(Exception ex)
			{
				log.Error("Exception thrown during export to MSXML.");
                log.Error(ex.Message);
                log.Error(ex.Source);
                log.Error(ex.StackTrace);
			}
			
        }
    }
}