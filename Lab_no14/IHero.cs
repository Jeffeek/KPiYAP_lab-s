#region Using namespaces

using System;

#endregion

namespace Lab_no14
{
    public interface IHero
    {
        int Life { get; set; }

        double AbilityPossibility { get; }

        IAbility Ability { get; }

        int MinPunch { get; }

        int MaxPunch { get; }

        IPunch Punch(IHero to);

        event EventHandler<IPunch> HeroPunched;

        event EventHandler HeroDied;

        event EventHandler<IAbility> AbilityUsed;
    }
}