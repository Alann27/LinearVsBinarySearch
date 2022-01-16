namespace DiscreteMathematicsII_Project.Utils
{
    public class IntComparer
    {
        public int Count { get; private set; }

        public IntComparer()
        {
            Count = 0;
        }

        public bool Compare(int x, int y)
        {
            Count++;
            return x == y;
        }

    }
}
