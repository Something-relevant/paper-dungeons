using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator
{
    private int maxIterations;
    private int roomLengthMin;
    private int roomWidthMin;

    public RoomGenerator(int maxIterations, int roomLengthMin, int roomWidthMin)
    {
        this.maxIterations = maxIterations;
        this.roomLengthMin = roomLengthMin;
        this.roomWidthMin = roomWidthMin;
    }

    public List<RoomNode> GenerateRoomsInGivenSpace(List<Node> roomSpaces,
        float roomBottomCornerModifier,
        float roomTopCornerModifier,
        int roomOffset)
    {
        List<RoomNode> listToReturn = new List<RoomNode>();
        foreach(var space in roomSpaces)
        {
            Vector2Int newBottomLeftPoint = StructureHelper.GenerateBottomLeftCornerBetween(
                space.BottomLeftAreaCorner, 
                space.TopRightAreaCorner,
                0.1f, 1); // change values for increase randomess, closeness of rooms

            Vector2Int newTopRightPoint = StructureHelper.GenerateBottomLeftCornerBetween(
                space.BottomLeftAreaCorner,
                space.TopRightAreaCorner,
                0.9f, 1); // change values for increase randomess, closeness of rooms

            space.BottomLeftAreaCorner = newBottomLeftPoint;
            space.TopRightAreaCorner = newTopRightPoint;
            space.BottomRightAreaCorner = new Vector2Int(newTopRightPoint.x, newBottomLeftPoint.y);
            space.TopLeftAreaCorner = new Vector2Int(newBottomLeftPoint.x, newTopRightPoint.y);
            listToReturn.Add((RoomNode)space);

        }

        return listToReturn;
    }
}