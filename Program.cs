/*
Пользователь вводит число месяца (апрель 2026).
Программа проверяет число и выводит: рабочий или нерабочий это день.
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
