using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static CharacterControl instance;
    
    [SerializeField] private Character _character;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }
}
