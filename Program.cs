namespace AnnLesson3
{
    internal class Program
    {
        static int masLenght = 5;
        static double[] mas = new double[masLenght];
        static int masCount = 0;
        static int errCount = 0;
        static bool isContinue = true;                                     //пока true - продолжаем читать данные

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            do
            {
                string str = Console.ReadLine();                
                if (str.Equals("Q"))                                    //при нажатии на Q                     
                {
                    PrintMas();                                         //выводим массив
                    GetUserAction();                                    //получаем от пользователя дальнейшие инструкции
                }
                else
                {
                    try
                    {
                        double correctInput = double.Parse(str);        //если введено число        
                        mas[masCount] = correctInput;                   //записали число в массив
                        masCount++;                                     //увеличили размер массива
                        if (masCount == masLenght)                      //если дошли до конца массива
                        {
                            DoubleMas();                                //увеличили массив
                        }
                    }
                    catch
                    {
                        ErrorProceed();                                 //обработка ошибки
                    }
                }                
            }
            while (isContinue);
            PrintMasInfo();                                             //при получении инструкции Выйти выводим информацию о размере массива и количестве ошибок
            Console.ReadKey();
        }

        static void PrintWelcomeMessage()                               //печать сообщения - приглашения на ввод чисел
        {
            Console.WriteLine("Введите числа, 'Q' - окончание ввода.");
        }

        static void ErrorProceed()                                      //обработка ошибки ввода
        {
            errCount++;                                                 //увеличиваем счетчик ошибок
            Console.WriteLine("Обнаружена ошибка ввода.");            
            GetUserAction();                                            //получаем от пользователя дальнейшие инструкции
        }
                
        static void GetUserAction()                                     //получение от пользователя дальнейших инструкций
        {
            bool isGotAction = false;
            do
            {
                Console.WriteLine("Выберите одно из следующих действий: Очистить (О), Продолжить (П), Выйти (В).");
                try
                {
                    int userAction = char.Parse(Console.ReadLine());
                    switch (userAction)
                    {
                        case 'О': ClearMas(); break;                                        //очистка массива и за дальнейшими инструкциями
                        case 'П': isGotAction = true; PrintWelcomeMessage(); break;         //получена инструкция от пользователя: возвращаемся к вводу
                        case 'В': isGotAction = true; isContinue = false; break;            //получена инструкция от пользователя: завершить работу программы                            
                    }                    
                }
                catch { }                                                                   //ошибку игнирируем и возвращаем к меню  
            }
            while (!isGotAction);
        }

        static void ClearMas()              //очистка массива
        {
            mas = new double[masLenght];    //очищаем переопределением (в принципе при наличии счетчика можно не очищать массив, но пусть будет)
            masCount = 0;                   //при очистке массива сбрасываем счетчик
            errCount = 0;                   //и ошибки            
        }

        static void DoubleMas()             //увеличиваем размер массива
        {
            double[] masTemp = new double[masLenght];
            for (int i = 0; i < masCount; i++)
                masTemp[i] = mas[i];            //скопировали старый массив во временный
            masLenght *= 2;
            mas = new double[masLenght];
            for (int i = 0; i < masCount; i++)
                mas[i] = masTemp[i];            //восстановили собранную половину увеличенного массива
        }

        static void PrintMas()              //печать массива
        {
            string printMas = "Введенные числа: ";
            for (int i = 0; i < masCount; i++)
                printMas += $"{mas[i]} ";
            Console.WriteLine(printMas);
        }

        static void PrintMasInfo()          //печать информации о количестве элемеентов в массиве и количестве ошибок
        {
            Console.WriteLine($"Количество элементов массива: {masCount}, количество ошибок при вводе: {errCount}.");
        }
    }
}