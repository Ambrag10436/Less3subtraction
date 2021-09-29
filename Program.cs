using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;                       // подключаем библиотеку для разбивки текста на строки и вывода по середине, 

namespace Homework_Theme_03
{
    class Program
    {
        /// <summary>
        /// Код который выполняется в первую очередь, начало написания кода 12.09.2021
        /// </summary>
        /// <param name="args">Параметры запуска</param>

        static void Main(string[] args)
        {   
           bool gameLoop = true;                                         //зацикливаем игру, чтобы после завершения можно было продолжить или выйти

                                                                         //Выводим приветствие и правила игры
            string Wellcome = $"Вас приветствует программа TroN \nДавайте поиграем в игру \nПравила очень просты: \nЯ сгенерирую число от 12 до 120, и покажу это число \nИгроки по очереди вводят одно число от 1 до 4 \nЭто число я вычитаю из задуманного, тем самым уменьшая \nПобеждает тот, на чьем ходе задуманное число будет равно 0 \nДля начала игры нажмите клавишу, для выхода закройте приложение";
            string[] lines = Regex.Split(Wellcome, "\r\n|\r|\n");         //разбиваем текст на строики
            int left = 0;                                                   //определяем для каждой строки отступ слева - равен 0
            int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;  //определяем отступ сверху для первой строки - высота экрана делим пополам минус длина текста деленная пополам и все этол минус 1
            int center = Console.WindowWidth / 2;                           //находим центр консоли: делим ширину экрана пополам

            for (int i = 0; i < lines.Length; i++)
            {
                left = center - (lines[i].Length / 2);                      //определяем отступ для текущей строки
                Console.SetCursorPosition(left, top);                       // меняем положение курсора на найденные ранее точки left и top;( где left равна центру минус длина строки деленная пополам)
                Console.WriteLine(lines[i]);                                //выводим строку
                top = Console.CursorTop;
            }
            Console.ReadKey();
            Console.Clear();

            while (gameLoop)                                                    //пока игра зациклена
            {

                Console.WriteLine("Введите количество игроков от 1 до 5");          //вводим количество игроков от 1 до 5
                int userCount = Convert.ToInt32(Console.ReadLine());                //юзер вводит количество игроков, конвертируем это в число
                
                if (userCount ==1)                                                             //если игрок один
	            {   
                    Console.WriteLine($"А Вы смелый игрок! Бросить вызов мне, самому Tron`y");      // ВОТ ЗДЕСЬ ПИШЕМ КОД ДЛЯ ИГРЫ С КОМПОМ
                    Console.WriteLine($"Как Ваше имя?");                                        //вводим имя игрока
                    string userName1 = Console.ReadLine();                                      //
                    string userName2 = "Tron";                                                  // имя компьютера
                    Random rand = new Random();                                                 //генерим число
                    int gameNumber = rand.Next(12, 121);
                    

                    while (gameNumber > 0 )                                     //играем пока задуманное число больше 0
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;          // и выделяем его зеленым цветом
                        Console.WriteLine($"Задуманное число {gameNumber}.");  //другой текст остается белым
                        Console.ForegroundColor = ConsoleColor.White;
                        int userTryNumber = 0;                                 //сначала обнуляем число пользователя
                        while (true)                                           //используем цикл while 
                        {
                            Console.WriteLine($"Ходит {userName1}: ");                                 //ходит игрок
                            bool validInput = int.TryParse(Console.ReadLine(), out userTryNumber);     //введенное значение конвертим в число
                            gameNumber -= userTryNumber;                                               //вычитаем и получаем новый gameNumber
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;          // и выделяем его зеленым цветом
                                Console.WriteLine($"Задуманное число {gameNumber}.");  //другой текст остается белым
                                Console.ForegroundColor = ConsoleColor.White;
                            if (gameNumber == 0)                                          //проверяем если геймнамбер = 0
                            {
                                Console.WriteLine($" Победил игрок {userName1} !");         //то пишем победу игроку
                                                                                            //Конец игры, выход или продолжение
                            Console.WriteLine();
                            Console.WriteLine("Повторим? - нажмите любую кнопку. Для выхода нажмите Esc");
                            if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                            gameLoop = false;
                            }

                            Console.Clear();
                                break;
                            }
                            
                            //победа



                            else if (gameNumber < 0)                                              //если геймнамбер меньше 0
	                        
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Задуманное число меньше 0. Гейм овер");       //то выводим надпись Гейм овер, красим в красный цвет
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();                                                               //предложение повторить игру
                                Console.WriteLine("Повторим? - нажмите любую кнопку. Для выхода нажмите Esc");
                            if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                                gameLoop = false;                                                                // при отказе выключаем игру (отменяем зацикленность)
                            }

                            Console.Clear();                                                                    // очищаем консоль
	                        }
                            if (validInput == false || userTryNumber < 1 || userTryNumber > 4)                   //проверка на корректность ввода числа пользователем
                            {
                                Console.WriteLine($"Ваше число мне не нравится введите другое от 1 до 4");       //если кривое число, просим ввести еще раз
                            } else
	                        {
                            break;
	                        }
                                                               	
                        }
                                                                                                               //ходит ТРОН
                            while (true)
                            {
                                int tronTry = rand.Next(1, 5);                                                 //генерим для трона его tronTry
                                Console.WriteLine($"Ходит {userName2}: ");
                                Console.WriteLine($" {tronTry} ");
                                gameNumber -= tronTry;                                                         //вычитаем и получаем новый геймнамбер
                                break;
                            }
                       if (gameNumber ==0)                                                                     //если геймнамбер = 0
                       {
                            Console.WriteLine($"Tron ПОБЕДИТЕЛЬ! ");                                           //то пишем трон победитель
                       } 
                        else if (gameNumber < 0)                                             //иначе если задуманное число меньше 0
                        {   
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Задуманное число меньше 0. Гейм овер");       //то выводим надпись Гейм овер
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();                                                             //предложение повторить игру
                                Console.WriteLine("Повторим? - нажмите любую кнопку. Для выхода нажмите Esc");
                            if (Console.ReadKey().Key == ConsoleKey.Escape)                                       //если отказ, то отменяем зацикливание, выключаем игру
                            {
                                gameLoop = false;
                            }

                            Console.Clear();
                        }
                      
                    }
                }
                else                                                            // если количество игроков больше 1, то игра между пользователями
	            {
                                    
                    Random rand = new Random();                                  //генерируем число от 12 до 120
                    int gameNumber = rand.Next(12, 121);
                    

	       	
            string[] users = new string[userCount];                             //делаем список игроков
           
            for (int i = 0; i < users.Length; i++)                              //используя цикл, заполняем именами игроков наш созданный список
            {                                                                  //
                while (string.IsNullOrEmpty(users[i]))                          //
                {                                                               //
                    Console.WriteLine($"Введите ник игрока №{i + 1}: ");        //
                    users[i] = Console.ReadLine().Replace(" ", "");             //
                }
            }
                      
            int currentUserIndex = 0;                                   //определяем номер игрока который делает ход    
                                        
                        while (gameNumber > 0 )                                     //играем пока задуманное число больше 0
                        {
                            Console.WriteLine();                                   //выводим задуманное число в консоль 
                            Console.ForegroundColor = ConsoleColor.Green;          // и выделяем его зеленым цветом
                            Console.WriteLine($"Задуманное число {gameNumber}.");  //другой текст остается белым
                            Console.ForegroundColor = ConsoleColor.White;

                            int userTryNumber = 0;                                 //Ход игрока
                            while (true)                                           //пока истина
                            {
                                Console.WriteLine($"Ходит {users[currentUserIndex]}: ");  //выводим в консоль какой игрок ходит

                                bool validInput = int.TryParse(Console.ReadLine(), out userTryNumber);  //проверяем введенное значение
                                if (validInput == false || userTryNumber < 1 || userTryNumber > 4)        //если ввод нерпавильный или число меньше 1 и больше 4
                                {
                                Console.WriteLine($"Ваше число мне не нравится введите другое от 1 до 4");      //то выводим предупреждение
                                }
                                else                                                                               //иначе стоп
                                {
                                break;
                                }

                            }
                            gameNumber -= userTryNumber;                                       //проверяем на окончание игры
                            if (gameNumber == 0 )                                                //если задуманное число равно 0
                            {
                                Console.WriteLine($"Выиграл игрок {users[currentUserIndex]}");      //то выводим надпись выиграл + имя игрока
                            }
                            else if (gameNumber < 0)                                             //иначе если задуманное число меньше 0
                            {   
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Задуманное число меньше 0. Гейм овер");       //то выводим надпись Гейм овер
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            currentUserIndex = ++currentUserIndex % users.Length;


                        }
            
                                            //Конец игры, выход или продолжение
                            Console.WriteLine();
                            Console.WriteLine("Повторим? - нажмите любую кнопку. Для выхода нажмите Esc");
                            if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                            gameLoop = false;
                            }

                            Console.Clear();
                       


            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


                }     
                
        
            }   
        }
    }
}
                                            //Конец написания кода 29.09.2021