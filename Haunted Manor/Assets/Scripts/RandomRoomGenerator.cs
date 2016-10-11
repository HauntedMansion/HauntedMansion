using UnityEngine;
using System.Collections.Generic;

public class RandomRoomGenerator : MonoBehaviour {

  public List<GameObject> rooms;

  GameObject[] doorways;

	void Start ()
  {
    doorways = GameObject.FindGameObjectsWithTag("Doorway");
    AddRoomsOnDoorways();
	}
  void AddRoomsOnDoorways()
  { 
    
    for (int i = 0; i < doorways.Length; i++)
    {
      int randomRoom = Random.Range(0, rooms.Count);
      Instantiate(rooms[randomRoom], doorways[i].transform.localPosition, doorways[i].transform.localRotation);
    }
  }

}
