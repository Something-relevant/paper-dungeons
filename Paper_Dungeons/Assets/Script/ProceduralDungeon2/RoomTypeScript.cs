using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTypeScript : MonoBehaviour
{
    public int roomType;
    // Start is called before the first frame update
    public void DestroyRoom()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
