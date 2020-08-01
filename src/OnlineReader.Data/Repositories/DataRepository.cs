using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnlineReader.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineReader.Data.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;
        public DataRepository(IConfiguration configuration)
        {
            _connectionString =
            configuration["Data:OnlineReader:ConnectionString"];
        }

        public int PostFile(FileInfo file)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var questionId = connection.QueryFirst<int>(
                  @"EXEC dbo.Files_Post
                    @FileName = @FileName, @Created = @Created, 
                    @MimeType = @MimeType, @BlobId = @BlobId",
                  file
                );

                return questionId;
            }
        }
    }
}
