using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Calc : MonoBehaviour, IPointerDownHandler
{   
    
    public InputField InNumb; //поле для вывода чисел. InNumb.text - текст вывода
    public string CalcButton; // переменная символа нажатой клавиши
    private resultVar rVar; // доступ к переменным из скрипта resultVar
    
    public void Start()
    {
        rVar = GameObject.FindGameObjectWithTag("Finish").GetComponent<resultVar>(); // подключаем переменную к скрипту при помощи тега Finish
        InNumb.text = "0";  // при старте на экран будет выведен 0

    }

    public virtual void OnPointerDown(PointerEventData eventData) // считывает нажатие кнопки
    {    
        if (rVar.d != 0 ) // проверяем есть ли в переменной rVar.d (результат математической операции) какое нибудь значение, если да очешаем переменные операндов rVar.a и rVar.b и выводим занчение rVar.d на экран
        {    
            rVar.a = 0;
            rVar.b = 0;
            InNumb.text = rVar.d.ToString();                               
        }
    }
    public void BMP() // функция работы с запоминаем чисел и операций над ней
    {   
        rVar.m = rVar.m + double.Parse(InNumb.text);
    }

    public void BMM() // функция работы с запоминаем чисел и операций над ней
    {   
        rVar.m = rVar.m - double.Parse(InNumb.text);
    }

    public void BMR() // функция работы с запоминаем чисел и операций над ней
    {   
        InNumb.text = rVar.m.ToString();
    }

    public void BMC() // функция работы с запоминаем чисел и операций над ней
    {   
        rVar.m *= 0;
    }

 
    public void BQuals() //кнопка равно
    {   
        
        if (rVar.a != 0)
        {
            rVar.b = double.Parse(InNumb.text);
            result();
        }
        
        else if (rVar.a == 0)
        {
            rVar.d = 0;
            InNumb.text = "0";
        }
    }    
    
       
    public void BPlusMinus() // кнопка +-
    {   
        if (rVar.d != 0)
        {       
            rVar.d *= -1;
            InNumb.text = rVar.d.ToString();
        }
            
        else
        {
            double VarOne = double.Parse(InNumb.text);
            VarOne *= -1;
            InNumb.text = VarOne.ToString();
        }
    }
      
    public void BSquare() // кнопка возведения в квадрат
    {
        
        double VarOne = double.Parse(InNumb.text);
        VarOne *= VarOne;
        InNumb.text = VarOne.ToString();
        rVar.d = double.Parse(InNumb.text);
        if (rVar.a != 0)
        {
            rVar.b = double.Parse(InNumb.text);
            result();
        }
    }
        
    public void B1Divide() // кнопка деления еденицы на число
    {
        
        double VarOne = double.Parse(InNumb.text);
        double VarTwo = 1/VarOne;
        InNumb.text = VarTwo.ToString();
        rVar.d = double.Parse(InNumb.text);
        if (rVar.a != 0)
        {
            rVar.b = double.Parse(InNumb.text);
            result();
        }
    }
        
    public void BSquareRoot() // кнопка квадратного корня
    {   
        
        float VarOne = float.Parse(InNumb.text);
        double VarTwo = Mathf.Sqrt(VarOne);
        InNumb.text = VarTwo.ToString();
        rVar.d = double.Parse(InNumb.text);
        if (rVar.a != 0)
        {
            rVar.b = double.Parse(InNumb.text);
            result();
        }
    }
        
    public void BPercent() // кнопка процентов
    {
        
        double VarOne = double.Parse(InNumb.text);
        VarOne /= 100;
        InNumb.text = VarOne.ToString();
        rVar.d = double.Parse(InNumb.text);
        if (rVar.a != 0)
        {
            rVar.b = double.Parse(InNumb.text);
            result();
        }            
    }
        
    public void BDel() // кнопка удаления последней цифры 
    {
        if (rVar.d != 0)
        {   
            string stD = rVar.d.ToString();
            int LeD = stD.Length;
            if (LeD == 1)
            {
                rVar.d = 0;
                InNumb.text = rVar.d.ToString();

            }
                
            else
            {
                string strD = rVar.d.ToString();
                int LenD = strD.Length;
                strD = strD.Remove(LenD -1,1);
                rVar.d = double.Parse(strD);
                InNumb.text = rVar.d.ToString();
            }
        }
            
        else
        {
            int Len = InNumb.text.Length;
            InNumb.text = InNumb.text.Remove(Len -1,1);
        }

        if (InNumb.text == "") InNumb.text = "0";
    }
        
    public void BCE() // кнопка удаления числа на экране
    {   
        rVar.d = 0;
        InNumb.text = "0";
    }
        
    public void BC() // кнопка очистки экрана и операндов
    {   
        rVar.a = 0;
        rVar.b = 0;
        rVar.d = 0;
        rVar.c = "";
        InNumb.text = "0";
    }   

    public void Dot()
    {
        string s = ",";
        bool b = InNumb.text.Contains(s); // проверяет есть ли запятая в числе
        if (b == true && CalcButton == ",") // если в числе уже есть запятае и была нажата кнопка запятая, ждет ввода другой кнопки
        {

        }
        else // в иных случаях добавляет число к цифре на экране
        {
            InNumb.text += CalcButton;                    
        }
    }   
    


    

    public void ClNum() // функция введения цифр
    {   
        
        int Leng = InNumb.text.Length; // измеряет длину строки
        if (Leng < 12)
        {       
            if (InNumb.text == "0") // если число на экране 0, тогда удаляет его в выводит значение нажатой кнопки
            {
                InNumb.text = "";
                InNumb.text += CalcButton;
            }
            
            else if (InNumb.text != "0" && rVar.d != 0)  // если число на экране не равно 0 и результат матем. операций (rVar.d) не равно 0, тогда удаляет число на экране, выводит значение нажатой кнопки и переменной rVar.d присваевает значение 0
            {
                InNumb.text = "";
                InNumb.text += CalcButton;
                rVar.d = 0;
            }
            
            else // в иных случаях добавляет число к цифре на экране
            {
                InNumb.text += CalcButton;                    
            }
        }                               
    }

    public void ClAction () // функция записи операторов и операндов в переменные
    {   

        
        rVar.c = CalcButton;
        if (rVar.a == 0)
        {
            rVar.a = double.Parse(InNumb.text);
            rVar.d = 0;
            InNumb.text = "";
        }
        
        else if(rVar.a != 0)
        {
            rVar.b = double.Parse(InNumb.text);
            result();
        } 
        
        else
        {   
            rVar.b = double.Parse(InNumb.text);          
            result();
        }    
    }

    void result() // производит математические операции
    {   
        switch(rVar.c)
        {
            case "+":
                rVar.d = rVar.a + rVar.b;
                break;
            case "-":
                rVar.d = rVar.a - rVar.b;
                break;
            case "*":
                rVar.d = rVar.a * rVar.b;
                break;
            case "/":
                rVar.d = rVar.a / rVar.b;
                break;
        }

        InNumb.text = rVar.d.ToString(); // выводит результат на экран   
    }   

    public void Exit()
    {
        Application.Quit();    // закрыть приложение
    } 
}
