using hw8;
using std;


namespace Tumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Song mySong = new Song();
            Task4();
        }

        /*Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
         методы заполнения полей.Вместо этих методов создать конструкторы. Переопределить
         конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
         для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
         банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
         счета.*/
        static void Task1()
        {
            Console.WriteLine("\nСоздание и отображение информации о банковском счете\n");
            List<BankAccount> accounts = new List<BankAccount>()
            {
                new BankAccount(10000),
                new BankAccount(5000, AccType.debit),
                new BankAccount(AccType.debit)
            };
            foreach (BankAccount account in accounts)
            {
                account.PrintAccountInfo();
            }
        }
        /*Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
        о всех банковских операциях.При изменении баланса счета создается новый объект класса
        BankTransaction, который содержит текущую дату и время, добавленную или снятую со
        счета сумму.Поля класса должны быть только для чтения(readonly). Конструктору класса
        передается один параметр – сумма.В классе банковский счет добавить закрытое поле типа
        System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
        данного банковского счета; изменить методы снятия со счета и добавления на счет так,
        переменную типа System.Collections.Queue.*/
        static void Task2()
        {
            Console.WriteLine("Создать класс BankTransaction");
            List<BankAccount> accounts = new List<BankAccount>()
            {
                new BankAccount(10000),
                new BankAccount(5000, AccType.debit),
                new BankAccount(50000, AccType.debit)
            };
            foreach (BankAccount account in accounts)
            {
                account.Deposit(1000);
                account.WithdrawCash(500);
                account.PrintAccountInfo();
            }

        }

        /*Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
        проводках из очереди запишет в файл.Не забудьте внутри метода Dispose вызвать метод
        GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
        завершения для указанного объекта.*/
        static void Task3()
        {
            Console.WriteLine("В классе банковский счет создать метод Dispose");
            using (BankAccount account = new BankAccount(AccType.debit))
            {
                account.Deposit(10000);
                account.WithdrawCash(5000);
                account.PrintAccountInfo();
                account.Dispose();
            }
        }
        /*Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие
        конструкторы:
        1) параметры конструктора – название и автор песни, указатель на предыдущую песню
        инициализировать null.
        2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main
        создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
        следующим образом: Song mySong = new Song(); ?
        Исправьте ошибку, создав необходимый конструктор.*/
        static void Task4()
        {
            Console.WriteLine("Добавление конструкторов в класс Song (из домашнего задания 8.2)");
            List<Song> songs = new List<Song>
            {
                new Song ( "Last Christmas", "Wham!" ),
                new Song ( "Зоопарк", "Егор Летов" ),
                new Song ( "DINAMITE", "TENTON" )
            };

            songs.Add(new Song("Duncan", "U-TOPIA", songs[1]));

            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].SetPrev(songs[i - 1]);
            }

            foreach (Song song in songs)
            {
                Console.WriteLine(song.Title());
            }

            if (songs[1].Equals(songs[0].prev))
            {
                Console.WriteLine("Первая и вторая песни одинаковые.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песни разные.");
            }
        }
    }
}
