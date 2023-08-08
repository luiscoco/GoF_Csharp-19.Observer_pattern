# GoF_Csharp-19.Observer_pattern

he Observer Pattern is a behavioral design pattern that defines a one-to-many relationship between objects. In this pattern, when one object (known as the subject or observable) changes its state, all its dependent objects (known as observers) are automatically notified and updated accordingly.

This pattern is commonly used in scenarios where you need to maintain consistency between related objects without tightly coupling them. It promotes loose coupling and allows for better separation of concerns in your code.

Here's a simple explanation of the components involved:

Subject (Observable): The object that is being observed. It maintains a list of its observers and provides methods to attach, detach, and notify observers when its state changes.

Observer: The objects that are interested in the state changes of the subject. They subscribe to the subject and are notified when the subject's state changes.

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ConcreteSubject subject = new ConcreteSubject();
        ConcreteObserver observer1 = new ConcreteObserver();
        ConcreteObserver observer2 = new ConcreteObserver();

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.State = 5; // Notifies both observers

        subject.Detach(observer1);

        subject.State = 10; // Only notifies observer2

        Console.ReadLine();
    }
}

// Subject (Observable)
interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Concrete Subject
class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private int state;

    public int State
    {
        get { return state; }
        set
        {
            state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(this);
        }
    }
}

// Observer
interface IObserver
{
    void Update(ISubject subject);
}

// Concrete Observer
class ConcreteObserver : IObserver
{
    private int observerState;

    public void Update(ISubject subject)
    {
        if (subject is ConcreteSubject concreteSubject)
        {
            observerState = concreteSubject.State;
            Console.WriteLine($"Observer updated with state: {observerState}");
        }
    }
}
```

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-16.Iterator_pattern/assets/32194879/1263a83b-d11c-4a48-ad5c-c22eecd42836)

