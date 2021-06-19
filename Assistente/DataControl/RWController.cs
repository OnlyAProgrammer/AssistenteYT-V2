using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistente.DataControl
{
    internal static class RWController
    {
        internal static void SaveLog()
        {
            var loglist = Log.LogPack.LogList;

            var content = new StringBuilder();

            foreach (var log in loglist)
                content.AppendLine(log.ToString());

            var filename = $"Log, {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}," +
                $" {DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}";
            Save(PRController.DataPath, filename, content.ToString());
        }

        private static void Save(string dir, string filename, string content)
        {
            var path = Path.Combine(dir, filename);

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (File.Exists(path)) File.Delete(path);

            var writer = File.CreateText(path);
            writer.Write(content);
            writer.Flush();
            writer.Close();
        }
    }
}
