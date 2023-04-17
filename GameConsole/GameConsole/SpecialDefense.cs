namespace GameConsole
{
    public abstract class SpecialDefense
    {
        public abstract int CalculateDamageReduction();

        public static SpecialDefense Null { get; } = new NullDefence();

        private class NullDefence : SpecialDefense
        {
            public override int CalculateDamageReduction()
            {
                return 0; // no op or do nothng behaviour
            }
        }
    }
}
