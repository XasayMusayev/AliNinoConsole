
using AliNino.Core.Helper;
using AliNino.Service.Service;

MenuService menuService= new MenuService();

Console.WriteLine("1.Join as admin");
Console.WriteLine("2.Join as user");

string request=Console.ReadLine();

#region AdminUser

if (request=="1")
{
    bool result = await menuService.Login();

    while (!result)
    {
        result = await menuService.Login();

        if (!result)
        {
            HelperColor.PrintLine(ConsoleColor.DarkYellow, "   *_*   Connect as User   *_*   ");
            Console.WriteLine("   2   -     Join as user   ");


            request = Console.ReadLine();
            if (request=="2")
            {
                result = true;
            }

        }




    }
}


if (menuService.IsAdmin)
{
    menuService.ShowMenuAdmin();
}
else
{
    menuService.ShowMenuUser();
}

#endregion