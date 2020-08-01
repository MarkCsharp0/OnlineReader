using OnlineReader.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineReader.Data.Repositories
{
    public interface IDataRepository
    {
         public int PostFile(FileInfo file);
    }
}
