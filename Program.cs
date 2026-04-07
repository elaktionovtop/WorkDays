/*
Пользователь вводит название месяца, число дней в месяце
и номер дня в недели для 1-го числа месяца (1 - понедельник, 2 - вторник, ..., 7 - воскресенье).
Программа выводит календарь месяца.
*/

using static System.Console;

WriteTitle("Программа...");

while(true)
{
    Action();
    string answer = EnterText("Хотите продолжить? (д/н y/n): ");
    if(answer.ToLower() != "д" && answer.ToLower() != "y")
        break;
    WriteLine();
}

ExitApp();

void Action()
{
    string month = EnterText("Введите название месяца: ");
    int daysNumber = EnterInteger("Введите количество дней в месяце: ");
    int firstWeekDayNumber = EnterInteger("Введите номер дня недели для 1-го числа: ");

    WriteMonth(month, daysNumber, firstWeekDayNumber);

    /*
        int dayNumber = EnterInteger("Введите число месяца (от 1 до 30): ");
        while(dayNumber < 1 || dayNumber > 30)
        {
            Write("Ошибка! ");
            dayNumber = EnterInteger("Введите число месяца (от 1 до 30): ");
        }
        if(dayNumber % 7 == 4 || dayNumber % 7 == 5)
            WriteLine("Это нерабочий день.");
        else
            WriteLine("Это рабочий день.");
    */
}

void WriteMonth(string month, int daysNumber, int firstWeekDayNumber)
{
    WriteLine();
    WriteLine(month.ToUpper());
    WriteLine(" пн. вт. ср. чт. пт. сб. вс.");
    for(int i = 1; i < firstWeekDayNumber; i++)
    {
        Write("    ");
    }
    int weekDayNumber = firstWeekDayNumber;
    for(int day = 1; day <= daysNumber; day++)
    {
        Write($"{day,4}");
        if(weekDayNumber == 7)
        {
            weekDayNumber = 0;
            WriteLine();
        }
        weekDayNumber++;
    }
    WriteLine();
}

void WriteTitle(string title)
{
    WriteLine(title);
    WriteLine(new string('-', title.Length));
    WriteLine();
}

void ExitApp()
{
    WriteLine();
    Write("Для выхода нажми Enter");
    ReadLine();
}

string EnterText(string prompt)
{
    Write(prompt);
    return ReadLine();
}

int EnterInteger(string prompt)
{
    string input = EnterText(prompt);
    bool result = int.TryParse(input, out int number);
    while(!result)
    {
        input = EnterText($"Некорректный ввод. {prompt}");
        result = int.TryParse(input, out number);
    }
    return number;
}

double EnterDouble(string prompt)
{
    string input = EnterText(prompt);
    bool result = double.TryParse(input, out double number);
    while(!result)
    {
        input = EnterText($"Некорректный ввод. {prompt}");
        result = double.TryParse(input, out number);
    }
    return number;
}
