using System.Collections.Generic;

namespace KataBowling
{
	public interface IRuleLink
	{
		int Handle(IFrame frame, IList<IFrame> frames);
	}
}
