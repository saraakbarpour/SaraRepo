using System;

namespace Automation.Repositories.UserManagement
{
	public class UserDto
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public DateTime? LockoutEndTime { get; set; }
	}
}