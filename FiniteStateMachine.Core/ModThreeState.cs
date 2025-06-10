namespace FiniteStateMachine.Core
{
    /// <summary>
    /// A state implementation for the mod-three problem.
    /// </summary>
    public class ModThreeState : IState<char, int>
    {
        private readonly int currentRemainder;
        private readonly Dictionary<char, ModThreeState> transitions;

        private ModThreeState(int remainder)
        {
            currentRemainder = remainder;
            transitions = new Dictionary<char, ModThreeState>();
        }

        public int Output => currentRemainder;

        public IState<char, int> ProcessInput(char input)
        {
            if (input != '0' && input != '1')
                throw new ArgumentException("Input must be '0' or '1'", nameof(input));

            return transitions[input];
        }

        // Static instances representing the three possible states
        public static readonly ModThreeState S0 = new ModThreeState(0);
        public static readonly ModThreeState S1 = new ModThreeState(1);
        public static readonly ModThreeState S2 = new ModThreeState(2);

        // Static constructor to initialize the state transitions
        static ModThreeState()
        {
            // When in state S0 (remainder 0):
            // Input 0: (0 * 2) % 3 = 0 -> S0
            // Input 1: (0 * 2 + 1) % 3 = 1 -> S1
            S0.transitions['0'] = S0;
            S0.transitions['1'] = S1;

            // When in state S1 (remainder 1):
            // Input 0: (1 * 2) % 3 = 2 -> S2
            // Input 1: (1 * 2 + 1) % 3 = 0 -> S0
            S1.transitions['0'] = S2;
            S1.transitions['1'] = S0;

            // When in state S2 (remainder 2):
            // Input 0: (2 * 2) % 3 = 1 -> S1
            // Input 1: (2 * 2 + 1) % 3 = 2 -> S2
            S2.transitions['0'] = S1;
            S2.transitions['1'] = S2;
        }
    }
}
