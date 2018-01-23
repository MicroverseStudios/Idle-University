using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public void SpawnStudent()
    {
        Debug.Log("Replace this line with the spawning action.");
        Stats.students++;
        Stats.money += Stats.tuition;
        Stats.incomeHolder += Stats.tuition;
    }

}
