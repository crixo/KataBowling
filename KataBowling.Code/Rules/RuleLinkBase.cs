using System.Collections.Generic;

namespace KataBowling.RulesChains
{
	public abstract class RuleLinkBase
	{		
		protected readonly IConfiguration Configuration;

		protected RuleLinkBase(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected abstract bool CanHandle(IFrame frame);

		public abstract int Handle(IFrame frame, IList<IFrame> frames);
	}
}
