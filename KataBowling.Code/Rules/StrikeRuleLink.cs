using System.Collections.Generic;
using System.Linq;

namespace KataBowling.RulesChains
{
	public class StrikeRuleLink : RuleLinkBase, IRuleLink
	{
		public StrikeRuleLink(IConfiguration configuration)
			: base(configuration){}

		protected override bool CanHandle(IFrame frame)
		{
			return IsStrike(frame);
		}

		public override int Handle(IFrame frame, IList<IFrame> frames)
		{
			if (!CanHandle(frame)) return 0;

			int frameScore = Configuration.NumberOfPins;

			List<int> extraRolls = new List<int>();

			var nextFrame = frames.FirstOrDefault(f => f.Sequence == frame.Sequence + 1);
			while(nextFrame != null && extraRolls.Count < Configuration.NumberOfRollsPerFrame)
			{
				if (IsStrike(nextFrame))
				{
					extraRolls.Add(Configuration.NumberOfPins);
					nextFrame = frames.FirstOrDefault(f => f.Sequence == frame.Sequence + 1);
				}
				else
				{
					extraRolls.Add(
						nextFrame.Rolls
							.Where(r => r.Pins.HasValue)
							.Select(r => r.Pins.Value).ToArray()[extraRolls.Count]					
						);
				}				
			}

			return frameScore + extraRolls.Sum();
		}

		private bool IsStrike(IFrame frame)
		{
			return frame.Rolls.First().Pins == Configuration.NumberOfPins;
		}
	}
}
