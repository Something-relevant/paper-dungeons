using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator2 : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;
    public GameObject player;
    public GameObject prison;
    //room index 0 = LR, index 1 = LRB, index 2 == LRT, index 3 == LRTB

    public float roomWidth;
    public float startTimeBtwnRoom;

    //the boundarys of level generator
    public float minX;
    public float maxX;
    public float minY;

    public LayerMask room;

    private int direction;
    private int roomRand;
    private int downCount;
    private float timeBtwnRoom;

    private bool isImageFound = false;
    public bool stopGeneration = false;
 




    void Start()
    {
        // Takes pose and places level generator to that position to determine start
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;

        //creates room
        Instantiate(rooms[0], transform.position, Quaternion.identity);

      
        //GameObject.Destroy(prison);

        direction = Random.Range(1, 6);


    }

     public void Update()
    {

        if (stopGeneration == false && timeBtwnRoom <= 0)
            {
                Move();
                timeBtwnRoom = startTimeBtwnRoom;
            }

            else
            {
                timeBtwnRoom -= Time.deltaTime;

            }

        if (stopGeneration == true)
        {
            GameObject.Destroy(prison);
        }

    }

    // if == effects odds of going left or right more than down
    private void Move()
        {

            if (direction == 1 || direction == 2) //right
            {
                downCount = 0;

                if (transform.position.x < maxX)
                {
                    Vector2 newPosition = new Vector2(transform.position.x + roomWidth, transform.position.y);
                    transform.position = newPosition;

                    roomRand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[roomRand], transform.position, Quaternion.identity);

                    direction = Random.Range(1, 6);
                    if (direction == 3) //prevents overlapping
                    {
                        direction = 2;
                    }

                    else if (direction == 4) //prevents overlapping
                    {
                        direction = 5;
                    }
                }
                else
                {
                    direction = 5;
                }
            }

            else if (direction == 3 || direction == 4) //left
            {
                downCount = 0;

                if (transform.position.x > minX)
                {
                    Vector2 newPosition = new Vector2(transform.position.x - roomWidth, transform.position.y);
                    transform.position = newPosition;

                    roomRand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[roomRand], transform.position, Quaternion.identity);

                    direction = Random.Range(3, 6);
                }

                else
                {
                    direction = 5;
                }

            }

            else if (direction == 5) //down
            {
                downCount++;

                if (transform.position.y > minY)
                {

                    //checks if room above has opening and destroys if not and adds one that does
                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                    var roomTypeComponent = roomDetection.GetComponent<RoomTypeScript>();

                    if (roomTypeComponent.roomType != 1 && roomTypeComponent.roomType != 3)
                    {
                        if (downCount >= 2)
                        {
                            roomTypeComponent.DestroyRoom();
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                        }

                        else
                        {
                            roomTypeComponent.DestroyRoom();

                            int randBottomRoom = Random.Range(1, 4);

                            if (randBottomRoom == 2)
                            {
                                randBottomRoom = 1;
                            }

                            Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                        }
                    }

                    Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - roomWidth);
                    transform.position = newPosition;

                    roomRand = Random.Range(2, 4);
                    Instantiate(rooms[roomRand], transform.position, Quaternion.identity);

                    direction = Random.Range(1, 6);
                }

                else
                {
                    stopGeneration = true;
                }
            }
        }

        //Instantiate(rooms[roomRand], transform.position, Quaternion.identity);
        //direction = Random.Range(1, 6);
        //roomRand = Random.Range(0, rooms.Length);

    }



