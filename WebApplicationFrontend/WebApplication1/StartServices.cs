using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System.IO;

namespace WebApplication1
{
    public class StartServices
    {
        public static void Start()
        {
            string path = System.Environment.CurrentDirectory;
            Console.WriteLine("Starting Elasticsearch and Kibana services...");
            //string testPath = @"D:\Downloads\";
            //StartElastic(Path.Combine(path, "elasticsearch", "bin"), "elasticsearch.bat");
            //StartKibana(Path.Combine(path, "kibana", "bin"), "kibana.bat");
            //StartElastic(Path.Combine(testPath, "elasticsearch-7.9.3", "bin"), "elasticsearch.bat");
            //StartKibana(Path.Combine(testPath, "kibana-7.9.3", "bin"), "kibana.bat");
            Console.WriteLine("Elasticsearch and Kibana services are running now.");
        }

        public static void StartDBUpdate()
        {
            string path = System.Environment.CurrentDirectory;

            StartService(Path.Combine(path, "services") ,"run_db_service.cmd");
            // listen then start python
            StartPython(Path.Combine(path, "services"), "run_loader.cmd");
            
        }

        private static void StartService(string path, string fileName)
        {
            var url = "http://localhost:8080";
            if (CheckConnection(url))
                return;
           
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                WorkingDirectory = path,
                //Arguments = strCmdText,
                UseShellExecute = true,
            };
            Process.Start(psi);
            for (var i = 0; i < 30; i++)
            {
                if (CheckConnection(url))
                    break;
                Thread.Sleep(3000);
            }
        }

        private static void StartPython(string path, string fileName)
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                WorkingDirectory = path,
                //Arguments = strCmdText,
                UseShellExecute = true,
            };
            Process.Start(psi);
        }

        private static bool CheckConnection(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // move path params to configuration file and add README
        private static void StartKibana(string path, string fileName)
        {
            var url = "http://localhost:5601";
            if (CheckConnection(url))
                return;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = fileName;
            psi.WorkingDirectory = path;
            psi.UseShellExecute = true;
            psi.CreateNoWindow = false;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            Process p = Process.Start(psi);

            for (var i = 0; i < 30; i++)
            {
                if (CheckConnection(url))
                    break;
                Thread.Sleep(3000);

            }
        }

        private static void StartElastic(string path, string fileName)
        {
            var url = "http://localhost:9200";
            if (CheckConnection(url))
                return;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.WorkingDirectory = path;
            psi.FileName = fileName;
            psi.UseShellExecute = true;
            psi.CreateNoWindow = false;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            Process p = Process.Start(psi);

            for (var i = 0; i < 30; i++)
            {
                if (CheckConnection(url))
                    break;
                Thread.Sleep(3000);
            }
        }


    }
}
