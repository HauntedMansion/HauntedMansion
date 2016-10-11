using UnityEngine;
using System.Collections.Generic;

public class RandomRoomGenerator : MonoBehaviour {

  public List<GameObject> rooms;

  GameObject[] roomSpawns;

	void Start ()
  {
    roomSpawns = GameObject.FindGameObjectsWithTag("RoomSpawn");
    AddRoomsOnDoorways();
	}
  void AddRoomsOnDoorways()
  {     
    for (int i = 0; i < roomSpawns.Length; i++)
    {
      int randomRoom = Random.Range(0, rooms.Count);
      Instantiate(rooms[randomRoom], roomSpawns[i].transform.localPosition, roomSpawns[i].transform.localRotation);
    }
  }

}
