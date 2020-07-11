using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update() {
        pivot.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
