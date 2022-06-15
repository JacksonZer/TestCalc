using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class resultVar : MonoBehaviour
{
    public InputField SeeVar; // поле вывода на экран записи математической операции 
    public Text M; // поле вывода символа записи числа в переменную
    public double a; // операнд 1
    public double b; // операнд 2
    public double d; // результат математической операции
    public double m; // переменная хранения числа MR
    public string c; // переменная хранения математического оператора
    
    private void Update()
    {   
        // выводит на экран символ М если в память записано число
        if (m != 0) M.text = "M";
        else M.text ="";          
        
        // выводит на экран запись математической операции
        if (a != 0 && b != 0 && d != 0)                         
        {                                                   
            string NumbA = a.ToString();
            string NumbB = b.ToString(); 
            SeeVar.text = NumbA + " " + c + " " + NumbB + " =";
        }
        else if(a != 0)
        {
            string NumbA = a.ToString();
            SeeVar.text = NumbA + " " + c;
        }
        else if(a == 0)
        {
            
            SeeVar.text = " ";
        }        
    }
    
}
