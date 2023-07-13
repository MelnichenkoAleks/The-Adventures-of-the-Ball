using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveiment : MonoBehaviour
{
    public Character Character;
    public float MinXPos;
    public float MaxXPos;
    public float MinYPos;
    public float MaxYPos;
    public float SpeedYPos;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(Character.transform.position.x, MinXPos,MaxXPos),
        Mathf.Clamp((Character.transform.position.y +2) * SpeedYPos, MinYPos, MaxYPos), transform.position.z);
    }
}
