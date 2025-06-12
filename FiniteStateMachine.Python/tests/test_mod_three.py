import pytest
from fsm import FiniteStateMachine, S0

def test_mod_three_processes_input_correctly():
    """Test that the FSM correctly processes binary inputs."""
    test_cases = [
        ("1101", 1),  # 13 % 3 = 1
        ("1110", 2),  # 14 % 3 = 2
        ("1111", 0),  # 15 % 3 = 0
        ("0", 0),     # 0 % 3 = 0
        ("1", 1),     # 1 % 3 = 1
        ("10", 2),    # 2 % 3 = 2
        ("1010", 1),  # 10 % 3 = 1
    ]
    
    for input_str, expected_remainder in test_cases:
        fsm = FiniteStateMachine(S0)
        result = fsm.process_inputs(input_str)
        assert result == expected_remainder

def test_mod_three_handles_empty_input():
    """Test that the FSM handles empty input correctly."""
    fsm = FiniteStateMachine(S0)
    result = fsm.process_inputs("")
    assert result == 0  # Empty input should return remainder 0

def test_mod_three_throws_on_invalid_input():
    """Test that the FSM throws on invalid input."""
    fsm = FiniteStateMachine(S0)
    with pytest.raises(ValueError):
        fsm.process_inputs("102")  # '2' is invalid input

def test_mod_three_can_be_reset():
    """Test that the FSM can be reset to its initial state."""
    fsm = FiniteStateMachine(S0)
    
    # Process some inputs and then reset
    fsm.process_inputs("11")  # Should end in state 2
    fsm.reset(S0)
    result = fsm.process_inputs("1")  # Should end in state 1
    
    assert result == 1
