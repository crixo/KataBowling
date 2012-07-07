using System.Collections.Generic;

namespace KataBowling
{
	public interface IFramesFactory
	{
		IList<IFrame> Create(IList<int> rolls);
	}
}
