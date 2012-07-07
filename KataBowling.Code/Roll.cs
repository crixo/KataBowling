
namespace KataBowling
{
	public class Roll
	{
		public Roll(int? pins)
		{
			Pins = pins;
		}

		public int? Pins { get; private set; }
	}
}
