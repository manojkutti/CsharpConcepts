# CsharpConcepts

**DESIGN PATTERNS**

**Factory Method Design Pattern:**
* Factory method is a design pattern which defines an interface for creating an object but let the classes that implement the interface decide which class to instantiate.

**UML Diagram**

The UML class diagram for the implementation of the factory design pattern is given below:

![FactoryUml](https://user-images.githubusercontent.com/39005871/79754610-6dfca280-8335-11ea-8349-038c3273920b.jpeg)


1.  Product: It defines the interface of objects the factory method creates.
2.  ConcreteProduct: This is a class that implements the Product interface. 
3.  Creator: This is an abstract class & declares the factory method, which returns an object of the type Product. 
4.  ConcreteCreator: This is a class that implements the Creator class & overrides the factory method to return an instance of ConcreteProduct.

**Factory Pattern Example**

Assume you have three different cards which are considered here as classes MoneyBack, Titanium and Platinum, all of them implement abstract class CreditCard. You need to instantiate one of these classes, but you don't know which of them, it depends on the user. This is a perfect scenario for the Factory Method design pattern.

![FactoryExample](https://user-images.githubusercontent.com/39005871/79754633-794fce00-8335-11ea-877c-ffb87b9e57f4.jpeg)

The classes, interfaces, and objects in the above class diagram can be identified as

**Product** - CreditCard\
**ConcreteProduct**- MoneyBackCreditCard, TitaniumCreditCard, PlatinumCreditCard\
**Creator**- CardFactory\
**ConcreteCreator**- MoneyBackCardFactory, TitaniumCardFactory, PlatinumCardFactory

**Here are the code blocks of each participant:**

**1.Product**

```csharp
       abstract class CreditCard  
    {  
        public abstract string CardType { get; }  
        public abstract int CreditLimit { get; set; }  
        public abstract int AnnualCharge { get; set; }  
    }      
```
**2.ConcreteProduct**

MoneyBackCreditCard
```csharp
using System;  
      class MoneyBackCreditCard : CreditCard  
    {  
        private readonly string _cardType;  
        private int _creditLimit;  
        private int _annualCharge;  
  
        public MoneyBackCreditCard(int creditLimit, int annualCharge)  
        {  
            _cardType = "MoneyBack";  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
  
        public override string CardType  
        {  
            get { return _cardType; }  
        }  
  
        public override int CreditLimit  
        {  
            get { return _creditLimit; }  
            set { _creditLimit = value; }  
        }  
  
        public override int AnnualCharge  
        {  
            get { return _annualCharge; }  
            set { _annualCharge = value; }  
        }  
    }    
```
TitaniumCreditCard
```csharp
using System;  
  
    class TitaniumCreditCard : CreditCard  
    {  
        private readonly string _cardType;  
        private int _creditLimit;  
        private int _annualCharge;  
  
        public TitaniumCreditCard(int creditLimit, int annualCharge)  
        {  
            _cardType = "Titanium";  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
  
        public override string CardType  
        {  
            get { return _cardType; }  
        }  
  
        public override int CreditLimit  
        {  
            get { return _creditLimit; }  
            set { _creditLimit = value; }  
        }  
  
        public override int AnnualCharge  
        {  
            get { return _annualCharge; }  
            set { _annualCharge = value; }  
        }      
    }  
```
PlatinumCreditCard
```csharp
using System;  
  
    class PlatinumCreditCard : CreditCard  
    {  
        private readonly string _cardType;  
        private int _creditLimit;  
        private int _annualCharge;  
  
        public PlatinumCreditCard(int creditLimit, int annualCharge)  
        {  
            _cardType = "Platinum";  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
  
        public override string CardType  
        {  
            get { return _cardType; }  
        }  
  
        public override int CreditLimit  
        {  
            get { return _creditLimit; }  
            set { _creditLimit = value; }  
        }  
  
        public override int AnnualCharge  
        {  
            get { return _annualCharge; }  
            set { _annualCharge = value; }  
        }  
    }   
```
**3.Creator**
```csharp
    abstract class CardFactory  
    {  
        public abstract CreditCard GetCreditCard();  
    }   
```
**4.ConcreteCreator**

MoneyBackFactory
```csharp
    class MoneyBackFactory : CardFactory  
    {  
        private int _creditLimit;  
        private int _annualCharge;  
  
        public MoneyBackFactory(int creditLimit, int annualCharge)  
        {  
            _creditLimit = creditLimit;  
            _annualCharge = annualCharge;  
        }  
  
        public override CreditCard GetCreditCard()  
        {  
            return new MoneyBackCreditCard(_creditLimit, _annualCharge);  
        }  
    }    
```
TitaniumFactory:
```csharp
    class TitaniumFactory: CardFactory      
    {      
        private int _creditLimit;      
        private int _annualCharge;      
      
        public TitaniumFactory(int creditLimit, int annualCharge)      
        {      
            _creditLimit = creditLimit;      
            _annualCharge = annualCharge;      
        }      
      
        public override CreditCard GetCreditCard()      
        {      
            return new TitaniumCreditCard(_creditLimit, _annualCharge);      
        }      
    }          
```
PlatinumFactory:
```csharp
    class PlatinumFactory: CardFactory      
    {      
        private int _creditLimit;      
        private int _annualCharge;      
      
        public PlatinumFactory(int creditLimit, int annualCharge)      
        {      
            _creditLimit = creditLimit;      
            _annualCharge = annualCharge;      
        }      
      
        public override CreditCard GetCreditCard()      
        {      
            return new PlatinumCreditCard(_creditLimit, _annualCharge);      
        }      
    }        
```
**Factory Pattern Client Demo**
```csharp
using System;  
  
    public class ClientApplication  
    {  
        static void Main()  
        {  
            CardFactory factory = null;  
            Console.Write("Enter the card type you would like to visit: ");  
            string card = Console.ReadLine();  
  
            switch (card.ToLower())  
            {  
                case "moneyback":  
                    factory = new MoneyBackFactory(50000, 0);  
                    break;  
                case "titanium":  
                    factory = new TitaniumFactory(100000, 500);  
                    break;  
                case "platinum":  
                    factory = new PlatinumFactory(500000, 1000);  
                    break;  
                default:  
                    break;  
            }  
  
            CreditCard creditCard = factory.GetCreditCard();  
            Console.WriteLine("\nYour card details are below : \n");  
            Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",  
                creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);  
              
        }  
    }     
```



**A working Prototype of the code is available in the following link**
https://github.com/EzDevPrac/CSharp-Tereena/tree/master/FactoryDesign


**Builder Pattern:**
* It is a creational design pattern, which allows constructing complex objects step by step. 
* Builder patterns makes it possible to produce different products or representations using the same construction process. 

**UML Diagram**

The UML class diagram for the implementation of the builder design pattern is given below:

![BuilderUml](https://user-images.githubusercontent.com/39005871/79754667-85d42680-8335-11ea-85b5-bb0596a31c89.jpeg)

1.  Builder: This is an interface which is used to define all the steps to create a product. 
2.  ConcreteBuilder: This is a class which implements the Builder interface to create a complex product. 
3.  Product: This is a class which defines the parts of the complex object which are generated by the builder pattern. 
4.  Director: This is a class which is used to construct an object using the builder interface.

**Builder Pattern Example**

![BuilderExample](https://user-images.githubusercontent.com/39005871/79754701-95536f80-8335-11ea-8c0d-7a55b5c9e14b.jpeg)


The classes, interfaces, and objects in the above class diagram can be identified as follows:

**IVehicleBuilder** - Builder interface\
**HeroBuilder & HondaBuilder**- Concrete Builder\
**Vehicle**- Product\
**Vehicle Creator** - Director

**Here are the code blocks of each participant:**

**1.Builder**
```csharp
public interface IVehicleBuilder
{
 void SetModel();
 void SetEngine();
 void SetTransmission();
 void SetBody();
 void SetAccessories();

 Vehicle GetVehicle();
}
```
**2.ConcreteBuilder**

HeroBuilder
```csharp
public class HeroBuilder : IVehicleBuilder
{
 Vehicle objVehicle = new Vehicle();
 public void SetModel()
 {
 objVehicle.Model = "Hero";
 }

 public void SetEngine()
 {
 objVehicle.Engine = "4 Stroke";
 }

 public void SetTransmission()
 {
 objVehicle.Transmission = "120 km/hr";
 }

 public void SetBody()
 {
 objVehicle.Body = "Plastic";
 }

 public void SetAccessories()
 {
 objVehicle.Accessories.Add("Seat Cover");
 objVehicle.Accessories.Add("Rear Mirror");
 }

 public Vehicle GetVehicle()
 {
 return objVehicle;
 }
}
```
HondaBuilder
```csharp
public class HondaBuilder : IVehicleBuilder
{
 Vehicle objVehicle = new Vehicle();
 public void SetModel()
 {
 objVehicle.Model = "Honda";
 }

 public void SetEngine()
 {
 objVehicle.Engine = "4 Stroke";
 }

 public void SetTransmission()
 {
 objVehicle.Transmission = "125 Km/hr";
 }

 public void SetBody()
 {
 objVehicle.Body = "Plastic";
 }

 public void SetAccessories()
 {
 objVehicle.Accessories.Add("Seat Cover");
 objVehicle.Accessories.Add("Rear Mirror");
 objVehicle.Accessories.Add("Helmet");
 }

 public Vehicle GetVehicle()
 {
 return objVehicle;
 }
}
```
**3.Product**
```csharp
public class Vehicle
{
 public string Model { get; set; }
 public string Engine { get; set; }
 public string Transmission { get; set; }
 public string Body { get; set; }
 public List<string> Accessories { get; set; }

 public Vehicle()
 {
 Accessories = new List<string>();
 }

 public void ShowInfo()
 {
 Console.WriteLine("Model: {0}", Model);
 Console.WriteLine("Engine: {0}", Engine);
 Console.WriteLine("Body: {0}", Body);
 Console.WriteLine("Transmission: {0}", Transmission);
 Console.WriteLine("Accessories:");
 foreach (var accessory in Accessories)
 {
 Console.WriteLine("\t{0}", accessory);
 }
 }
}
```
**4.Director**
```csharp
public class VehicleCreator
{
 private readonly IVehicleBuilder objBuilder;

 public VehicleCreator(IVehicleBuilder builder)
 {
 objBuilder = builder;
 }

 public void CreateVehicle()
 {
 objBuilder.SetModel();
 objBuilder.SetEngine();
 objBuilder.SetBody();
 objBuilder.SetTransmission();
 objBuilder.SetAccessories();
 }

 public Vehicle GetVehicle()
 {
 return objBuilder.GetVehicle();
 }
}
```

**Builder Design Pattern Demo**
```csharp
class Program
{
 static void Main(string[] args)
 {
 var vehicleCreator = new VehicleCreator(new HeroBuilder());
 vehicleCreator.CreateVehicle();
 var vehicle = vehicleCreator.GetVehicle();
 vehicle.ShowInfo();

 Console.WriteLine("---------------------------------------------");

 vehicleCreator = new VehicleCreator(new HondaBuilder());
 vehicleCreator.CreateVehicle();
 vehicle = vehicleCreator.GetVehicle();
 vehicle.ShowInfo();

 
 }
}
```



**A working Prototype of the code is available in the following link**
https://github.com/EzDevPrac/CSharp-Tereena/tree/master/BuilderDesign


**Command Design Pattern:**
* Command is behavioral design pattern that converts requests or simple operations into objects.

**UML Diagram**

The UML class diagram for the implementation of the command design pattern is given below:

![CommandUml](https://user-images.githubusercontent.com/39005871/79754761-a9976c80-8335-11ea-9ea8-8f9e425a9a2b.jpeg)


1.  Invoker  --> Asks the command to carry out the action
2.  Command --> This is an interface which specifies the execute operation
3.  Concrete Command --> Class that implements the execute operation by invoking on the receiver
4.  Receiver class --> Class that performs the Action Associated with the Request

**Command Pattern Example**

![CommandExampleDiagram](https://user-images.githubusercontent.com/39005871/79754784-b3b96b00-8335-11ea-8095-dcaa93358f3e.jpeg)



The classes, interfaces, and objects in the above class diagram can be identified as follows:

**Switch**- Invoker class.\
**ICommand** - Command interface.\
**FlipUpCommand and FlipDownCommand** - Concrete Command classes.\
**Light** - Receiver class.

**Here are the code blocks for each participant**
**1.Command**
```csharp
public interface ICommand
{
 void Execute();
}
```
**2.Invoker**
```csharp
public class Switch
{

 public void StoreAndExecute(ICommand command)
 {
 command.Execute();
 }
}
```
**3.Receiver**
```csharp
public class Light
{
 public void TurnOn()
 {
 Console.WriteLine("The light is on");
 }

 public void TurnOff()
 {
 Console.WriteLine("The light is off");
 }
}
```
**4.ConcreteCommand**

FlipUpCommand
```csharp
public class FlipUpCommand : ICommand
{
 private Light _light;

 public FlipUpCommand(Light light)
 {
 _light = light;
 }

 public void Execute()
 {
 _light.TurnOn();
 }
}
```

FlipDownCommand
```csharp
public class FlipDownCommand : ICommand
{
 private Light _light;

 public FlipDownCommand(Light light)
 {
 _light = light;
 }

 public void Execute()
 {
 _light.TurnOff();
 }
}
```
**Command Pattern Demo**
```csharp
class Program
{
 static void Main(string[] args)
 {
 Console.WriteLine("Enter Commands (ON/OFF) : ");
 string cmd = Console.ReadLine();

 Light lamp = new Light();
 ICommand switchUp = new FlipUpCommand(lamp);
 ICommand switchDown = new FlipDownCommand(lamp);

 Switch s = new Switch();

 if (cmd == "ON")
 {
 s.StoreAndExecute(switchUp);
 }
 else if (cmd == "OFF")
 {
 s.StoreAndExecute(switchDown);
 }
 else
 {
 Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
 }
 }
}
```


**A working Prototype of the code is available in the following link**
https://github.com/EzDevPrac/CSharp-Tereena/tree/master/CommandDesign


**Facade Design Pattern:**

Facade is a structural design pattern that provides a simplified interface to a library, a framework, or any other complex set of classes.

If we try to understand this in simpler terms, then we can say that a room is a façade and just by looking at it from outside the door, one can not predict what is inside the room and how the room is structured from inside. Thus, Façade is a general term for simplifying the outward appearance of a complex or large system.

In software terms, Facade pattern hides the complexities of the systems and provides a simple interface to the clients.

This pattern involves one wrapper class which contains a set of methods available for the client. This pattern is particularly used when a system is very complex or difficult to understand and when the system has multiple subsystems.

**Let’s see the below UML diagram**


Here, we can see that the client is calling the Façade class which interacts with multiple subsystems making it easier for the client to interact with them.

However, it is possible that façade may provide limited functionality in comparison to working with the subsystem directly, but it should include all those features which are actually required by the client. 

For example, When someone calls the restaurant, suppose, for ordering pizza or some other food, then the operator on behalf of the restaurant gives the voice interface which is actually the façade for their customers.

Customers place their orders just by talking to the operator and they don’t need to bother about how they will prepare the pizza, what all operations will they perform, on what temperature they will cook, etc. 

Similarly, in our code sample, we can see that the client is using the restaurant façade class to order pizza and bread of different types without directly interacting with the subclasses.

**CODE**

**This is the interface specific to the pizza.**

```csharp
public interface IPizza {  
    void GetVegPizza();  
    void GetNonVegPizza();  
}  
```

**This is a pizza provider class which will get pizza for their clients. Here methods can have other private methods which client is not bothered about.**
```csharp
public class PizzaProvider: IPizza {  
    public void GetNonVegPizza() {  
        GetNonVegToppings();  
        Console.WriteLine("Getting Non Veg Pizza.");  
    }  
    public void GetVegPizza() {  
        Console.WriteLine("Getting Veg Pizza.");  
    }  
    private void GetNonVegToppings() {  
        Console.WriteLine("Getting Non Veg Pizza Toppings.");  
    }  
}  
```

**Similarly, this is the interface specific for the bread.**
```csharp
public interface IBread {  
    void GetGarlicBread();  
    void GetCheesyGarlicBread();  
}  
```

**And this is a bread provider class.**
```csharp
public class BreadProvider: IBread {  
    public void GetGarlicBread() {  
        Console.WriteLine("Getting Garlic Bread.");  
    }  
    public void GetCheesyGarlicBread() {  
        GetCheese();  
        Console.WriteLine("Getting Cheesy Garlic Bread.");  
    }  
    private void GetCheese() {  
        Console.WriteLine("Getting Cheese.");  
    }  
}  
```
**Below is the restaurant façade class, which will be used by the client to order different pizzas or breads.**
```csharp
public class RestaurantFacade {  
    private IPizza _PizzaProvider;  
    private IBread _BreadProvider;  
    public RestaurantFacade() {  
        _PizzaProvider = new PizzaProvider();  
        _BreadProvider = new BreadProvider();  
    }  
    public void GetNonVegPizza() {  
        _PizzaProvider.GetNonVegPizza();  
    }  
    public void GetVegPizza() {  
        _PizzaProvider.GetVegPizza();  
    }  
    public void GetGarlicBread() {  
        _BreadProvider.GetGarlicBread();  
    }  
    public void GetCheesyGarlicBread() {  
        _BreadProvider.GetCheesyGarlicBread();  
    }  
}  
```
**Finally, below is the main method of our program**

```csharp
void Main() {  
    Console.WriteLine("----------------------CLIENT ORDERS FOR PIZZA----------------------------\n");  
    var facadeForClient = new RestaurantFacade();  
    facadeForClient.GetNonVegPizza();  
    facadeForClient.GetVegPizza();  
    Console.WriteLine("\n----------------------CLIENT ORDERS FOR BREAD----------------------------\n");  
    facadeForClient.GetGarlicBread();  
    facadeForClient.GetCheesyGarlicBread();  
}  
```
**Referance**

