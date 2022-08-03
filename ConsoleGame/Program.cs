// See https://aka.ms/new-console-template for more information


var resp = 0;
do
{
    new ConsoleGame.Engine.ConsoleGame().Run();
    Console.WriteLine("Quer tentar novamente? (1 - Sim, Outro - Não)");
    resp = Convert.ToInt32(Console.ReadLine());
} while (resp == 1);
