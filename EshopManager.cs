using System;
using System.Collections.Generic;

public enum Model{
  Iphone,
  Ipad,
  AppleWatch
}


public class Gadget
{
  private int price;
  private Model model;
  private bool available;
  private List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();

  public Gadget(int price, Model model, bool available){
    this.price = price;
    this.model = model;
    this.available = available;
  }

  public void AddParameter(Tuple<string, object> parameter){
    parameters.Add(parameter);
  }
    
  public void PrintInfo(){
    Console.WriteLine("Model: " + model);
    Console.WriteLine("Availability: " + available);
    Console.WriteLine("Price: " + price);
    foreach(Tuple<string, object> parametr in parameters){
      Console.WriteLine(parametr.Item1 + ": " + parametr.Item2);
    }
  }
  
  
}


public class EshopManager
{
  private PriorityQueue<Gadget, int> Eshop = new PriorityQueue<Gadget, int>();
  
 public void AddIphone(int price, int RAM_size, bool available)
 {
   Gadget gadget = new Gadget(price, Model.Iphone, available);
   gadget.AddParameter(new Tuple<string, object>("RAM Size", RAM_size));
   Eshop.Enqueue(gadget, price);
 }
  
 public void AddIpad(int price, bool SIM_card, bool available){
   Gadget gadget = new Gadget(price, Model.Ipad, available);
   Tuple<string, object> tuple = new Tuple<string, object>("SIM Card Support", SIM_card);
   gadget.AddParameter(tuple);
   Eshop.Enqueue(gadget, price);
 }
 
 
 public void AddAppleWatch(int price, int display_size, bool available)
 {
   Gadget gadget = new Gadget(price, Model.AppleWatch, available);
   gadget.AddParameter(new Tuple<string, object>("Display Size", display_size));
   Eshop.Enqueue(gadget, price);
 }
  
 public void PrintTheCheapestItem()
 {
   if(Eshop.Count == 0){
     Console.WriteLine("Gadgets are not available");
     return;
   }
   Gadget gadget = Eshop.Dequeue();
   gadget.PrintInfo();
 }
}


class Program
{
    static void Main(string[] args)
    {
      EshopManager manager = new EshopManager();
      /*manager.AddIphone(100, 200, true);
      manager.AddIpad(60, true, false);
      manager.AddAppleWatch(200, 180, true);*/
      manager.PrintTheCheapestItem();
    }
}

