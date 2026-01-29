# CSE 212 AI Coding Assistant Instructions

## Project Overview
This is a **C# data structures and algorithms course repository** for CSE 212 at BYU-Idaho. It's organized into 6 weekly modules (week01-06) covering fundamental data structures: Arrays, Queues, Sets/Maps, Linked Lists, Recursion, and Trees. Each week has `code/` (main implementation), `teach/` (teaching examples), and `learn/` (scaffolded exercises) subdirectories.

## Key Architecture & Patterns

### Project Structure
- **Solution file**: `cse212-ww-student-template.sln` (Visual Studio 2017+ format)
- **Framework**: .NET 10.0 with implicit using statements enabled
- **Testing**: MSTest framework (Microsoft.VisualStudio.TestTools.UnitTesting)
- **Build System**: `dotnet build` (tasks defined for each module)

### Code Organization
- **Static helper classes**: `Arrays`, `SetsAndMaps`, `Recursion` - contain static methods for algorithms
- **Data structure classes**: `LinkedList`, `PriorityQueue`, `TakingTurnsQueue` - implement data structures with internal helper classes (e.g., `Node`, `PriorityItem`)
- **Test files**: Named `*_Tests.cs` with `[TestClass]` and `[TestMethod]` attributes (DO NOT MODIFY comments are common)
- **Solution files**: Separate `*Solution.cs` files exist showing completed implementations (reference only)

### Conventions & Patterns

1. **Method Documentation**: Use XML doc comments (`/// <summary>`) with detailed explanations of algorithm behavior, parameters, and return values. Include examples (e.g., `MultiplesOf(7, 5)` returns `{7, 14, 21, 28, 35}`).

2. **Error Handling**: Use `InvalidOperationException` with descriptive messages for constraint violations (e.g., "The queue is empty.").

3. **Nullable Reference Types**: Disabled (`<Nullable>disable</Nullable>`) - use `?` for nullable types and null-coalescing patterns explicitly.

4. **Collection Use**:
   - `List<T>` for dynamic arrays
   - `HashSet<T>` for O(n) duplicate/existence checks
   - `Dictionary<K, V>` for key-value pairs
   - Custom doubly-linked nodes with `Next` and `Prev` properties

5. **Loop Invariants**: Comments like `// FIXED: must include last element` indicate common bugs to watch for (e.g., off-by-one errors).

## Build & Test Workflow

### Running Tests
```bash
# Build and run tests for a specific week
dotnet test c:\Users\edwinch\Documents\School\cse212-ww-student-template\week01\code\code.csproj

# Build without testing
dotnet build <weekN>/<module>/<module>.csproj
```

### Available Build Tasks
- `build-week0X-code` - main implementations (has tests)
- `build-week0X-teach` - teaching examples
- `build-week0X-learn` - scaffolded exercises
- `build-week0X-analyze` - code analysis projects

Execute tasks via `dotnet build` command or VS Code task runner.

## Critical Implementation Details

### Data Structure Specifics
- **LinkedList** (week04): Doubly-linked with head/tail sentinels; methods include `InsertHead`, `InsertTail`, `RemoveHead` (IEnumerable<int>)
- **PriorityQueue** (week02): Linear search for max priority using `>=` comparison (dequeues LAST highest-priority item); must remove after dequeue
- **Recursion** (week05): Tuple-based solution patterns for complex recursion problems

### Common Bugs to Avoid
- **Off-by-one errors**: Loops must check all elements; watch boundary conditions
- **Missing removal**: Operations like dequeue must both remove AND return items
- **Reverse string/list operations**: Maintain order using proper index calculation
- **Set membership checks**: Use `HashSet<T>.Contains()` for O(1) lookups, not list iteration

## Code Style Requirements

- **Class names**: PascalCase (e.g., `PriorityQueue`, `LinkedList`)
- **Method names**: PascalCase with verb-noun pattern (e.g., `Enqueue`, `Dequeue`, `FindPairs`)
- **Private fields**: `_camelCase` prefix with underscore (e.g., `_queue`, `_head`)
- **Constants**: UPPER_SNAKE_CASE (implicit when used in class context)
- **Implicit usings**: No need to explicitly list `using System`, `using System.Collections`, etc.

## Testing Patterns

Test files use MSTest with scenarios/expected results documented in comments:
```csharp
[TestMethod]
// Scenario: Description of test case
// Expected Result: What should happen
// Defect(s) Found: What bugs this catches
public void TestName() { ... }
```

Tests validate:
- Correct return values
- State changes (ToString() methods for queue/list contents)
- Edge cases (empty structures, boundary values, negative numbers)
- Collection equality using `CollectionAssert.AreEqual()`

## Integration Points

- **Student modifications**: Only edit implementation classes in `code/` directories (not test files)
- **Reference implementations**: Available in `*Solution.cs` files—study but don't copy
- **External files**: week03 uses CSV files (basketball.csv, census.txt) for data processing examples

---

**Last Updated**: January 2026 | **Target Audience**: AI coding assistants helping with CSE 212 coursework
