namespace Labe_no10.Second_Task
{
    class GeniusStudent : Student
    {
        public GeniusStudent(string fullName, int visitedClasses) 
                             : base(fullName, visitedClasses)
        {
        }

        public override bool PassOffset()
        {
            if (VisitedClasses >= 1)
                return true;
            return false;
        }
    }
}
