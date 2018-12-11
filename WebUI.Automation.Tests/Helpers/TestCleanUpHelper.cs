using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Dapper;

namespace WebUI.Automation.Tests.Helpers
{
	public class TestCleanUpHelper : IDisposable
	{
		private readonly IDbConnection _dbConnection;

		public TestCleanUpHelper(string connectionString)
		{
			_dbConnection = new SqlConnection(connectionString);
		}

		public void CleanupConsumerDataByEmail(string userEmail)
		{
			using (var transaction = new TransactionScope())
			{
				var consumerId = GetConsumerIdByEmail(userEmail);
				CleanupConsumerDataByConsumerId(consumerId, userEmail);
				transaction.Complete();
			}
		}

		private Guid GetConsumerIdByEmail(string userEmail)
		{
			var userId = GetUserIdByEmail(userEmail);

			var consumerId = _dbConnection.Query<Guid>("SELECT con.ConsumerId " +
				"FROM " +
				"(SELECT AccountHolderId AS UserId, Id AS ConsumerId " +
				"FROM Consumers " +
				"UNION ALL " +
				"SELECT UserId, ConsumerId " +
				"FROM ConsumerUsers " +
				") con " +
				"WHERE con.UserId = @userId",
				new { userId }).FirstOrDefault();

			return consumerId;
		}

		private void CleanupConsumerDataByConsumerId(Guid consumerId, string userEmail = null)
		{
			using (var transaction = new TransactionScope())
			{
				userEmail = userEmail ?? GetEmailByConsumerId(consumerId);

				DeleteConsumerByConsumerId(consumerId);

				DeleteUserByEmail(userEmail);

				transaction.Complete();
			}
		}

		private string GetEmailByConsumerId(Guid consumerId)
		{
			var email = _dbConnection.Query<string>("SELECT u.Email FROM AspNetUsers u " +
				"JOIN Consumers c ON u.Id = c.AccountHolderId " +
				"WHERE c.Id = @consumerId", new { consumerId }).FirstOrDefault();

			return email;
		}


		private void DeleteConsumerByConsumerId(Guid consumerId)
		{
			DeleteConsumerUserByConsumerId(consumerId);
			_dbConnection.Query("DELETE FROM AlexaInformations WHERE Id = @consumerId", new { consumerId });
			_dbConnection.Query("DELETE FROM Consumers WHERE Id = @consumerId", new { consumerId });
		}

		private void DeleteUserByEmail(string userEmail)
		{
			var userId = GetUserIdByEmail(userEmail);
			DeleteUserRolesByUserId(userId);

			_dbConnection.Query("DELETE FROM AspNetUsers WHERE Email = @userEmail", new { userEmail });
		}

		private string GetUserIdByEmail(string userEmail)
		{
			var userId = _dbConnection.Query<string>("SELECT Id FROM AspNetUsers WHERE Email = @userEmail", new { userEmail }).FirstOrDefault();

			return userId;
		}

		private void DeleteUserRolesByUserId(string userId)
		{
			_dbConnection.Query("DELETE FROM AspNetUserRoles WHERE UserId = @userId", new { userId });
		}

		private void DeleteConsumerUserByConsumerId(Guid consumerId)
		{
			_dbConnection.Query("DELETE FROM ConsumerUsers WHERE ConsumerId = @consumerId", new { consumerId });
		}

		public void Dispose()
		{
			_dbConnection?.Dispose();
		}
	}
}