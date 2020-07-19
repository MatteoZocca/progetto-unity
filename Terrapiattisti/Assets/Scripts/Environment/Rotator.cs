using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotateSpeed;

    void Update() {
        pivot.transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
    }
}
