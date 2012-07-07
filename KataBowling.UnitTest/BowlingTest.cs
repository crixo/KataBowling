using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataBowling.RulesChains;

namespace KataBowling.UnitTest
{
	[TestClass]
	public class BowlingTest
	{
		Game _game;

		[TestInitialize]
		public void MyMethod()
		{
			var configuration = new Configuration(numberOfPins: 10, numberOfRollsPerFrame: 2, numberOfFrames: 10);
			var frameFactory = new FramesFactory(configuration);
			var rulesChain = new RulesChain(
				configuration,
				new IRuleLink[] { 
					new StrikeRuleLink(configuration),
					new SpareRuleLink(configuration),
					new BaseRuleLink(configuration) });
			_game = new Game(frameFactory, rulesChain);
		}

		[TestMethod]
		public void It_should_be_all_zero()
		{
			Rolls(20, 0);

			Assert.AreEqual(0, _game.score());
		}

		[TestMethod]
		public void It_should_be_a_total_of_40_in_20_rolls()
		{
			Rolls(20, 2);

			Assert.AreEqual(40, _game.score());
		}

		[TestMethod]
		public void It_should_be_a_total_of_18_in_20_rolls_due_to_one_spare()
		{
			_game.roll(7);
			_game.roll(3);

			_game.roll(4);
			_game.roll(0);

			Rolls(18, 0);

			Assert.AreEqual( (10 + 4) + (4 + 0), _game.score());
		}

		[TestMethod]
		public void It_should_be_a_total_of_24_in_20_rolls_due_to_one_strike()
		{
			_game.roll(10);

			_game.roll(4);
			_game.roll(3);

			Rolls(18, 0);

			Assert.AreEqual((10 + 4 + 3) + (4 + 3), _game.score());
		}

		[TestMethod]
		public void It_should_be_a_total_of_41_in_20_rolls_due_to_one_strike_followed_by_spare_and_than_a_7_point_frame()
		{
			Rolls(2, 0);

			_game.roll(10);

			_game.roll(4);
			_game.roll(6);

			_game.roll(4);
			_game.roll(3);

			Rolls(14, 0);

			Assert.AreEqual((10 + 4 + 6) + (4 + 6 + 4) + (4 + 3), _game.score());
		}


		[TestMethod]
		public void It_should_be_a_total_of_300_for_a_perfect_game()
		{
			for (var i = 0; i < 13; i++ )
				_game.roll(10);

			Assert.AreEqual(300, _game.score());
		}


		[TestMethod]
		public void It_should_be_a_total_of_30_in_20_rolls_due_to_a_strike_on_last_frame_plus_2_others_strike_as_extra_rolls()
		{
			Rolls(18, 0);

			_game.roll(10);

			_game.roll(10);

			_game.roll(10);


			Assert.AreEqual((10 + 10 + 10), _game.score());
		}

		private void Rolls(int rolls, int scorePerRoll)
		{
			for (int i = 1; i <= rolls; i++)
			{
				_game.roll(scorePerRoll);
			}
		}
	}
}
