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
    public void ButtonMP() // прибавляет число на экране к пременной rVar.m(M - память калькулятора), по умолчанию 0, при нажатие кнопки М+
    {   
        rVar.m = rVar.m + double.Parse(InNumb.text);
    }

    public void ButtonMM() // вычитает число на экране от пременной rVar.m(M - память калькулятора), по умолчанию 0, при нажатие кнопки М-
    {   
        rVar.m = rVar.m - double.Parse(InNumb.text);
    }

    public void ButtonMR() // выводт число из переменной rVar.m (M - паиять калькулятора) на экран при нажатии на кнопку MR
    {   
        InNumb.text = rVar.m.ToString();
    }

    public void ButtonMC() // присваевает переменной rVar.m (М - память калькулятора) значение 0 (очещает память калькулятора) при нажатии на кнопку MC
    {   
        rVar.m *= 0;
    }

 
    public void ButtonRavno() //принажатии на кнопку равно (=)
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
    
       
    public void ButtonPlusMinus() // при нажатии на кнопку плюс-минус(+/-). Меняет знак числа на противоположный
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
      
    public void ButtonVKvadrate() // при нажатии на кнопку возвести в квадрат (x^2). Возводит число на эекране в квадрат
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
        
    public void ButtonDel1NaX() // при нажатии на кнопку деление еденицы на число(1/x). Производить деление еденицы на число на экране
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
        
    public void ButtonKvadratKoren() // при нажатии на кнопку квадратного корня (√). вычесляет квадранный корень числа на экране
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
        
    public void ButtonPercent() // при нажатии на кнопку процент(%). вычесляет процент из числа на экране
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
        
    public void ButtonDel() // при нажатии на кнопку Del. Удалет последнюю цифру из числа на экране(Backspace)
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
        
    public void ButtonCE() // при нажатии на кнопку CE. Присваевает переменной rVar.d значение 0, и выводит 0 на экран.(Очистка экрана)
    {   
        rVar.d = 0;
        InNumb.text = "0";
    }
        
    public void ButtonC() // при нажатии на кнопку C. Присваевает переменным rVar.a rVar.b rVar.d значение 0, и выводит 0 на экран.(Очищает экран и удаляет операнды)
    {   
        rVar.a = 0;
        rVar.b = 0;
        rVar.d = 0;
        rVar.c = "";
        InNumb.text = "0";
    }   

    public void ButtonDot() //при нажатие на кнопку точка(,). Ставить точку в числе если её еще нет
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
    


    

    public void NumButtons() // при нажатие на кнопки 1 2 3 4 5 6 7 8 9 0
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

    public void ActionButtons () // при нажатии на кнопки + - * /
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

    public void Exit() // закрыть приложение
    {
        Application.Quit();    
    } 
}
