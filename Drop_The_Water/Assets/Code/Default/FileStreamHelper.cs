using System;
using UnityEngine;
using System.IO;

namespace FileHelper
{
	public class FileStreamHelper
	{
		private static string _tmp = "";

		public FileStreamHelper ()
		{

		}

		public static void writeStringToFile( string str, string filename )
		{
			#if !WEB_BUILD
			string path = pathForDocumentsFile( filename );
			FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);

			StreamWriter sw = new StreamWriter(file);
			sw.WriteLine( str );

			sw.Close();
			file.Close();
			#endif
		}

		public static void writeStringToFileAppend( string str, string filename )
		{
			#if !WEB_BUILD
			string path = pathForDocumentsFile( filename );
			FileStream file = new FileStream (path, FileMode.Append, FileAccess.Write);

			StreamWriter sw = new StreamWriter( file );
			sw.WriteLine( str );

			sw.Close();
			file.Close();
			#endif 
		}

		public static string readStringFromFile( string filename)
		{
			#if !WEB_BUILD
			string path = pathForDocumentsFile(filename );

			if (File.Exists(path))
			{
				FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader( file );

				string str = null;
				string total = "";
				while((str = sr.ReadLine()) != null)
					total += str + "\n";

				sr.Close();
				file.Close();

				return total;
			}
			else
			{
				return null;
			}
			#else
			return null;
			#endif 
		}

		public static string pathForDocumentsFile(string filename)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				string path = Application.persistentDataPath;
				path = path.Substring(0, path.LastIndexOf('/'));
				path = path + "/files";
				return Path.Combine(path, filename);
			}

			else
			{
				string path = Application.dataPath;
				//string path = "";
				path = path.Substring(0, path.LastIndexOf('/'));
				path = path + "/files";
				return Path.Combine(path, filename);
			}
		}

		public static void log(string log)
		{
			if (log.Equals (_tmp))
				return;
			else
				_tmp = log;

			log = System.DateTime.Now.ToString ("yyyy:MM:dd:hh:mm:ss :: ") + log;

			Debug.Log (log);

			//log = readStringFromFile ("log") + "\n" + log;

			writeStringToFileAppend (log, "log");
		}

		public static void log(int obj)
		{
			log (obj.ToString ());
		}
	}
}