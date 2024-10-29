using System.Collections.Generic;
using UnityEngine;

public class PlaceLoader : MonoBehaviour
{
#pragma warning disable IDE0044 // Add readonly modifier
    public LevelDataSO data;
    [SerializeField] GameObject player1, player2, obstacle, gameItem;
    [SerializeField] GameItemSO Rock, Paper, Scissors;
    [SerializeField] bool settingPositions;
#pragma warning restore IDE0044 // Add readonly modifier

    readonly List<GameObject> obstacles = new();
    GameObject rock1, rock2, paper1, paper2, scissors1, scissors2;

    void OnEnable()
    {
        player1.GetComponent<PlayerController>().enabled = true;
        player2.GetComponent<PlayerController>().enabled = true;
        player1.transform.SetPositionAndRotation(data.Player1StartPosition, Quaternion.identity);
        player2.transform.SetPositionAndRotation(data.Player2StartPosition, Quaternion.identity);
        rock1 = Instantiate(gameItem, data.Rock1, Quaternion.identity);
        rock1.GetComponent<GameItem>().Set(Rock);
        rock2 = Instantiate(gameItem, data.Rock2, Quaternion.identity);
        rock2.GetComponent<GameItem>().Set(Rock);
        paper1 = Instantiate(gameItem, data.Paper1, Quaternion.identity);
        paper1.GetComponent<GameItem>().Set(Paper);
        paper2 = Instantiate(gameItem, data.Paper2, Quaternion.identity);
        paper2.GetComponent<GameItem>().Set(Paper);
        scissors1 = Instantiate(gameItem, data.Scissors1, Quaternion.identity);
        scissors1.GetComponent<GameItem>().Set(Scissors);
        scissors2 = Instantiate(gameItem, data.Scissors2, Quaternion.identity);
        scissors2.GetComponent<GameItem>().Set(Scissors);
        foreach (TransformData trd in data.Obstacles)
        {
            obstacles.Add(Instantiate(obstacle, trd.Position, Quaternion.Euler(trd.Rotation)));
            obstacles[^1].transform.localScale = trd.Scale;
        }
    }
    void Update()
    {
        if (settingPositions)
        {
            player1.transform.SetPositionAndRotation(data.Player1StartPosition, Quaternion.identity);
            player2.transform.SetPositionAndRotation(data.Player2StartPosition, Quaternion.identity);
            rock1.transform.SetPositionAndRotation(data.Rock1, Quaternion.identity);
            rock2.transform.SetPositionAndRotation(data.Rock2, Quaternion.identity);
            paper1.transform.SetPositionAndRotation(data.Paper1, Quaternion.identity);
            paper2.transform.SetPositionAndRotation(data.Paper2, Quaternion.identity);
            scissors1.transform.SetPositionAndRotation(data.Scissors1, Quaternion.identity);
            scissors2.transform.SetPositionAndRotation(data.Scissors2, Quaternion.identity);
            if (obstacles.Count > data.Obstacles.Length)
            {
                for (int i = data.Obstacles.Length; i < obstacles.Count; i++)
                    Destroy(obstacles[i]);
                obstacles.RemoveRange(data.Obstacles.Length, obstacles.Count - data.Obstacles.Length);
            }
            else if (obstacles.Count < data.Obstacles.Length)
                for (int i = obstacles.Count; i < data.Obstacles.Length; i++)
                    obstacles.Add(Instantiate(obstacle, data.Obstacles[i].Position, Quaternion.Euler(data.Obstacles[i].Rotation)));
            for (int i = 0; i < obstacles.Count; i++)
            {
                obstacles[i].transform.localScale = data.Obstacles[i].Scale;
                obstacles[i].transform.SetPositionAndRotation(data.Obstacles[i].Position, Quaternion.Euler(data.Obstacles[i].Rotation));
            }
        }
    }
    void OnDisable()
    {
        player1.GetComponent<PlayerController>().enabled = false;
        player2.GetComponent<PlayerController>().enabled = false;
        player1.transform.SetPositionAndRotation(data.Player1StartPosition, Quaternion.identity);
        player2.transform.SetPositionAndRotation(data.Player2StartPosition, Quaternion.identity);
        Destroy(rock1);
        Destroy(rock2);
        Destroy(paper1);
        Destroy(paper2);
        Destroy(scissors1);
        Destroy(scissors2);
        for (int i = 0; i < obstacles.Count; i++)
            Destroy(obstacles[i]);
        obstacles.Clear();
    }
}
