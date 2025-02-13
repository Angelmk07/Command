using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Stack<Action> methodUndoStack = new Stack<Action>();
    private Action methodStart;
    private readonly Dictionary<Type, Command> _states;
    public CommandInvoker(Tp tpCommand, CreateSmth createSmthcommand1)
    {
        _states = new Dictionary<Type, Command>()
            {
                {typeof(Tp), tpCommand},
                {typeof(CreateSmth), createSmthcommand1},

            };
    }
    public void StartCommand<T>( Vector2 position) where T : Command
    {
        if (_states.ContainsKey(typeof(T)))
        {
            _states[typeof(T)].Invoke(position);
            methodUndoStack.Push(_states[typeof(T)].Undo);

        }
    }
    public void PutIn<T>(Vector2 position) where T : Command
    {
        if (_states.ContainsKey(typeof(T)))
        {
            methodStart += () =>  _states[typeof(T)].Invoke(position);
            methodUndoStack.Push(_states[typeof(T)].Undo);

        }
    }
    public void InvokeAllMetods()
    {
        methodStart?.Invoke();
    }
    public void UndoLastCommand()
    {
        if (methodUndoStack.Count > 0)
        {
            methodUndoStack.Pop()?.Invoke();
        }
    }
}
