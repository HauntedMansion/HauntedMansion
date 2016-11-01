using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GhoulController : MonoBehaviour
{
  int health;
  public GameObject player;
  public int slowDist;
  public float moveSpeed;
  public float slowSpeed;
  public float teleportAfterShot = 10;
  public GameObject gameOverCamera;
  public GameObject gameText;

  private GameObject[] rooms;  

  private float surpriseDist = 6;
  private float surpriseSpeed = 5;
  private float slowDown = 2;

  private bool pursuing;
  private bool sprint;

  // Use this for initialization
  void Start()
  {
    health = 200;
    pursuing = true;

    rooms = GameObject.FindGameObjectsWithTag("RoomSpawn");

  }

  // Update is called once per frame
  void Update()
  {
    if (health <= 0)
    {
      Destroy(this.gameObject);
      gameText.GetComponent<Text>().text = "Mission Accomplished";
    }
    if (player != null)
    {
      transform.LookAt(player.transform);

      if (pursuing && !sprint)
      {
        if (Vector3.Distance(transform.position, player.transform.position) <= slowDist)
        {
          transform.position += transform.forward * slowSpeed * Time.deltaTime;
        }
        else
        {
          transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
      }
      else if (pursuing && sprint)
      {
        if (Vector3.Distance(transform.position, player.transform.position) <= surpriseDist && Vector3.Distance(transform.position, player.transform.position) > slowDown)
        {
          transform.position += transform.forward * surpriseSpeed * Time.deltaTime;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= slowDown)
        {
          sprint = false;
        }
      }

      if (!pursuing)
      {
        if (Vector3.Distance(transform.position, player.transform.position) <= surpriseDist)
        {
          pursuing = true;
          sprint = true;
        }
      }
    }
  }


  public void takeDamage(int damage)
  {
    health -= damage;
  }

  public int returnHealth()
  {
    return health;
  }
  void LoadMenu()
  {
    SceneManager.LoadScene("Menu");
  }

  void OnTriggerEnter(Collider other)
  {
      if (other.tag == "Player")
      {
      GetComponent<Animator>().SetTrigger("isAttacking");
      FirstPersonController controller = other.GetComponentInChildren<FirstPersonController>();
        controller.GetMouseLook().SetCursorLock(false);

        gameText.SetActive(true);
        gameText.GetComponent<Text>().text = "You are Dead";
        Camera playerCam = other.GetComponentInChildren<Camera>();
        gameOverCamera.GetComponent<Camera>().transform.position = playerCam.transform.position;
        gameOverCamera.GetComponent<Camera>().transform.rotation = playerCam.transform.rotation;
        gameOverCamera.SetActive(true);
        Destroy(other.gameObject);
        Invoke("LoadMenu", 4);

      }
      if (other.tag == "Bullet")
      {

        if (Random.value <= 0.25f)
        {
          pursuing = false;
          spawnRoom();
        }
        else
        {
          randomTeleport();
          randomTeleport();
          randomTeleport();
        }

        sprint = false;
      }
    
  }

  void randomTeleport()
  {
    float direction = Random.value;

    if (direction <= 0.25f)
      transform.position -= transform.forward * teleportAfterShot;
    else if (direction > 0.25f && direction <= 0.5f)
      transform.position = transform.forward * teleportAfterShot;
    else if (direction > 0.5f && direction <= 0.75f)
      transform.position = transform.right * teleportAfterShot;
    else if (direction > 0.75f && direction <= 1f)
      transform.position -= transform.right * teleportAfterShot;

  }

  void spawnRoom()
  {
    transform.position = rooms[Random.Range(0, rooms.Length)].transform.position;

    if (Random.value < 0.51f)
      transform.position += transform.right * 2;
    else
      transform.position -= transform.right * 2;
  }
}
