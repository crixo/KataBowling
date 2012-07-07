using System.Collections.Generic;
using System.Linq;

namespace KataBowling.RulesChains
{
	public class SpareRuleLink : RuleLinkBase, IRuleLink
	{
		public SpareRuleLink(IConfiguration configuration)
			: base(configuration){}

		protected override bool CanHandle(IFrame frame)
		{
			return frame.Rolls
							.Where(r => r.Pins.HasValue)
							.Select(r => r.Pins.Value)
							.Sum() == Configuration.NumberOfPins;
		}

		public override int Handle(IFrame frame, IList<IFrame> frames)
		{
			if (!CanHandle(frame)) return 0;

			int frameScore =  frame.Rolls
				.Where(r => r.Pins.HasValue)
				.Select(r => r.Pins.Value)
				.Sum();

			var nextFrame = frames.FirstOrDefault(f=>f.Sequence == frame.Sequence+1);

			int firstRollNextFrame = nextFrame != null && nextFrame.Rolls.First().Pins.HasValue 
				? nextFrame.Rolls.First().Pins.Value : 0;

			return frameScore + firstRollNextFrame;
		}
	}
}
