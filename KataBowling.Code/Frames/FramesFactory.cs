using System.Collections.Generic;

namespace KataBowling
{
	public class FramesFactory : IFramesFactory
	{
		private readonly IConfiguration _configuration;

		public FramesFactory(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IList<IFrame> Create(IList<int> rolls)
		{
			var rollsWithNullShots = AddNullRollsDueToStrike(rolls);

			var frames = new List<IFrame>();
			IFrame currentFrame = null;

			for (var i = 0; i<rollsWithNullShots.Count; i++)
			{
				if ((i) % _configuration.NumberOfRollsPerFrame == 0)
				{
					currentFrame = new Frame(frames.Count);
					frames.Add(currentFrame);
				}

				currentFrame.Rolls.Add(new Roll(rollsWithNullShots[i]));
			}

			return frames;
		}

		private List<int?> AddNullRollsDueToStrike(IList<int> rolls)
		{
			var rollsWithNullShots = new List<int?>();
			for (var i = 0; i < rolls.Count; i++)
			{
				var currentRoll = rolls[i];
				rollsWithNullShots.Add(rolls[i]);

				if (currentRoll == _configuration.NumberOfPins)
				{
					for (var r = 1; r < _configuration.NumberOfRollsPerFrame; r++)
					{
						rollsWithNullShots.Add(null);
					}
				}
			}
			return rollsWithNullShots;
		}
	}
}
