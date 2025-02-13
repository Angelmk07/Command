using CommandSystem;
using UnityEngine;
namespace PlayerSystem
{

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
            if (StackMode)
            {
                if (Input.GetKeyDown(keyCodeTp))
                {
                    _commandInvoker.PutIn<TpCommand>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                if (Input.GetKeyDown(keyCodeCreate))
                {
                    _commandInvoker.PutIn<CreateObjCommand>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                if (Input.GetKeyDown(StartStack))
                {
                    _commandInvoker.InvokeAllMetods();
                }
            }
            else
            {
                if (Input.GetKeyDown(keyCodeTp))
                {
                    _commandInvoker.StartCommand<TpCommand>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                if (Input.GetKeyDown(keyCodeCreate))
                {
                    _commandInvoker.StartCommand<CreateObjCommand>(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
            if (Input.GetKey(modifierKey) && Input.GetKeyDown(keyCodeReturn))
            {
                _commandInvoker.UndoLastCommand();
            }
        }
    }

}