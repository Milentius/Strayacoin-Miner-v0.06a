using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

public class OutputManager
{
    public bool NoNewLine { get; set; } = false;
    public bool EndOfGroupedMessages { get; set; } = false;

    private readonly System.Timers.Timer timer;
    private readonly ConcurrentQueue<ColoredMessage> messageQueue;

    public OutputManager(double interval)
    {
        messageQueue = new ConcurrentQueue<ColoredMessage>();
        timer = new System.Timers.Timer(interval);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
    }

    public void ClearScreen()
    {
        Console.Clear();
        Console.ResetColor();
    }

    public void Start()
    {
        Console.WriteLine("Starting Output Manager.");
        timer.Start();
    }

    public void Stop()
    {
        Console.WriteLine("Stopping Output Manager.");
        timer.Stop();
    }

    public void EnqueueMessage(string message, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, int buffer = 0)
    {
        messageQueue.Enqueue(new ColoredMessage(message, foregroundColor, backgroundColor, buffer));
    }

    public void EnqueueMessages(IEnumerable<(string Message, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor, int Buffer, bool IsLastMessage)> messages)
    {
        foreach (var (message, foregroundColor, backgroundColor, buffer, isLastMessage) in messages)
        {
            messageQueue.Enqueue(new ColoredMessage(message, foregroundColor, backgroundColor, buffer, isLastMessage));
        }
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        while (messageQueue.TryDequeue(out ColoredMessage coloredMessage))
        {
            WriteColoredMessage(coloredMessage);
        }
    }

    private void WriteColoredMessage(ColoredMessage coloredMessage)
    {
        string Message = coloredMessage.Message;

        Console.BackgroundColor = coloredMessage.BackgroundColor;
        Console.Write(new string(' ', coloredMessage.Buffer));
        Console.ResetColor();

        foreach (char c in Message)
        {
            if (c == ' ')
            {
                Console.Write(c);
            }
            else
            {
                if(Console.BackgroundColor != coloredMessage.BackgroundColor)
                {
                    Console.BackgroundColor = coloredMessage.BackgroundColor;
                }
                if(Console.ForegroundColor != coloredMessage.ForegroundColor)
                {
                    Console.ForegroundColor = coloredMessage.ForegroundColor;
                }
                Console.Write(c);
                Console.ResetColor();
            }
        }

        Console.BackgroundColor = coloredMessage.BackgroundColor;
        if (coloredMessage.IsLastMessage)
        {
            Console.WriteLine(new string(' ', coloredMessage.Buffer));
        }
        else
        {
            Console.Write(new string(' ', coloredMessage.Buffer));
        }

        Console.ResetColor();
    }

    
}

public struct ColoredMessage
{
    public bool IsLastMessage { get; set; }
    public string Message { get; }
    public ConsoleColor ForegroundColor { get; }
    public ConsoleColor BackgroundColor { get; }
    public int Buffer { get; }

    public ColoredMessage(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor, int buffer, bool isLastMessage = false)
    {
        Message = message;
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
        Buffer = buffer;
        IsLastMessage = isLastMessage;
    }
}
