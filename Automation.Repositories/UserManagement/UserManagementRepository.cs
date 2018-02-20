using System.Collections.Generic;
using System.Linq;

namespace Automation.Repositories.UserManagement
{
	public class UserManagementRepository : BaseRepository
	{
		public UserManagementRepository(string connectionString) : base(connectionString)
		{
		}

		public string GetARandomUsername(string defaultUsername = "gtmondotest@gmail.com")
		{
			var randomUser = Query<string>($@"
				SELECT public.""AspNetUsers"".""UserName""
				FROM public.""AspNetUsers""
				WHERE public.""AspNetUsers"".""UserName"" != {defaultUsername}
				ORDER BY RANDOM() LIMIT 1;").FirstOrDefault();

			return randomUser;
		}

		public IEnumerable<UserDto> GetUsers()
		{
			var users = Query<UserDto>($@"
				SELECT public.""AspNetUsers"".""UserName"",
				null,
				public.""AspNetUsers"".""Email"",
				public.""AspNetUsers"".""LockoutEnd""
				FROM public.""AspNetUsers"";");

			return users;
		}
	}
}