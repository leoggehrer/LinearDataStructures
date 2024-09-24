# Definitionen

## Generischer Datentyp

Ein **generischer Datentyp** in der Programmierung ist ein **Typ**, der so definiert wird, dass er mit **verschiedenen Datentypen** arbeiten kann, ohne dabei seine Funktionalität zu ändern. Generische Datentypen erlauben es, Algorithmen und Strukturen so zu schreiben, dass sie auf Daten beliebigen Typs anwendbar sind, wodurch die Wiederverwendbarkeit und Flexibilität des Codes verbessert wird.

### Definition eines generischen Datentyps (in C#)

In C# werden generische Datentypen durch die Verwendung von **Platzhaltertypen** definiert. Diese Platzhaltertypen werden normalerweise durch **Typ-Parameter** wie `T`, `U`, etc. repräsentiert. Der genaue Typ wird erst zur Laufzeit oder bei der Instanziierung festgelegt.

### Beispiel eines generischen Typs

```csharp
// Eine generische Klasse mit einem Typ-Parameter T
public class Box<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public T GetValue()
    {
        return value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }
}
```

**Instanziierung eines generischen Typs**

Die generische Klasse kann mit beliebigen Datentypen verwendet werden. Bei der Instanziierung muss der konkrete Datentyp angegeben werden:

```csharp
Box<int> intBox = new Box<int>(123);                // T ist int
Box<string> stringBox = new Box<string>("Hello");   // T ist string
```
### Vorteile von generischen Datentypen

1. **Wiederverwendbarkeit:** Generische Klassen und Methoden können mit beliebigen Datentypen arbeiten, sodass derselbe Code für viele verschiedene Typen verwendet werden kann.
2. **Typsicherheit:** Der Compiler überprüft die Typen zur Compile-Zeit, was Laufzeitfehler reduziert.
3. **Performance:** Bei generischen Typen müssen keine Typkonvertierungen durchgeführt werden (z. B. Boxen und Unboxen), was die Leistung verbessert.

Generische Typen sind in vielen modernen Programmiersprachen wie C#, Java und C++ verfügbar und spielen eine zentrale Rolle bei der Implementierung von Datenstrukturen wie Listen, Stacks, Queues und Dictionaries.

## Schnittstelle 

In der Programmierung, insbesondere in C# und anderen objektorientierten Sprachen, bezeichnet eine Schnittstelle (im Englischen "interface") eine Gruppe von Methoden und Eigenschaften, die von einer Klasse implementiert werden müssen, ohne selbst eine Implementierung bereitzustellen. Sie legt lediglich fest, was eine Klasse tun muss, aber nicht wie.

### Eigenschaften einer Schnittstelle:

- **Definiert nur Signaturen:** Eine Schnittstelle enthält nur Methodendeklarationen, Eigenschaften oder Ereignisse. Es gibt keine Implementierung der Methoden in der Schnittstelle.
- **Implementierung durch Klassen:** Eine Klasse, die eine Schnittstelle implementiert, muss alle in der Schnittstelle definierten Methoden und Eigenschaften implementieren.
- **Multiple Implementierungen:** In C# kann eine Klasse mehrere Schnittstellen implementieren, was die Mehrfachvererbung simuliert.
- **Verwendet für Polymorphismus:** Schnittstellen fördern das Konzept des Polymorphismus, da unterschiedliche Klassen dieselbe Schnittstelle implementieren können, aber auf unterschiedliche Weise funktionieren (eine detailiertere Erläuterung dazu folgt in einem späteren Kapitel).

## Mock-Implementierung

Die Mock-Implementierung in diesem Kontext ist eine einfache, konkrete Klasse, die die Schnittstelle IQueue&lt;T&gt; (bzw. IStack&lt;T&gt; in der vorliegenden Aufgabe) implementiert. Der Hauptzweck dieser Implementierung besteht darin, eine funktionierende Instanz der Schnittstelle zu erstellen, die in den Unit-Tests verwendet werden kann.

### Bedeutung und Zweck der Mock-Implementierung:
1. **Unit-Testing ohne konkrete Implementierung:** Normalerweise testet man in Unit-Tests das Verhalten einer konkreten Implementierung. Wenn man jedoch nur eine Schnittstelle hat (wie IQueue<T>), gibt es keine direkte Klasse, die diese Schnittstelle implementiert. Daher erstellt man eine Mock-Implementierung – eine einfache, funktionierende Version der Klasse, die man in den Tests verwenden kann.
2. **Prüfung des Verhaltens der Schnittstelle:** Die Tests überprüfen das Verhalten einer Implementierung dieser Schnittstelle. Indem wir eine rudimentäre Implementierung schreiben (wie die Queue<T>), können wir die Schnittstellenmethoden in den Tests aufrufen und sicherstellen, dass sie erwartungsgemäß funktionieren.
3. **Nicht für den Produktionseinsatz:** Diese Mock-Implementierung ist in der Regel nicht so ausgefeilt wie eine echte, produktionsreife Implementierung. Sie dient nur dazu, die grundlegende Funktionalität zu simulieren, die die Schnittstelle vorgibt. Beispielsweise könnte eine echte Queue oder Stack-Implementierung optimierte Datenstrukturen (wie eine LinkedList oder einen Ringpuffer) verwenden, um die Leistung zu verbessern. Die hier verwendete Implementierung mit einer List&lt;T&gt; ist einfach, aber nicht unbedingt die effizienteste Lösung.
4. **Isolation der Tests:** Wenn sie die Unit-Tests schreiben, möchten sie die Tests isoliert von anderen Abhängigkeiten durchführen. Das bedeutet, dass sie nur die Funktionalität der zu testenden Schnittstelle überprüfen, ohne auf komplexe externe Bibliotheken oder Systeme angewiesen zu sein. Die Mock-Implementierung stellt sicher, dass der Fokus auf dem Testen der Schnittstellenmethoden liegt.
