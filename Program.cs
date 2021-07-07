using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MigracaoSVN
{
    class Program
    {
        static List<FileInfo> _files;
        static List<FileInfo> _filesIsReadOnly;
        private static Dictionary<string, string> _replaceList;
        
        [STAThreadAttribute()]
        static void Main()
        {

            _filesIsReadOnly = new List<FileInfo>();
            _files = new List<FileInfo>();
            _replaceList = new Dictionary<string, string>();
            Console.WriteLine("Informe o diretorio de leitura");            
            frmConfigSln formConfiguraSolution = new frmConfigSln();
            formConfiguraSolution.ShowDialog();

            string caminhoPadrao = Path.Combine(formConfiguraSolution.txtPath.Text);

            Console.WriteLine("Leitura do diretorio " + caminhoPadrao + " iniciada");
            SearchFilesInDirectories(new DirectoryInfo(caminhoPadrao));
            _filesIsReadOnly = SearchFilesInDirectoriesNew(caminhoPadrao,  ".sln", ".vbproj", ".csproj");
            string[] arrayReplaceArquivo = new string[] { ".sln", ".vbproj", ".csproj"};
            string[] arrayDeletarArquivo = new string[] { ".vspscc", ".vssscc"};
            
            Console.WriteLine("{0} arquivo encontrado", _files.Count.ToString(CultureInfo.InvariantCulture));

            Console.Write("Processo inicado ...."); 
            CreateReplaceList();
            Console.WriteLine("{0} item added", _replaceList.Count.ToString(CultureInfo.InvariantCulture));
            

            for (int i = 0; i < _files.Count; i++)
            {
                var fileInfo = _files[i];
                fileInfo.IsReadOnly = false;

                if (arrayReplaceArquivo.Contains(fileInfo.Extension))
                {
                    Console.CursorLeft = 0;
                    Console.Write("{0} of {1}", i.ToString(CultureInfo.InvariantCulture), _files.Count.ToString(CultureInfo.InvariantCulture));

                    ReplaceInFile(fileInfo.FullName);
                }

                if (arrayDeletarArquivo.Contains(fileInfo.Extension))
                {
                    
                    Console.WriteLine("Buscando arquivos com a extensão .vspscc e . vssscc ");

                    fileInfo.Attributes = FileAttributes.Normal;
                    File.Delete(fileInfo.FullName);

                    Console.WriteLine("Arquivos deletados " + fileInfo.FullName);
                }
            }

            Console.CursorLeft = 0;
            Console.WriteLine("Processo finalizado");
            Console.ReadKey();
        }

        public static List<FileInfo> GetFiles(string path, params string[] extensions)
        {
            List<FileInfo> list = new List<FileInfo>();
            
            foreach (string ext in extensions)
                list.AddRange(new DirectoryInfo(path).GetFiles("*" + ext, SearchOption.AllDirectories).Where(p =>
                      p.Extension.Equals(ext, StringComparison.CurrentCultureIgnoreCase))
                      .ToArray());
            return list;
        }

        public static List<FileInfo> SearchFilesInDirectoriesNew(string path, params string[] extensions)
        {
            List<FileInfo> list = new List<FileInfo>();

            foreach (string ext in extensions)
                list.AddRange(new DirectoryInfo(path).GetFiles("*" + ext, SearchOption.AllDirectories).Where(p =>
                      p.Extension.Equals(ext, StringComparison.CurrentCultureIgnoreCase))
                      .ToArray());
            return list;
        }

        private static void SearchFilesInDirectories(DirectoryInfo dir)
        {
            if (!dir.Exists) return;

            foreach (DirectoryInfo subDirInfo in dir.GetDirectories())
                SearchFilesInDirectories(subDirInfo);

            foreach (var fileInfo in dir.GetFiles())
                _files.Add(fileInfo);
        }

        private static void CreateReplaceList()
        {
            _replaceList.Add("<SccProjectName>SAK</SccProjectName>", "<SccProjectName>Svn</SccProjectName>");
            _replaceList.Add("<SccLocalPath>SAK</SccLocalPath>", "<SccLocalPath>Svn</SccLocalPath>");
            _replaceList.Add("<SccAuxPath>SAK</SccAuxPath>", "<SccAuxPath>Svn</SccAuxPath>");
            _replaceList.Add("<SccProvider>SAK</SccProvider>", "<SccProvider>SubversionScc</SccProvider>");
            
            
        }

        public static void ReplaceInFile(string filePath)
        {
            string content;
            using (var reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
                reader.Close();
            }

            content = _replaceList.Aggregate(content, (current, item) => current.Replace(item.Key, item.Value));

            if (filePath.IndexOf(".sln") > 0)
            {
                content = BuscaChaveTfs(content);
            }

            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(content);
                writer.Close();
            }
        }

        public static string BuscaChaveTfs(string content)
        {
            string input = Regex.Replace(content, @"(?i:\s*?GlobalSection\(TeamFoundationVersionControl\)(?:.|\n)*?EndGlobalSection\s*?)", "\n	GlobalSection(TeamFoundationVersionControl) = preSolution \n\n	EndGlobalSection", RegexOptions.IgnoreCase);
            return input;
        }
    }
}
