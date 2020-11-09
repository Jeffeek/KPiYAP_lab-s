using System;

namespace Labe_no10.Second_Task
{
    class BrightHeadStudent : Student
    {
        public BrightHeadStudent(string fullName, int visitedClasses) : base(fullName, visitedClasses)
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
                if (rndNumber >= 3)
                    return true;
                return false;
            }

            return false;
        }
    }
}
