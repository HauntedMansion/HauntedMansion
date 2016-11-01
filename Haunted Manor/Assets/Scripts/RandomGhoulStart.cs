using UnityEngine;
using System.Collections.Generic;

public class RandomGhoulStart : MonoBehaviour
{

  public List<Transform> spawnLocations;
  public Transform ghoulPosition;
  // Use this for initialization
  void Start()
  {
    int randomLocation = Random.Range(0, spawnLocations.Count);
    ghoulPosition.position = spawnLocations[randomLocation].position;
  }
}
