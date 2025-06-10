namespace FiniteStateMachine.Core
{
    /// <summary>
    /// Represents a state in a finite state machine.
    /// </summary>
    /// <typeparam name="TInput">The type of input that triggers state transitions.</typeparam>
    /// <typeparam name="TOutput">The type of output associated with the state.</typeparam>
    public interface IState<TInput, TOutput>
    {
        /// <summary>
        /// Gets the output value associated with this state.
        /// </summary>
        TOutput Output { get; }

        /// <summary>
        /// Processes an input and returns the next state.
        /// </summary>
        /// <param name="input">The input to process.</param>
        /// <returns>The next state based on the input.</returns>
        IState<TInput, TOutput> ProcessInput(TInput input);
    }
}
