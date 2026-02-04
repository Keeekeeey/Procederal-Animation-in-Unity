using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSolver : MonoBehaviour
{
    // The position and rotation we want to stay in range of
    [SerializeField] Transform footDistance;
    // If we exceed this distance from home, next move try will succeed
    [SerializeField] float wantStepAtDistance;
    // How long a step takes to complete
    [SerializeField] float moveDuration;
    // How far past the home position the foot will move as a fraction of wantStepAtDistance
    [SerializeField] float stepOvershootFraction;

    // Start is called before the first frame update
    void Start()
    {
        
        print("foot location");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
