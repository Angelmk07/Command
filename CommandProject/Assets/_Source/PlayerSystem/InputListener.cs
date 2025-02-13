using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private KeyCode keyCodeTp = KeyCode.Mouse0;
    [SerializeField] private KeyCode keyCodeCreate = KeyCode.Mouse1;
    [SerializeField] private KeyCode keyCodeReturn = KeyCode.Z;
    [SerializeField] private KeyCode modifierKey = KeyCode.LeftControl;
    [SerializeField] private KeyCode StartStack = KeyCode.Return;
    [SerializeField] private bool StackMode = false;
    private CommandInvoker _commandInvoker;
    public void Constructor(CommandInvoker commandInvoker)
    {
        _commandInvoker = commandInvoker;
    }
    void Update()
    {
        if(StackMode)
        {
            if (Input.GetKeyDown(keyCodeTp))
            {
                _commandInvoker.PutIn<Tp>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            if (Input.GetKeyDown(keyCodeCreate))
            {
                _commandInvoker.PutIn<CreateSmth>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            if(Input.GetKeyDown(StartStack))
            {
                _commandInvoker.InvokeAllMetods();
            }
        }
        else
        {
            if (Input.GetKeyDown(keyCodeTp))
            {
                _commandInvoker.StartCommand<Tp>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            if (Input.GetKeyDown(keyCodeCreate))
            {
                _commandInvoker.StartCommand<CreateSmth>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
        if(Input.GetKey(modifierKey) && Input.GetKeyDown(keyCodeReturn))
        {
            _commandInvoker.UndoLastCommand();
        }
    }
}
