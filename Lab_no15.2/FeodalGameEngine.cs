using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lab_no15._2
{
    [DataContract]
    public class FeodalGameEngine
    {
	    public event EventHandler LostGame;
	    public event EventHandler WinGame;
	    public event EventHandler MoneyEarned;
	    public event EventHandler MoneySpended;
	    public event EventHandler PeasentAdded;
	    public event EventHandler PeasentRemoved;

	    private int _peasantsCount;
	    private int _money = 0;
	    
	    public bool IsGameOn { get; private set; }
	    [DataMember]
	    public FeodalGameSettings Settings { get; }
	    [DataMember]
	    public int Money
	    {
		    get => _money;
		    private set
		    {
			    if(IsGameOn)
			    {
				    bool addOrRemove = _money < value;
				    _money = value;
				    if(addOrRemove)
					    MoneyEarned?.Invoke(this, EventArgs.Empty);
				    else
					    MoneySpended?.Invoke(this, EventArgs.Empty);

				    if(value < 0)
					    LostGame?.Invoke(this, EventArgs.Empty);
			    }
		    }
	    }
	    [DataMember]
	    public int PeasantsCount
		{
			get => _peasantsCount;
			private set
			{
				if(IsGameOn)
				{
                    bool addOrRemove = _peasantsCount < value;
                    _peasantsCount = value;
					if(addOrRemove)
						PeasentAdded?.Invoke(this, EventArgs.Empty);
					else
						PeasentRemoved?.Invoke(this, EventArgs.Empty);

					if(value == Settings?.PeasantsTargetCount)
						WinGame?.Invoke(this, EventArgs.Empty);
				}
			}
	    }

	    //For new game
	    public FeodalGameEngine(int peasantsTargetCount, int startPeasantsCount)
		{
			Settings = new FeodalGameSettings(peasantsTargetCount);
			_peasantsCount = startPeasantsCount;
			Init();
		}

	    //for load
	    public FeodalGameEngine(DTOGameSave gameSave)
	    {
		    Settings = new FeodalGameSettings(gameSave.Settings);
		    _peasantsCount = gameSave.PeasantsCount;
		    Init();
	    }

	    private void Init()
	    {
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
		    if(PeasantsCount == Settings.MaxPeasentCount) return;
		    var random = new Random();
		    var randomNumber = random.NextDouble();
		    if(randomNumber <= Settings.PeasentSpawnChance)
			    PeasantsCount = _peasantsCount + 1;
	    }

	    private void ReloadGame(object sender, EventArgs args)
	    {
		    IsGameOn = false;
		    Settings.PeasentSpawnChance = 0.05;
		    Settings.MaxPeasentCount = 0;
		    _money = 0;
		    _peasantsCount = 0;
	    }

		private void IncreaseTax()
		{
			Money = Money + 1;
			Settings.PeasentSpawnChance -= 0.002;
		}

	    private void ReduceTax()
	    {
		    Money = Money - 1;
		    Settings.PeasentSpawnChance += 0.002;
	    }

	    private void BuildShack()
	    {
		    Money -= 10;
		    Settings.MaxPeasentCount += 4;
	    }

	    private void GiveFreeRein()
	    {
		    PeasantsCount--;
		    Settings.PeasentSpawnChance += 0.05;
	    }

	    private void HoldCelebration()
	    {
		    Money -= 20;
		    Settings.PeasentSpawnChance += 0.01;
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
