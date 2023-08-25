using EfExamples;
using System.ComponentModel;

var _context = new AppDbContext();

var custOrders = from c in _context.Customers
                 join o in _context.Orders
                 on c.Id equals o.CustomerId
                 join ol in _context.OrderLines
                 on o.Id equals ol.OrdersId
                 select new
                 {
                     OrderDate = o.Date,
                     o.Description,
                     ol.Product,
                     ol.Price,
                     ol.Quantity,
                     Customer = c.Name,
                     LineTotal = ol.Quantity * ol.Price
                     
                 };
custOrders.ToList().ForEach(c => Console.WriteLine($"{c.OrderDate:d} | {c.Description} | {c.Customer} | {c.Product} | {c.Price:C} | {c.Quantity} | {c.LineTotal:C} "));



/*
var customers = from c in _context.Customers
                where c.City ==  "Cincinnati"
                orderby c.Name
                select c;

 
//get all customer
//foreach(var cust in _context.Customers.ToList())
//{
//    Console.WriteLine(cust);
//e}

//get by primary key
Console.WriteLine(_context.Customers.Find(1));

// Insert Customer
//var newCust = new Customer() { Id = 0, Code = "JJIM", Name="Jungle Jims", City = "Fairfield", State = "OH", Sales = 5032.00m, Active = true };

//_context.Customers.Add(newCust);
//_context.SaveChanges();


var updateCustomer = _context.Customers.Find(58);
if (updateCustomer == null) return;
updateCustomer.Code = "JJIM";
//_context.Entry(updateCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
_context.SaveChanges();
Console.WriteLine(_context.Customers.Find(58));

// delete customer
int id = 46;
var deleCust = _context.Customers.Find(id);
if(deleCust == null) return;
_context.Remove(deleCust);
_context.SaveChanges();

foreach (var cust in _context.Customers.ToList())
{
    Console.WriteLine(cust);
}
*/
