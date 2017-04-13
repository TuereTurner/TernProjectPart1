using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    [Serializable]
    public class FileInfo
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public float FileSize { get; set; }
        public string FileType { get; set; }
        public string UploadDate { get; set; }
        public string Username { get; set; }
    }
}
