using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private PathCreator path;
    [SerializeField] private float speed = 2.5f;
    private float _distanceTravelled;
    private readonly EndOfPathInstruction pathEnd = EndOfPathInstruction.Stop;
    
    void Update()
    {
        _distanceTravelled += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(_distanceTravelled, pathEnd);
        
        // Check if the end of the path has been reached
        if (pathEnd == EndOfPathInstruction.Stop && _distanceTravelled >= path.path.length)
        {
            Destroy(gameObject);
        }
    }

    public void SetPath(PathCreator inputPath)
    {
        path = inputPath;
    }
    
}
