using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelativityDBHelper;
using System.Xml;
using System.IO;

namespace RelativityScriptViewer
{
    class Relativity
    {
        private Database RelativityDatabase;
        private Helpers Helpers;

        public Relativity(string server, string userid, string password, string timeout="120")
        {
            if (String.IsNullOrWhiteSpace(userid) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException();
            }
            RelativityDatabase = new Database(server, userid, password, timeout);
            Helpers = new Helpers(RelativityDatabase);
        }

        /// <summary>
        /// This eventhandler sets the proper version of Relativity assemblies to load
        /// 
        /// Use the following code to set the eventhandler. 
        /// 
        ///  AppDomain relativityDomain = AppDomain.CurrentDomain;
        ///  relativityDomain.AssemblyResolve += new ResolveEventHandler(RelativityDomain_AssemblyResolve);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private System.Reflection.Assembly RelativityDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string version = Helpers.getRelativityProductVersion();
            //Logging.writeMessage("Determined Relativity version is " + version);

            System.Reflection.Assembly loadfrom = null;
            switch (version)
            {
                case "9.7" :
                    loadfrom = System.Reflection.Assembly.LoadFrom("9.7\\RelativityHelper9.7.dll");
                    //Logg("Loading from 9.7\\RelativityHelper9.7.dll");
                    break;
                case "9.6" :
                    loadfrom = System.Reflection.Assembly.LoadFrom("9.6\\RelativityHelper9.6.dll");
                    //Logging.writeMessage("Loading from 9.6\\RelativityHelper9.6.dll");
                    break;
                default:
                    //Logging.writeMessage("Unable to determine Relativity server version.");
                    throw new Exception("Unable to determine Relativity server version.");
            }

            return loadfrom;
        }
        /// <summary>
        /// Get a list of scripts
        /// </summary>
        public List<string> GetScriptList()
        {
            return Helpers.getScriptList();
        }
        /// <summary>
        /// Reads the given script content from the Relativity database
        /// </summary>
        /// <param name="name">Script name</param>
        /// <returns>Script body text formatted in XML</returns>
        public string GetScript(string name)
        {
            // Read the script content from the Relativity database
            string script = Helpers.getScript(name); 

            // Load script content into an XML document
            XmlDocument xml_document = new XmlDocument();
            xml_document.PreserveWhitespace = true;
            xml_document.LoadXml(script);
            
            // Format the XML text.
            StringWriter string_writer = new StringWriter();
            XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
            xml_text_writer.Formatting = Formatting.Indented;
            xml_document.WriteTo(xml_text_writer);

            return string_writer.ToString();
            
        }
    }
}
