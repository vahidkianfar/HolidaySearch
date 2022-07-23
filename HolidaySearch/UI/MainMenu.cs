using Spectre.Console;

namespace HolidaySearch.UI;

public class MainMenu
{
    public static void Start()
    {
        AnsiConsole.Progress()
            .Start(ctx => 
            {
                var task1 = ctx.AddTask("[blue]Loading[/]");
                while(!ctx.IsFinished)
                    task1.Increment(0.00007);
            });
        while (true)
        {
            Console.Clear();
            var selectInstructionOption =
                ConsoleHelper.MultipleChoice(true, "1. Search", "2. Exit");
            switch (selectInstructionOption)
            {
                case 0:
                    SearchMenu.Start();
                    break;
                
                case 1:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}