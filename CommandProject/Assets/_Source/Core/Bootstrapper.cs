using CommandSystem;
using PlayerSystem;
using UnityEngine;
namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] private int maxMemory;
        [SerializeField] private int maxMemoryQueue;
        private CommandInvoker commandInvoker;
        private TpCommand tp;
        private CreateObjCommand createSmth;
        public void Awake()
        {
            tp = new(playerInfo.player, maxMemory);
            createSmth = new(playerInfo.smth, maxMemory);
            commandInvoker = new(tp, createSmth, maxMemoryQueue);
            inputListener.Constructor(commandInvoker);
        }
    }

}
