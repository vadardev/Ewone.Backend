using System.Data;
using Npgsql;
using Vesta.DbMapper;

namespace Ewone.Domain.DataLayer.DbMapper
{
    public class NpgsqlDapperDbMapper : DapperDbMapper
    {
        public NpgsqlDapperDbMapper(Func<string> connectionStringGetter) : base(connectionStringGetter)
        {
        }

        protected override IDbConnection GetConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}