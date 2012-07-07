
using System;
using System.Collections.Generic;
using System.Linq;
using KataBowling.RulesChains;

namespace KataBowling
{
	public class Game
	{
		private List<int> _scorePerRolls;
		private readonly IRulesChain _rulesChain;
		private readonly IFramesFactory _framesFactory;

		public Game(IFramesFactory frameFactory, IRulesChain rulesChain)
		{
			_rulesChain = rulesChain;
			_framesFactory = frameFactory;
			_scorePerRolls = new List<int>();
		}

		public void roll(int pins)
		{
			_scorePerRolls.Add(pins);
		}

		public int score()
		{
			var frames = _framesFactory.Create(_scorePerRolls);

			var score = _rulesChain.Execute(frames);

			return score;
		}
	}
}
