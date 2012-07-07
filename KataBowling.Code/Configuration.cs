// -----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KataBowling
{
	public class Configuration : IConfiguration
	{
		public int NumberOfPins { get; private set; }

		public int NumberOfRollsPerFrame { get; private set; }

		public int NumberOfFrames { get; private set; }

		public Configuration(int numberOfPins, int numberOfRollsPerFrame, int numberOfFrames)
		{
			NumberOfPins = numberOfPins;
			NumberOfRollsPerFrame = numberOfRollsPerFrame;
			NumberOfFrames = numberOfFrames;
		}
	}
}
