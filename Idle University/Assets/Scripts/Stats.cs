using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Stats : MonoBehaviour {

    public static int students;
    public static int extraStudentsPerSecondChance;
    public static float money;
    public static float income;
    public static float incomeHolder;
    public static float tuition;
    //Text that displays the number of students, current money, and current income (per second).
    public Text sText;
    public Text mText;
    public Text iText;
    private List<float> incomePerSecond;

    void Start()
    {
        students = 0;
        extraStudentsPerSecondChance = 0;
        money = 0;
        income = 0;
        tuition = 10;
        incomePerSecond = new List<float>();
        for (int i = 0; i < 60; i++)
        {
            incomePerSecond.Add(money);
        }
        InvokeRepeating("IncomeCalculate", 0, 0.1f);
        InvokeRepeating("AddStudents", 0, 1f);
    }

    void Update()
    {
        income = (incomePerSecond.Sum())/60;
        sText.text = ""+students;
        if (money % 1 == 0)
        {
            mText.text = "£" + money + ".00";
        } else
        {
            mText.text = "£" + (float)(System.Math.Truncate((double)money * 100.0) / 100.0);
        }
        if (income % 1 == 0)
        {
            iText.text = "£" + income + ".00 /s";
        } else
        {
            iText.text = "£" + (float)(System.Math.Truncate((double)income * 100.0) / 100.0) + " /s";
        }
    }
    
    //Calculates the income per second. 
    void IncomeCalculate()
    {
        incomePerSecond.RemoveAt(0);
        incomePerSecond.Add(incomeHolder);
        incomeHolder = 0;
    }

    //Used by modifiers that result in additional students joining the university.
    void AddStudents()
    {
        System.Random rand = new System.Random();
        if (rand.Next(0,100) < extraStudentsPerSecondChance) {
            students++;
            money += tuition;
            incomeHolder += tuition;
        }
    }

}
