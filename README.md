# POSE 5ABIF/5AKIF

## LinearDataStructures

Lernziele

- Die Bedeutung von generischen Datentypen verstehen und Wiedergeben (einfach)
- Die Bedeutung von Schnittstellen verstehen und Wiedergeben (einfach)
- Lesen und Verstehen von UnitTests mit Mock-Objekten
- Implementierung von linearen Datenstrukturen (Stack, Queue)
- Ersetzen der Mock-Objekte durch eine eigene Implementierungen

### Aufgabenstellung

In der vorliegenden Aufgabe befinden sich die UnitTests für die linearen Datenstrukturen *Stack*, *Queue* und einer *Universalen Queue*. Analysieren sie die einzelnen Tests und ersetzen sie anschließend die Mock-Objekte durch Ihre eigene Implementierung. Nach dem Austauch der Mock-Objekten durch Ihre Implementierung, sollen alle Tests ebenfalls wieder positiv durchlaufen werden.

#### Vorgehensweise

1. Implementieren sie die Schnittstelle **IStack&lt;T&gt;** im Projekt **LinearDataStruktures.Logic**
2. Erstzen sie in der **Factory**-Klasse die entsprechende Programmzeile wie folgt:
```csharp
...
  public static IStack<T> CreateStack<T>()
  {
      throw new NotImplementedException();
  }
...
```

durch

```csharp
...
  public static IStack<T> CreateStack<T>()
  {
      return new Stack<T>();
  }
...
```
3. Nun ersetzen sie im Unit-Test das Mock-Objekt mit der konkreten Implementierung durch folgende Änderung:
```csharp
...
    [TestClass]
    public class StackUnitTests
    {
        private IStack<int> _stack;

        private static IStack<T> CreateStack<T>()
        {
            return new MockStack<T>();
        }
...
```

durch

```csharp
...
    [TestClass]
    public class StackUnitTests
    {
        private IStack<int> _stack;

        private static IStack<T> CreateStack<T>()
        {
            return DataStructuresFactory.CreateStack<T>();
        }
...
```

Wiederholen sie diese Vorgangsweise für alle anderen Schnittstellen.

## Definitionen 

Wichtige Begriffe aus dieser Aufgabenstellung finden sie hier: [Definitionen](definitions.md)

**Viel Spaß mit der Aufgabe!**