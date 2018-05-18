using System;
using System.Collections.Generic;
using System.Linq;
using RandomNameGenerator;

namespace WebUI.Automation.Tests.Helpers
{
	public class DataHelper
	{
		private static readonly Random Random = new Random();

		public static string GenerateRandomName()
		{
			var genderList = new List<Gender> {Gender.Female, Gender.Male};
			return NameGenerator.Generate(genderList.ElementAt(Random.Next(0, genderList.Count)));
		}
	}
}