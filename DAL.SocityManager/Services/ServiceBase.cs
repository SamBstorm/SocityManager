using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SocityManager.Services
{
    public abstract class ServiceBase
    {
        private readonly IConfiguration _config;

        public ServiceBase(IConfiguration config)
        {
           DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            //Si besoin d'un autre client (Oracle par exemple, il nous faut définir les liens entre les invariant names et les instances de factory
            //DbProviderFactories.RegisterFactory("System.Data.OracleClient", OracleClientFactory.Instance);
            _config = config;
        }

        protected string ConnectionString
        {
            get { return _config.GetConnectionString("localDb"); }
        }
        protected string InvariantName
        {
            get { return _config.GetSection("InvariantNames").GetSection("localDb").Value; }
        }
    }
}
