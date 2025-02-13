using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener inputListener;
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private int maxMemory;
    private CommandInvoker commandInvoker;
    private Tp tp;
    private CreateSmth createSmth;
    public void Awake()
    {
        tp = new(playerInfo.player, maxMemory);
        createSmth = new(playerInfo.smth, maxMemory);
        commandInvoker = new(tp, createSmth);
        inputListener.Constructor(commandInvoker);
    }
}
