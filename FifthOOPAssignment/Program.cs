using FifthOOPAssignment;

class Program
{

    public static void Main(string[] args)
    {

        #region Theo. Questions 
        /* ===================== Q1: Object Copying =====================

        a) When  assign one object variable to another,
        both variables point to the same object in memory same address in stack.

        b) No, assigning one object to another does NOT create a new object.
        It only copies the reference in the stack.

        c) Copying an object means creating a new instance with the same data.
        Copying a reference means both variables refer to the same object.




        ===================== Q2: Shallow Copy vs Deep Copy =====================

        a) Shallow Copy: creates a new object but copies only simple values.
        Reference type members are not copied only their references.

        b) Deep Copy: creates a completely independent copy
        including all nested objects.

        c) In Shallow Copy reference-type members are shared
        between the original and the copy.

        d) In Deep Copy reference-type members are duplicated,
        so each object has its own separate data.

        e) Deep Copy is safer when you don't want changes in one object
        to affect another .

     


        ===================== Q3: Static Members =====================

        a) A static field is shared among all instances of a class,
        while an instance field belongs to each object separately.

        b) A static method belongs to the class itself.
        It cannot directly access instance members.

        c) A static constructor initializes static data.
        It runs only once when the class is first used.

        d) A static class cannot be instantiated (no objects can be created from it ).

     


       ===================== Q4: Extension Methods =====================

        a) An Extension Method allows adding new methods to an existing class
        without modifying its original code.

        b) The keyword (this) must be used in the first parameter.

        c) Extension methods must be declared inside a static class.

        d) No, extension methods cannot access private members of the class.

      


     ===================== Q5: Partial Classes and Partial Methods =====================

        a) A Partial Class allows splitting a class definition into multiple files.

        b) This helps organize code and allows multiple developers
        to work on the same class.

        c) A Partial Method can be declared in one part
        and implemented in another part of the partial class.

        d) If a partial method has no implementation,
        it is ignored and not executed.

        */
        #endregion
        #region test Main
        DeliveryUtilities.PrintSystemTitle();

        Console.WriteLine("Creating Shipments...");
        Console.WriteLine();

        DeliveryAddress addr1 = new DeliveryAddress("Cairo", "Tahrir", 15);
        DeliveryAddress addr2 = new DeliveryAddress("Giza", "Pyramids", 22);
        DeliveryAddress addr3 = new DeliveryAddress("Alex", "Corniche", 5);

        StandardShipment s1 = new StandardShipment("SH001", "Laptop", 3, 80, addr1);
        ExpressShipment s2 = new ExpressShipment("SH002", "Mobile Phone", 2, 60, addr2, 30);
        InternationalShipment s3 = new InternationalShipment("SH003", "Television", 8, 120, addr3, "Germany", 100);

        Console.WriteLine("Standard Shipment Created");
        Console.WriteLine("Express Shipment Created");
        Console.WriteLine("International Shipment Created");
        Console.WriteLine();

        Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Object Copying");
        Console.WriteLine();

        Shipment assigned = s1;
        Console.WriteLine($"Original Shipment : {s1.TrackingCode}");
        Console.WriteLine($"Assigned Shipment : {assigned.TrackingCode}");
        Console.WriteLine($"Same Object : {ReferenceEquals(s1, assigned)}");
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Shallow Copy");
        Console.WriteLine();

        StandardShipment shallow = (StandardShipment)s1.ShallowCopy();
        Console.WriteLine($"Original Shipment Address : {s1.Destination.City}");
        Console.WriteLine($"Copied Shipment Address   : {shallow.Destination.City}");
        Console.WriteLine();
        Console.WriteLine("Changing copied shipment address...");
        Console.WriteLine();

        shallow.Destination = new DeliveryAddress("Giza", "Pyramids", 22);

        Console.WriteLine($"Original Shipment Address : {s1.Destination.City}");
        Console.WriteLine($"Copied Shipment Address   : {shallow.Destination.City}");
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Deep Copy");
        Console.WriteLine();

        s1.Destination = new DeliveryAddress("Cairo", "Tahrir", 15);

        StandardShipment deep = (StandardShipment)s1.DeepCopy();
        Console.WriteLine($"Original Shipment Address : {s1.Destination.City}");
        Console.WriteLine($"Copied Shipment Address   : {deep.Destination.City}");
        Console.WriteLine();
        Console.WriteLine("Changing copied shipment address...");
        Console.WriteLine();

        deep.Destination = new DeliveryAddress("Giza", "Pyramids", 22);

        Console.WriteLine($"Original Shipment Address : {s1.Destination.City}");
        Console.WriteLine($"Copied Shipment Address   : {deep.Destination.City}");
        Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(s1.Destination, deep.Destination)}");
        Console.WriteLine();

        Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Extension Methods");
        Console.WriteLine();

        Console.WriteLine(s1.GetSummary());
        Console.WriteLine(s3.GetSummary());
        Console.WriteLine();
        Console.WriteLine($"s1 IsDelivered : {s1.IsDelivered()}");
        Console.WriteLine($"s3 IsDelivered : {s3.IsDelivered()}");
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Partial Method Demo");
        Console.WriteLine();

        s1.UpdateTrackingStatus("Out For Delivery");
        Console.WriteLine();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Assignment 04 Functionality Still Works");
        Console.WriteLine();

        DeliveryCenter center = new DeliveryCenter("Cairo Center");
        center.AddShipment(s1);
        center.AddShipment(s2);
        center.AddShipment(s3);
        center.PrintAllShipments();

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Done.");
    }
        #endregion

}
