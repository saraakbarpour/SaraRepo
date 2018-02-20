using System.Linq;
using TechTalk.SpecFlow;

namespace WebUI.Automation.Tests.Steps.Transforms
{
	[Binding]
	public class StepArgumentTransforms
	{
		[StepArgumentTransformation]
		public string[] ConvertCommaSeparatedValuesToStringArray(string commaSeparatedValues)
		{
			return commaSeparatedValues.Split(',').Select(s => s.Trim()).ToArray();
		}

		[StepArgumentTransformation]
		public RegexTestInput GenerateInputFromRegex(string input)
		{
			return new RegexTestInput(input);
		}
	}
}