// See https://aka.ms/new-console-template for more information

using ConsoleApp1.Containers;

ContainerShip newShip = new ContainerShip(20, 6, 200);

GasContainer hydrogenContainer = new GasContainer(15, 800, 400, 300, 200);
LiquidContainer waterContainer = new LiquidContainer(false, 400, 100, 100, 250);
RefrigeratedContainer eggsContainer = new RefrigeratedContainer(19, "Eggs", 220, 150, 150, 200);

hydrogenContainer.loadContainer(150);
waterContainer.loadContainer(200);
eggsContainer.loadContainer(170);

newShip.AddContainer(hydrogenContainer);
newShip.AddContainer(waterContainer);
newShip.AddContainer(eggsContainer);

Console.WriteLine(newShip.ToString());