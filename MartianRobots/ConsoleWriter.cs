﻿namespace MartianRobots;

public class ConsoleWriter : IWriter
{
    public string WriteLine(string? message)
    {
        Console.WriteLine(message);
        return message;
    }
}
