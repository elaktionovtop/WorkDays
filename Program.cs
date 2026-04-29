/*
Пользователь вводит название месяца, число дней в месяце
и номер дня в недели для 1-го числа месяца (1 - понедельник, 2 - вторник, ..., 7 - воскресенье).
Номер дня недели проверяется.
Программа выводит календарь месяца.

Пользователь вводит число месяца,
программа выводит название дня недели для этого числа,
разные дни недели выделяются разными цветами:
понедельник - черным, 
вторник, среда, четверг - синим, 
пятница - зеленым, 
суббота, воскресенье - красным.
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
    while(firstWeekDayNumber < 1 || firstWeekDayNumber > 7)
    {
        Write("Ошибка! ");
        firstWeekDayNumber = EnterInteger("Введите номер дня недели для 1-го числа: ");
    }

    WriteMonth(month, daysNumber, firstWeekDayNumber);

    int dayNumber = EnterInteger("Введите число месяца (от 1 до {daysNumber}): ");
    while(dayNumber < 1 || dayNumber > daysNumber)
    {
        Write("Ошибка! ");
        dayNumber = EnterInteger($"Введите число месяца (от 1 до {daysNumber}): ");
    }
    WriteDayOfWeek(month, dayNumber, firstWeekDayNumber);
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

    for(int day = 1, i = firstWeekDayNumber; day <= daysNumber; day++, i++)
    {
        Write($"{day,4}");
        if(i % 7 == 0)
        {
            WriteLine();
        }
    }
    WriteLine();
}

void WriteDayOfWeek(string month, int dayNumber, int firstWeekDayNumber)
{
    string[] weekDays = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница",
        "Суббота", "Воскресенье" };

    int weekDayNumber = (dayNumber + firstWeekDayNumber - 2) % 7;

    switch(weekDayNumber)
    {
        case 0:
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            break;
        case 1:
        case 2:
        case 3:
            ForegroundColor = ConsoleColor.Blue;
            break;
        case 4:
            ForegroundColor = ConsoleColor.Green;
            break;
        case 5:
        case 6:
            ForegroundColor = ConsoleColor.Red;
            break;
    }
    WriteLine($"{month}, {dayNumber}: {weekDays[weekDayNumber]}");
    ResetColor();
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
