using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HorrorGame;

namespace HorrorGame
{
    public class Door : MonoBehaviour
    {
        public DoorState _state;

        public GameObject closedDoor;
        public GameObject openedDoor;

        // Start is called before the first frame update
        void Start()
        {
            _state = DoorState.CLOSED;
            updateStateSprite();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setState(DoorState state)
        {
            _state = state;
            updateStateSprite();
        }

        private void updateStateSprite()
        {
            switch (_state)
            {
                case DoorState.OPENED:
                    {
                        closedDoor.SetActive(false);
                        openedDoor.SetActive(true);
                    }
                    break;
                case DoorState.CLOSED:
                    {
                        closedDoor.SetActive(true);
                        openedDoor.SetActive(false);
                    }
                    break;
            }
        }
    }

}
