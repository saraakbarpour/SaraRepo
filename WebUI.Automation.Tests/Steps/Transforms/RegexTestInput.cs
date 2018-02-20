using Fare;

namespace WebUI.Automation.Tests.Steps.Transforms
{
	public class RegexTestInput
	{
		public RegexTestInput(string input)
		{
			if (input.StartsWith("^") && input.EndsWith("$"))
				Value = new Xeger(input).Generate();
			else
				Value = input;
		}

		public string Value { get; }
	}
}