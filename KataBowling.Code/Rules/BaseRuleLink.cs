// -----------------------------------------------------------------------
// <copyright file="BaseRuleLink.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KataBowling.RulesChains
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class BaseRuleLink : RuleLinkBase, IRuleLink
	{
		public BaseRuleLink(IConfiguration configuration)
			: base(configuration) { }

		protected override bool CanHandle(IFrame frame)
		{
			return true;
		}

		public override int Handle(IFrame frame, IList<IFrame> frames)
		{
			return frame.Rolls
				.Where(r => r.Pins.HasValue)
				.Select(r => r.Pins.Value)
				.Sum();
		}
	}
}
