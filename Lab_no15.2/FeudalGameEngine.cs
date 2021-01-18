using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_no15._2
{
	public class FeudalGameEngine
    {
	    public event EventHandler LostGame;
	    public event EventHandler WinGame;
	    public event EventHandler MoneyEarned;
	    public event EventHandler MoneySpend;
	    public event EventHandler PeasantAdded;
	    public event EventHandler PeasantRemoved;

	    private int _peasantsCount;
	    private int _money = 0;
	    
	    public bool IsGameOn { get; private set; }

	    public FeudalGameSettings Settings { get; }

	    public int Money
	    {
		    get => _money;
		    private set
		    {
			    if(!IsGameOn) return;
			    var addOrRemove = _money < value;
			    _money = value;
			    if(addOrRemove)
				    MoneyEarned?.Invoke(this, EventArgs.Empty);
			    else
				    MoneySpend?.Invoke(this, EventArgs.Empty);

			    if(value < 0)
				    LostGame?.Invoke(this, EventArgs.Empty);
		    }
	    }

	    public int PeasantsCount
		{
			get => _peasantsCount;
			private set
			{
				if(!IsGameOn) return;
				var addOrRemove = _peasantsCount < value;
				_peasantsCount = value;
				if(addOrRemove)
					PeasantAdded?.Invoke(this, EventArgs.Empty);
				else
					PeasantRemoved?.Invoke(this, EventArgs.Empty);

				if(value == Settings.PeasantsTargetCount)
					WinGame?.Invoke(this, EventArgs.Empty);
			}
	    }

	    //For new game
	    public FeudalGameEngine(int peasantsTargetCount, int startPeasantsCount)
		{
			Settings = new FeudalGameSettings(peasantsTargetCount);
			_peasantsCount = startPeasantsCount;
			Init();
		}

	    //for load
	    public FeudalGameEngine(DTOGameSave gameSave)
	    {
		    Settings = new FeudalGameSettings(gameSave.Settings);
		    _peasantsCount = gameSave.PeasantsCount;
		    Init();
	    }

	    private void Init()
	    {
		    LostGame += ReloadGame;
		    WinGame += ReloadGame;
		    IsGameOn = true;
		}

	    public void MakeStep(Queue<FeudalActions> actions)
	    {
		    while(actions.Any())
		    {
				if (!IsGameOn) break;
				var action = actions.Dequeue();
				switch (action)
				{
					case FeudalActions.IncreaseTax:
						IncreaseTax();
						break;

					case FeudalActions.ReduceTax:
						ReduceTax();
						break;

					case FeudalActions.BuildShack:
						BuildShack();
						break;

					case FeudalActions.GiveFreeRein:
						GiveFreeRein();
						break;

					case FeudalActions.HoldCelebration:
						HoldCelebration();
						break;
				}
			}
			TryToGeneratePeasant();
		}

	    private void TryToGeneratePeasant()
	    {
		    if(PeasantsCount == Settings.MaxPeasantCount) return;
		    var random = new Random();
		    var randomNumber = random.NextDouble();
		    if(randomNumber <= Settings.PeasantSpawnChance)
                PeasantsCount++;
	    }

	    private void ReloadGame(object sender, EventArgs args)
	    {
		    IsGameOn = false;
		    Settings.PeasantSpawnChance = 0.05;
		    Settings.MaxPeasantCount = 0;
		    _money = 0;
		    _peasantsCount = 0;
	    }

		private void IncreaseTax()
		{
			Money = Money + 1;
			Settings.PeasantSpawnChance -= 0.002;
		}

	    private void ReduceTax()
	    {
		    Money = Money - 1;
		    Settings.PeasantSpawnChance += 0.002;
	    }

	    private void BuildShack()
	    {
		    Money -= 10;
		    Settings.MaxPeasantCount += 4;
	    }

	    private void GiveFreeRein()
	    {
		    PeasantsCount--;
		    Settings.PeasantSpawnChance += 0.05;
	    }

	    private void HoldCelebration()
	    {
		    Money -= 20;
		    Settings.PeasantSpawnChance += 0.01;
	    }
    }

    public enum FeudalActions
    {
	    IncreaseTax,
	    ReduceTax,
	    BuildShack,
	    GiveFreeRein,
	    HoldCelebration
	}
}
