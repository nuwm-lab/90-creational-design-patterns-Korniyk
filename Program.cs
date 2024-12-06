using System;
using System.Collections.Generic;

// Клас космічної ракети
public class SpaceRocket
{
    public List<string> Stages { get; set; } = new();
    public string EngineType { get; set; }
    public string Payload { get; set; }

    public override string ToString()
    {
        return $"Конфігурація ракети:\n" +
               $"- Ступені: {string.Join(", ", Stages)}\n" +
               $"- Тип двигуна: {EngineType}\n" +
               $"- Корисний вантаж: {Payload}";
    }
}

// Інтерфейс будівельника
public interface IRocketBuilder
{
    void Reset();
    void SetStages(List<string> stages);
    void SetEngineType(string engineType);
    void SetPayload(string payload);
    SpaceRocket GetResult();
}

// Конкретний будівельник
public class RocketBuilder : IRocketBuilder
{
    private SpaceRocket _rocket;

    public RocketBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _rocket = new SpaceRocket();
    }

    public void SetStages(List<string> stages)
    {
        _rocket.Stages = stages;
    }

    public void SetEngineType(string engineType)
    {
        _rocket.EngineType = engineType;
    }

    public void SetPayload(string payload)
    {
        _rocket.Payload = payload;
    }

    public SpaceRocket GetResult()
    {
        return _rocket;
    }
}

// Директор для створення ракет
public class RocketDirector
{
    private IRocketBuilder _builder;

    public RocketDirector(IRocketBuilder builder)
    {
        _builder = builder;
    }

    public void BuildSimpleRocket()
    {
        _builder.Reset();
        _builder.SetStages(new List<string> { "Ступінь 1" });
        _builder.SetEngineType("Твердопаливний двигун");
        _builder.SetPayload("Супутник");
    }

    public void BuildAdvancedRocket()
    {
        _builder.Reset();
        _builder.SetStages(new List<string> { "Ступінь 1", "Ступінь 2", "Ступінь 3" });
        _builder.SetEngineType("Рідиннопаливний двигун");
        _builder.SetPayload("Модуль з екіпажем");
    }
}

// Тестування
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var builder = new RocketBuilder();
        var director = new RocketDirector(builder);

        Console.WriteLine("Створення простої ракети:");
        director.BuildSimpleRocket();
        Console.WriteLine(builder.GetResult());

        Console.WriteLine("\nСтворення складної ракети:");
        director.BuildAdvancedRocket();
        Console.WriteLine(builder.GetResult());
    }
}
