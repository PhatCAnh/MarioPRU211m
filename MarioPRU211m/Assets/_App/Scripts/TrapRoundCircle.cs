using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrapRoundCircle : MonoBehaviour
{
    [SerializeField] private float _rotationDuration = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 360), _rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
