using System.Collections.Generic;
using System.IO;

namespace SageCS.Core
{
    class FileSystem                                   
    {
        private static SortedDictionary<string, Stream> entries;

        public static void Init()
        {
            entries = new SortedDictionary<string, Stream>();
            string[] archives = Directory.GetFiles(Directory.GetCurrentDirectory(),"*.big",SearchOption.AllDirectories);
                               
            foreach (var archive in archives)
            {
                var content = Loaders.BigArchive.GetEntries(archive);
                foreach (var c in content)
                {
                    if (!entries.ContainsKey(c.Key))
                        entries.Add(c.Key, c.Value);
                }  
            }

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories);
            foreach (var f in files)
            {
                if (Path.GetExtension(f)!=".big")
                {
                    var relPath = f.Replace(Directory.GetCurrentDirectory(), "").TrimStart('\\');
                    if (!entries.ContainsKey(relPath))
                        entries.Add(relPath, null);
                }
            }     
        }

        public static Stream Open(string name)
        {
            return entries[name];
        }

        public static List<Stream> OpenAll(string extension)
        {
            List<Stream> streams = new List<Stream>();
            foreach (KeyValuePair<string, Stream> entry in entries)
            {
                if (entry.Key.EndsWith(extension))
                    streams.Add(entry.Value);
            }
            return streams;
        }
    }
}
