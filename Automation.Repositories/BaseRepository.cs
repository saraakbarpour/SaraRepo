using System.Collections.Generic;
using System.Linq;
using Dapper;
using Devart.Data.PostgreSql;

namespace Automation.Repositories
{
	public abstract class BaseRepository
	{
		private readonly string _connectionString;

		protected BaseRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public IEnumerable<T> Query<T>(string sql, object param = null)
		{
			using (var connection = new PgSqlConnection(_connectionString))
			{
				connection.Open();
				var records = connection.Query<T>(sql, param);
				return records;
			}
		}

		public int Execute(string sql, object param = null)
		{
			using (var connection = new PgSqlConnection(_connectionString))
			{
				connection.Open();
				var recordsAffected = connection.Execute(sql, param);
				return recordsAffected;
			}
		}

		public IEnumerable<int> Execute(params SqlCommand[] sqlCommands)
		{
			using (var connection = new PgSqlConnection(_connectionString))
			{
				var allRecordsAffected = new List<int>();
				connection.Open();
				connection.BeginTransaction();
				try
				{
					sqlCommands.ToList().ForEach(sqlCommand =>
					{
						var recordsAffected = connection.Execute(sqlCommand.Sql, sqlCommand.Param);
						allRecordsAffected.Add(recordsAffected);
					});

					connection.Commit();
				}
				catch
				{
					connection.Rollback();
					throw;
				}
				finally
				{
					connection.Close();
				}

				return allRecordsAffected;
			}
		}
	}
}