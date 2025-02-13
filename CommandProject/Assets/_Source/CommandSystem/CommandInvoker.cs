using System;
using System.Collections.Generic;
using UnityEngine;
namespace CommandSystem
{

    public class CommandInvoker
    {
        private Stack<Action> methodUndoStack = new Stack<Action>();
        private Queue<Action> methodStartQueue = new Queue<Action>();
        private int methodmaxCount;
        private readonly Dictionary<Type, Command> _states;
        public CommandInvoker(TpCommand tpCommand, CreateObjCommand createSmthcommand1, int value)
        {
            _states = new Dictionary<Type, Command>()
            {
                {typeof(TpCommand), tpCommand},
                {typeof(CreateObjCommand), createSmthcommand1},

            };
            methodmaxCount = value;
        }
        public void StartCommand<T>(Vector2 position) where T : Command
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
                if (methodStartQueue.Count > methodmaxCount)
                {
                    methodStartQueue.Dequeue();
                }
                methodStartQueue.Enqueue(() => _states[typeof(T)].Invoke(position));
                methodUndoStack.Push(_states[typeof(T)].Undo);

            }
        }
        public void InvokeAllMetods()
        {
            for (int i = 0; i < methodStartQueue.Count; i++)
            {
                methodStartQueue.Dequeue().Invoke();
            }
        }
        public void UndoLastCommand()
        {
            if (methodUndoStack.Count > 0)
            {
                methodUndoStack.Pop()?.Invoke();
            }
        }
    }

}