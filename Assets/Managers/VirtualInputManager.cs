using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class VirtualInputManager : Singleton<VirtualInputManager>
{  
    public bool MoveRight;
    public bool MoveLeft;
    public bool Jump;
    public bool Sprint;
    public bool Grapple;
}
