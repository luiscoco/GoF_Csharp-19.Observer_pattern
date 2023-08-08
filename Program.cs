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
