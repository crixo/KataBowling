using System.Collections.Generic;

namespace KataBowling
{
	public class Frame : IFrame
	{
		public int Sequence { get; private set; }

		public IList<Roll> Rolls { get; set; }
		
		public Frame(int sequence)
		{
			Sequence = sequence;
			Rolls = new List<Roll>();
		}
	}
}
