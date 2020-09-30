using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Player[] PlayerList;
    int PlayerSelected;
    // Start is called before the first frame update
    void Start()
    {
        PlayerList = GetComponentsInChildren<Player>(); //Makes a list of the children under this controller. Supports any number of players

        PlayerSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Big thanks to the NavMesh lecture for this te c h   s k i l l
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)){
                    PlayerList[PlayerSelected].MoveToLocation(hit.point); //Tells the currently selected player to move to where you clicked
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            PlayerSelected = (PlayerSelected + 1) % PlayerList.Length; //cycles between players when you press space
        }
    }
}
