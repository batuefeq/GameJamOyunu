using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject bullet, enemy;



    [SerializeField]
    private GameObject _bullet, _enemy;



    private void Awake()
    {
        bullet = _bullet;
        enemy = _enemy;
    }

}
