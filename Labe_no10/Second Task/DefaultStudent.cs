using System;

namespace Labe_no10.Second_Task
{
    class DefaultStudent : Student
    {
        public DefaultStudent(string fullName, int visitedClasses) : base(fullName, visitedClasses)
        {
        }

        public override bool PassOffset()
        {
            if (VisitedClasses == TotalCLasses)
                return true;
            if (VisitedClasses > TotalCLasses / 2)
            {
                var rnd = new Random();
                int rndNumber = rnd.Next(0, 11);
                if (rndNumber >= 5)
                    return true;
                return false;
            }

            return false;
        }
    }
}
