using System;
namespace KataBowling
{
	public interface IConfiguration
	{
		int NumberOfPins { get; }
		int NumberOfRollsPerFrame { get; }
		int NumberOfFrames { get; }
	}
}
