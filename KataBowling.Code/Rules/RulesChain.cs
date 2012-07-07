using System.Collections.Generic;
using System.Linq;

namespace KataBowling.RulesChains
{
	public class RulesChain : IRulesChain
	{
		private readonly IList<IRuleLink> _ruleLinks;
		private readonly IConfiguration _configuration;

		public RulesChain(IConfiguration configuration, IList<IRuleLink> ruleLinks)
		{
			_ruleLinks = ruleLinks;
			_configuration = configuration;
		}

		public int Execute(IList<IFrame> frames)
		{
			int score = 0;
			int frameScore = 0;

			foreach (var f in frames.Where(f=>f.Sequence < _configuration.NumberOfFrames))
			{
				frameScore = 0;
				foreach (var rl in _ruleLinks)
				{
					if (frameScore == 0)
					{
						frameScore = rl.Handle(f, frames);
						score += frameScore;
					}
				}
			}

			return score;
		}
	}
}
