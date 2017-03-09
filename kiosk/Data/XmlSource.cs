using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace kiosk.Data
{
    public static class XmlSource
    {
        public static object Load(Type t, string path)
        {
            object o = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(t);

                if (!System.IO.File.Exists(path))
                    throw new Exceptions.FileNotFoundException(string.Format("File \"{0}\" could not be found.  Are you sure it is in the same folder as the program and that you supplied the correct filename?", path));

                using (TextReader reader = new StreamReader(path))
                {
                    o = serializer.Deserialize(reader);
                }
            }
            catch(NullReferenceException nre)
            {
                if(t == null)
                    throw new NullReferenceException("Parameter \"Type\" to deserialize cannot be null.", nre);
            }
            catch(System.IO.FileNotFoundException fnfex)
            {
                throw; // see what this puts out, modify and rethrow with better message if necessary
            }
            catch(System.InvalidOperationException iopex)
            {
                throw new kiosk.Data.Exceptions.MalformedDataSourceFileException(string.Format("File \"{0}\" is corrupt and cannot be used.",path), iopex);
            }
            catch (System.Exception)
            {
                throw; // "re-throw" original unhandled exception witout modifying stack trace
            }
            finally
            {
            }

            return o;
        }

        public static void Save(object o, string path)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(o.GetType());

                using (TextWriter w = new StreamWriter(path))
                {
                    s.Serialize(w, o);
                }

            }
            catch (NullReferenceException nre)
            {
                if (o == null)
                    throw new NullReferenceException("Parameter \"object\" to serialize cannot be null.", nre);
            }
            catch (System.IO.FileNotFoundException fnfex)
            {
                throw; // see what this puts out, modify and rethrow with better message if necessary
            }
            catch (Exception ex)
            {
                throw; // "re-throw" original unhandled exception witout modifying stack trace
            }
            finally
            {
            }
        }
    }
}
