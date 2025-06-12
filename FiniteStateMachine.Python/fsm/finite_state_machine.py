from typing import TypeVar, Generic, Iterable
from .state import State

TInput = TypeVar('TInput')
TOutput = TypeVar('TOutput')

class FiniteStateMachine(Generic[TInput, TOutput]):
    """A generic finite state machine implementation."""
    
    def __init__(self, initial_state: State[TInput, TOutput]):
        """Create a new instance of FiniteStateMachine."""
        self._current_state = initial_state
    
    def process_inputs(self, inputs: Iterable[TInput]) -> TOutput:
        """Process a sequence of inputs and return the final state's output."""
        for input_value in inputs:
            self._current_state = self._current_state.process_input(input_value)
        return self._current_state.output
    
    @property
    def current_output(self) -> TOutput:
        """Get the current state's output."""
        return self._current_state.output
    
    def reset(self, initial_state: State[TInput, TOutput]) -> None:
        """Reset the machine to its initial state."""
        self._current_state = initial_state
