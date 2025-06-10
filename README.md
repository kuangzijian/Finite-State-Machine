# Finite State Machine Implementation

This project implements a generic Finite State Machine (FSM) in C# with a specific implementation for solving the mod-three problem. The solution demonstrates Object-Oriented Design principles and provides a reusable FSM framework that can be extended for various FSM problems.

## Problem Description

The implementation solves the following problem: Given a string of ones and zeros representing an unsigned binary integer, compute the remainder when the represented value is divided by three.

Examples:
- Input: '1101' (13 in decimal) → Output: 1 (13 ÷ 3 = 4 remainder 1)
- Input: '1110' (14 in decimal) → Output: 2 (14 ÷ 3 = 4 remainder 2)
- Input: '1111' (15 in decimal) → Output: 0 (15 ÷ 3 = 5 remainder 0)

## Solution Approach

The solution uses a Finite State Machine with three states (S0, S1, S2) representing the possible remainders when divided by 3. The FSM processes the input binary string one character at a time, from most significant bit to least significant bit.

### State Transition Logic

When processing a binary digit in state Sx (where x is the current remainder):
1. For input '0': New remainder = (2x) mod 3
2. For input '1': New remainder = (2x + 1) mod 3

## Project Structure

- `FiniteStateMachine.Core/`: Contains the core FSM implementation
  - `IState.cs`: Generic interface for FSM states
  - `FiniteStateMachine.cs`: Generic FSM implementation
  - `ModThreeState.cs`: Specific implementation for mod-three problem
- `FiniteStateMachine.Tests/`: Contains unit tests
  - `ModThreeTests.cs`: Test cases for the mod-three FSM

## Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or Visual Studio Code with C# extension

## Building the Project

1. Clone the repository:
```powershell
git clone [repository-url]
cd Finite-State-Machine
```

2. Build the solution:
```powershell
dotnet build
```

## Running Tests

To run the unit tests:
```powershell
dotnet test
```

## Usage Example

```csharp
// Create an instance of the FSM with initial state S0
var fsm = new FiniteStateMachine<char, int>(ModThreeState.S0);

// Process a binary number and get its remainder when divided by 3
string binaryNumber = "1101";  // 13 in decimal
int remainder = fsm.ProcessInputs(binaryNumber);  // Returns 1
```

## Design Features

1. **Generic Implementation**: The FSM is implemented using generics (`TInput`, `TOutput`) allowing for different types of inputs and outputs.
2. **State Pattern**: Uses the State design pattern to encapsulate state-specific behavior.
3. **Immutable States**: Each state is immutable and shared across instances.
4. **Extensible Design**: New FSM implementations can be created by implementing the `IState` interface.