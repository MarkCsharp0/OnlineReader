using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineReader.Data.Entities
{
    public class FileInfo
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string MimeType { get; set; }

        public DateTime Created { get; set; }

        public string BlobId { get; set; }
    }
}
