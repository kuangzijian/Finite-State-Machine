from abc import ABC, abstractmethod
from typing import TypeVar, Generic

TInput = TypeVar('TInput')
TOutput = TypeVar('TOutput')

class State(Generic[TInput, TOutput], ABC):
    """Abstract base class for FSM states."""
    
    @property
    @abstractmethod
    def output(self) -> TOutput:
        """Get the output value associated with this state."""
        pass
    
    @abstractmethod
    def process_input(self, input_value: TInput) -> 'State[TInput, TOutput]':
        """Process an input and return the next state."""
        pass
