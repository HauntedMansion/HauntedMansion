using UnityEngine;
using System.Collections.Generic;

public class RandomRoomGenerator : MonoBehaviour {

  public GameObject emptyRoom;

  GameObject[] doorways;

	void Start ()
  {
    doorways = GameObject.FindGameObjectsWithTag("Doorway");
    AddRoomsOnDoorways();
	}
  void AddRoomsOnDoorways()
  {
    for(int i = 0; i < doorways.Length; i++)
    {
      Instantiate(emptyRoom, doorways[i].transform.localPosition, doorways[i].transform.localRotation);
    }
  }

}
