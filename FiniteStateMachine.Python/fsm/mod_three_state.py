from typing import Dict
from .state import State

class ModThreeState(State[str, int]):
    """A state implementation for the mod-three problem."""
    
    def __init__(self, remainder: int):
        """Initialize a new state with the given remainder."""
        self._remainder = remainder
        self._transitions: Dict[str, 'ModThreeState'] = {}
    
    @property
    def output(self) -> int:
        """Get the remainder value associated with this state."""
        return self._remainder
    
    def process_input(self, input_value: str) -> 'ModThreeState':
        """Process a binary digit and return the next state."""
        if input_value not in ['0', '1']:
            raise ValueError("Input must be '0' or '1'")
        return self._transitions[input_value]

# Static instances representing the three possible states
S0 = ModThreeState(0)
S1 = ModThreeState(1)
S2 = ModThreeState(2)

# Initialize the state transitions
def _initialize_transitions():
    """Initialize the state transition table."""
    # When in state S0 (remainder 0):
    # Input 0: (0 * 2) % 3 = 0 -> S0
    # Input 1: (0 * 2 + 1) % 3 = 1 -> S1
    S0._transitions['0'] = S0
    S0._transitions['1'] = S1
    
    # When in state S1 (remainder 1):
    # Input 0: (1 * 2) % 3 = 2 -> S2
    # Input 1: (1 * 2 + 1) % 3 = 0 -> S0
    S1._transitions['0'] = S2
    S1._transitions['1'] = S0
    
    # When in state S2 (remainder 2):
    # Input 0: (2 * 2) % 3 = 1 -> S1
    # Input 1: (2 * 2 + 1) % 3 = 2 -> S2
    S2._transitions['0'] = S1
    S2._transitions['1'] = S2

_initialize_transitions()
