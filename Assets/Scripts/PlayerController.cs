using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private NativeEvent endGameEvent;


	private void Die()
    {
        endGameEvent.Invoke();
    }
}
