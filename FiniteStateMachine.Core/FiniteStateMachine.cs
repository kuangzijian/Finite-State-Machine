namespace FiniteStateMachine.Core
{
    /// <summary>
    /// A generic finite state machine implementation.
    /// </summary>
    /// <typeparam name="TInput">The type of input that triggers state transitions.</typeparam>
    /// <typeparam name="TOutput">The type of output associated with states.</typeparam>
    public class FiniteStateMachine<TInput, TOutput>
    {
        private IState<TInput, TOutput> currentState;

        /// <summary>
        /// Creates a new instance of FiniteStateMachine.
        /// </summary>
        /// <param name="initialState">The initial state of the machine.</param>
        public FiniteStateMachine(IState<TInput, TOutput> initialState)
        {
            currentState = initialState;
        }

        /// <summary>
        /// Processes a sequence of inputs and returns the final state's output.
        /// </summary>
        /// <param name="inputs">The sequence of inputs to process.</param>
        /// <returns>The output of the final state.</returns>
        public TOutput ProcessInputs(IEnumerable<TInput> inputs)
        {
            foreach (var input in inputs)
            {
                currentState = currentState.ProcessInput(input);
            }
            return currentState.Output;
        }

        /// <summary>
        /// Gets the current state's output.
        /// </summary>
        public TOutput CurrentOutput => currentState.Output;

        /// <summary>
        /// Resets the machine to its initial state.
        /// </summary>
        /// <param name="initialState">The state to reset to.</param>
        public void Reset(IState<TInput, TOutput> initialState)
        {
            currentState = initialState;
        }
    }
}
