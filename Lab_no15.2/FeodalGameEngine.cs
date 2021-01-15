using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace Lab_no15._2
{
    public class FeodalGameEngine
    {
	    private static class GameFields
	    {
		    public static Random Random = new Random();
		    public static double PeasentSpawnChance = 0.5;
		    public static int MaxPeasentCount = -1;
	    }

	    public event EventHandler LostGame;
	    public event EventHandler WinGame;
	    public event EventHandler MoneyEarned;
	    public event EventHandler MoneySpended;
	    public event EventHandler PeasentAdded;
	    public event EventHandler PeasentRemoved;

	    public bool IsGameOn { get; private set; }
	    private int _peasantsCount;
	    private int _money = 10;

	    public int PeasantsTargetCount { get; }

	    public int Money
	    {
		    get => _money;
		    private set
		    {
			    if(IsGameOn)
			    {
				    bool addOrRemove = _money < value;
				    _money = value;
					if (addOrRemove)
					    MoneyEarned?.Invoke(this, EventArgs.Empty);
				    else
					    MoneySpended?.Invoke(this, EventArgs.Empty);
				    if (value < 0)
					    LostGame?.Invoke(this, EventArgs.Empty);
				}
		    }
	    }

	    public int PeasantsCount
		{
			get => _peasantsCount;
			private set
			{
				if(IsGameOn)
				{
					bool addOrRemove = _peasantsCount < value;
					_peasantsCount = value;
					if (addOrRemove)
						PeasentAdded?.Invoke(this, EventArgs.Empty);
                    else
						PeasentRemoved?.Invoke(this, EventArgs.Empty);
					if (value == PeasantsTargetCount)
						WinGame?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		public FeodalGameEngine(int peasantsTargetCount, int startPeasantsCount)
	    {
		    PeasantsTargetCount = peasantsTargetCount;
		    _peasantsCount = startPeasantsCount;
		    LostGame += ReloadGame;
		    WinGame += ReloadGame;
		    IsGameOn = true;
	    }

	    public void MakeStep(Queue<FeodalActions> actions)
	    {
		    while(actions.Any())
		    {
				if (!IsGameOn) break;
				var action = actions.Dequeue();
				switch (action)
				{
					case FeodalActions.IncreaseTax:
						IncreaseTax();
						break;

					case FeodalActions.ReduceTax:
						ReduceTax();
						break;

					case FeodalActions.BuildShack:
						BuildShack();
						break;

					case FeodalActions.GiveFreeRein:
						GiveFreeRein();
						break;

					case FeodalActions.HoldCelebration:
						HoldCelebration();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		    
		    TryToGeneratePeasent();
	    }

	    private void TryToGeneratePeasent()
	    {
		    var randomNumber = GameFields.Random.NextDouble();
		    if(randomNumber <= GameFields.PeasentSpawnChance)
			    PeasantsCount++;
	    }

	    private void ReloadGame(object sender, EventArgs args)
	    {
		    IsGameOn = false;
		    GameFields.PeasentSpawnChance = 0.05;
		    GameFields.MaxPeasentCount = -1;
		    _money = -1;
		    _peasantsCount = -1;
	    }

		private void IncreaseTax()
		{
			Money = Money + 1;
			GameFields.PeasentSpawnChance -= 0.002;
		}

	    private void ReduceTax()
	    {
		    Money = Money - 1;
		    GameFields.PeasentSpawnChance += 0.002;
	    }

	    private void BuildShack()
	    {
		    Money -= 10;
		    GameFields.MaxPeasentCount += 4;
	    }

	    private void GiveFreeRein()
	    {
		    PeasantsCount--;
		    GameFields.PeasentSpawnChance += 0.05;
	    }

	    private void HoldCelebration()
	    {
		    Money -= 20;
		    GameFields.PeasentSpawnChance += 0.01;
	    }
    }

    public enum FeodalActions
    {
	    IncreaseTax,
	    ReduceTax,
	    BuildShack,
	    GiveFreeRein,
	    HoldCelebration
	}
}
