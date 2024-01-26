using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject bullet;

    [SerializeField]
    private GameObject _bullet;



    private void Awake()
    {
        bullet = _bullet;
    }

}
