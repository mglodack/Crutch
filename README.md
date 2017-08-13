# Crutch - a C# code analyzer

> Just because the language supports it, does not mean it's okay.

## Supported Functionality

#### Warn on unused parameters

Not usuing parameters on a C# method is allowed. However, if it isn't being used then either it was meant to be used but forgotten or we can remove it.

```cs
class Car
{
  public void MakeNoise(int soundLevel)
  {
    Console.WriteLine("Vroom");
  }
}
```

#### Warn on invalid property assignment

Assigning a property to itself is valid within C#. It also exposes a subtle and hard to find bug.

```cs
class Car
{
  public Car(string make)
  {
    Make = Make;
  }

  public string Make { get; }
}
```
