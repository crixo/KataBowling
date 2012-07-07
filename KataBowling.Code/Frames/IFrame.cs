using System;
using System.Collections.Generic;

namespace KataBowling
{
	public interface IFrame
	{
		int Sequence { get; }

		IList<Roll> Rolls { get; set; }
	}
}
