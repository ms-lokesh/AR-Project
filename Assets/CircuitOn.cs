using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitOn : MonoBehaviour
{
    public bool circuitOn = false;

    /// <summary>
    /// Get the current circuit status
    /// </summary>
    public bool GetCircuitStatus()
    {
        return circuitOn;
    }

    /// <summary>
    /// Set the circuit status
    /// </summary>
    public void SetCircuitStatus(bool status)
    {
        circuitOn = status;
    }

    /// <summary>
    /// Toggle the circuit status
    /// </summary>
    public void ToggleCircuit()
    {
        circuitOn = !circuitOn;
    }
}
