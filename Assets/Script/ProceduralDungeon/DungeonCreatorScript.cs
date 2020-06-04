using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreatorScript : MonoBehaviour
{

    public int dungeonWidth, dungeonLength;
    public int roomWidthMin, roomLengthMin;
    public int maxIterations;
    public int corridorWidth;

    public Material material;

    [Range(0.0f, 0.3f)]
    public float roomBottomCornerModifier;
    [Range(0.7f, 1.0f)]
    public float roomTopCornerModifier;
    [Range(0, 2)]
    public int roomOffset;

    GameObject wallVertical, wallHorizontal;

    List<Vector3Int> possibleDoorVerticlePosition;
    List<Vector3Int> possibleDoorHorizontalPosition;

    List<Vector3Int> possibleWallVerticlePosition;
    List<Vector3Int> possibleWallHorizontalPosition;



    // Start is called before the first frame update
    void Start()
    {
        CreateDungeon();
    }


    private void CreateDungeon()
    {
        DungeonGenerator generator = new DungeonGenerator(dungeonWidth, dungeonLength);

        var listOfRooms = generator.CalculateDungeon(
            maxIterations,
            roomWidthMin,
            roomLengthMin,
            roomBottomCornerModifier,
            roomTopCornerModifier, 
            roomOffset,
            corridorWidth
            );

        GameObject wallParent = new GameObject("wallParent");
        wallParent.transform.parent = transform;

        possibleDoorVerticlePosition = new List<Vector3Int>();
        possibleDoorHorizontalPosition = new List<Vector3Int>();

        possibleWallVerticlePosition = new List<Vector3Int>();
        possibleWallHorizontalPosition = new List<Vector3Int>();

        for (int i = 0; i < listOfRooms.Count; i++)
        {
            CreateMesh(
                listOfRooms[i].BottomLeftAreaCorner,
                listOfRooms[i].TopRightAreaCorner,
                wallParent);
        }

    }

    private void CreateMesh(
        Vector2 bottomLeftCorner,
        Vector2 topRightCorner, 
        GameObject wallParent)
    {
        Vector3 bottomLeftV = new Vector3(bottomLeftCorner.x, 0, bottomLeftCorner.y);
        Vector3 bottomRightV  = new Vector3(topRightCorner.x, 0, bottomLeftCorner.y);
        Vector3 topLeftV = new Vector3(bottomLeftCorner.x, 0, topRightCorner.y);
        Vector3 topRightV = new Vector3(topRightCorner.x, 0, topRightCorner.y);

        Vector3[] vertices = new Vector3[]
        {
           topLeftV,
           topRightV,
           bottomLeftV,
           bottomRightV
        };

        Vector2[] uvs = new Vector2[vertices.Length];
        for(int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        int[] triangles = new int[]
        {
            0,
            1,
            2,
            2,
            1,
            3,
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        GameObject dungeonFloor = new GameObject("Mesh"+bottomLeftCorner, typeof(MeshFilter), typeof(MeshRenderer));

        dungeonFloor.transform.position = Vector3.zero;
        dungeonFloor.transform.localScale = Vector3.one;
        dungeonFloor.GetComponent<MeshFilter>().mesh = mesh;
        dungeonFloor.GetComponent<MeshRenderer>().material = material;

        for (int row = (int)bottomLeftV.x; row < (int)bottomRightV.x; row++)
        {
            var wallPosition = new Vector3(row, 0, bottomLeftV.z);
            AddWallPositionToList(wallPosition, possibleWallHorizontalPosition, possibleDoorHorizontalPosition);
        }




    }

    private void AddWallPositionToList(Vector3 wallPosition, List<Vector3Int> possibleWallHorizontalPosition, List<Vector3Int> possibleDoorHorizontalPosition)
    {
        Vector3Int point = Vector3Int.CeilToInt(wallPosition);
        //if (wallList.contain) { }
    }
}


