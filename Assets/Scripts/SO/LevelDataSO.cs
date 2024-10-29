using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataSO", menuName = "LevelData SO", order = -215)]
public class LevelDataSO : ScriptableObject
{
    public TransformData[] Obstacles;
    public Vector3 Player1StartPosition, Player2StartPosition, Rock1, Rock2, Paper1, Paper2, Scissors1, Scissors2;
}

[Serializable]
public struct TransformData
{
    public Vector3 Position, Rotation, Scale;
}