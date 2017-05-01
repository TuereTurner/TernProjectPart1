using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
namespace File
{
    [Serializable]
    public class FileInfoWS
    {
        public byte[] File { get; set; }
        public DataSet FileSet { get; set; }
        public string FileName { get; set; }
        public float FileSize { get; set; }
        public string FileType { get; set; }
        public string UploadDate { get; set; }
        public string Username { get; set; }
        public string CurrentFolder { get; set; }
        public string Path { get; set; }
    }
}
