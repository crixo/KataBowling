using System.Collections.Generic;

namespace KataBowling.RulesChains
{
	public interface IRulesChain
	{
		int Execute(IList<IFrame> frames);
	}
}
