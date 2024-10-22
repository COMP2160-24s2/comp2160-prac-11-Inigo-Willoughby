using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject marble;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = marble.transform.position;
        
    }

     void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
