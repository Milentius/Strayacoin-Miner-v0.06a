# OutputManager Developer Documentation

## Overview
The `OutputManager` class provides an efficient way to manage console output with color formatting and message buffering. It utilizes a timer to process messages asynchronously from a queue.

## Features
- Queue-based message handling.
- Custom foreground and background colors.
- Configurable message buffering.
- Automatic timed message processing.
- Ability to clear the console screen.

## Installation
Ensure your project includes the required dependencies:
```csharp
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;
```

## Usage
### Creating an Instance
Initialize the `OutputManager` with a specified interval (in milliseconds) for processing queued messages.
```csharp
OutputManager outputManager = new OutputManager(1000); // Processes messages every second.
```

### Starting and Stopping
Start or stop the message processing timer:
```csharp
outputManager.Start(); // Begins processing messages.
outputManager.Stop();  // Stops processing messages.
```

### Clearing the Screen
```csharp
outputManager.ClearScreen();
```

### Enqueuing Messages
#### Single Message
```csharp
outputManager.EnqueueMessage("Hello, World!", ConsoleColor.Green, ConsoleColor.Black, 2);
```
#### Multiple Messages
```csharp
var messages = new List<(string, ConsoleColor, ConsoleColor, int, bool)>
{
    ("First Line", ConsoleColor.Yellow, ConsoleColor.Black, 2, false),
    ("Last Line", ConsoleColor.Red, ConsoleColor.Black, 2, true)
};
outputManager.EnqueueMessages(messages);
```

## Internal Mechanism
1. Messages are stored in a `ConcurrentQueue<ColoredMessage>`.
2. The timer triggers `OnTimedEvent`, which dequeues and processes messages.
3. `WriteColoredMessage` prints messages with specified colors and buffers.

## Struct: `ColoredMessage`
Defines a message with color and formatting properties.
```csharp
public struct ColoredMessage
{
    public string Message { get; }
    public ConsoleColor ForegroundColor { get; }
    public ConsoleColor BackgroundColor { get; }
    public int Buffer { get; }
    public bool IsLastMessage { get; set; }
}
```

## Notes
- `NoNewLine` and `EndOfGroupedMessages` properties are included but not currently used in `OutputManager`.
- Ensure `Start()` is called before enqueuing messages for processing.

## License
This documentation is provided as is without warranty.

