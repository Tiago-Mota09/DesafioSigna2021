using AutoMapper.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021.Data.Repositories
{
    public class RepositoryBase
    {
        protected IConfiguration configuration;

        internal IDbConnection Connection
        {
            get
            {
                var connect = new NpgsqlConnection(configuration["ConnectionString"]);

                connect.Open();

                return connect;
            }
        }
    }
}
