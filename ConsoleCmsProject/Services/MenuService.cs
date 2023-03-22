using ConsoleCmsProject.Models;

namespace ConsoleCmsProject.Services
{
    internal class MenuService
    {
        public async Task CreateNewErrandAsync()
        {
            var customer = new Customer();

            Console.WriteLine("Create a new errand: ");
            Console.Write("Firstname: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.Write("Lastname: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.Write("Email address: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Phonenumber: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Streetname: ");
            customer.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postalcode: ");
            customer.Postalcode = Console.ReadLine() ?? "";

            Console.Write("City: ");
            customer.City = Console.ReadLine() ?? "";

            Console.Write("Title of the errand: ");
            customer.ErrandTitle = Console.ReadLine() ?? "";

            Console.Write("Description of the errand: ");
            customer.Description = Console.ReadLine() ?? "";
            Console.WriteLine("Select status:");
            Console.WriteLine(" 1 = Not started / 2 = Started / 3 = Completed: ");
            var inputanswer = Console.ReadLine();
            if (inputanswer == "1")
            {
                customer.Status = "Not started";
            }
            else if (inputanswer == "2")
            {
                customer.Status = "Started";
            }
            else if (inputanswer == "3")
            {
                customer.Status = "Completed";
            }
            Console.WriteLine("Errand saved.");

            await ErrandService.SaveAsync(customer);
        }

        public async Task ListAllErrandsAsync()
        {
            var customers = await ErrandService.GetAllAsync();

            if (customers.Any())
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($" Customer number: {customer.Id}");
                    Console.WriteLine($" Full name: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($" Email address: {customer.Email}");
                    Console.WriteLine($" Phonenumber: {customer.PhoneNumber}");
                    Console.WriteLine($" Full address: {customer.StreetName}, {customer.Postalcode} {customer.City}");
                    Console.WriteLine($" Title of the errand: {customer.ErrandTitle}");
                    Console.WriteLine($" Description of the errand: {customer.Description}");
                    Console.WriteLine($" Errand saved: {customer.CreatedAt}");
                    Console.WriteLine($" Status: {customer.Status}");
                    Console.WriteLine("");
                    Console.WriteLine($"{customer.UpdateComment} {customer.UpdatedAt}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("There are no cases in the database. ");
                Console.WriteLine("");
            }
        }

        public async Task ListSpecficErrandAsync()
        {
            Console.Write("Enter the email address of the customer you want to find errand from: ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var customer = await ErrandService.GetAsync(email);

                if (customer != null)
                {
                    Console.WriteLine($" Customer number: {customer.Id}");
                    Console.WriteLine($" Full name: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($" Email address: {customer.Email}");
                    Console.WriteLine($" Phonenumber: {customer.PhoneNumber}");
                    Console.WriteLine($" Full address: {customer.StreetName}, {customer.Postalcode} {customer.City}");
                    Console.WriteLine($" Title of the errand: {customer.ErrandTitle}");
                    Console.WriteLine($" Description of the errand: {customer.Description} ");
                    Console.WriteLine($" Created: {customer.CreatedAt}");
                    Console.WriteLine($" Status: {customer.Status}");
                    Console.WriteLine("");
                    Console.WriteLine($"{customer.UpdateComment} {customer.UpdatedAt}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"No customer with the email address {email} was found.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No email address specified");
            }
        }
        public async Task CommentSpecficErrandAsync()
        {
            Console.Write("Enter the email address of the errand you want to comment on: ");
            Console.WriteLine("");

            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var customer = await ErrandService.GetAsync(email);
                if (customer != null)
                {
                    Console.WriteLine("Comment on the current errand. ");
                    Console.Write($"Comment: ");

                    customer.UpdateComment = Console.ReadLine() ?? "";

                    Console.WriteLine($"{customer.UpdatedAt}");
                    Console.WriteLine("");
                    Console.WriteLine("Update status:");
                    Console.WriteLine(" 1 = Not started / 2 = Started / 3 = Completed: ");

                    var inputanswer = Console.ReadLine();
                    if (inputanswer == "1")
                    {
                        customer.Status = "Not started";
                    }
                    else if (inputanswer == "2")
                    {
                        customer.Status = "Started";
                    }
                    else if (inputanswer == "3")
                    {
                        customer.Status = "Completed";
                    }
                }
                await ErrandService.UpdateAsync(customer);
                Console.WriteLine("Updated");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No email address specified.");
            }
        }

        public async Task UpdateSpecficErrandAsync()
        {
            Console.Write("Enter the email address of the customer to change the information about the errand on: ");

            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                var customer = await ErrandService.GetAsync(email);

                if (customer != null)
                {

                    Console.WriteLine("Update the current field. \n");

                    Console.Write("Firstname: ");
                    customer.FirstName = Console.ReadLine() ?? "";

                    Console.Write("Lastname: ");
                    customer.LastName = Console.ReadLine() ?? "";

                    Console.Write("Email address: ");
                    customer.Email = Console.ReadLine() ?? "";

                    Console.Write("Phonenumber: ");
                    customer.PhoneNumber = Console.ReadLine() ?? "";

                    Console.Write("Streetname: ");
                    customer.StreetName = Console.ReadLine() ?? "";

                    Console.Write("Postalcode: ");
                    customer.Postalcode = Console.ReadLine() ?? "";

                    Console.Write("City: ");
                    customer.City = Console.ReadLine() ?? "";

                    Console.Write("Title of the errand: ");
                    customer.ErrandTitle = Console.ReadLine() ?? "";

                    Console.Write("Description of the errand: ");
                    customer.Description = Console.ReadLine() ?? "";

                    await ErrandService.UpdateAsync(customer);
                    Console.WriteLine("Updated");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No email address specified.");
            }
        }
        public async Task DeleteSpecficErrandAsync()
        {
            Console.Write("Enter the email address of the customer you want to delete the errand for: ");
            var email = Console.ReadLine();
            Console.WriteLine("Do you want to delete the errand linked to the email address " + email + " from the list? ");
            Console.Write("y = yes. n = no.");
            var inputanswer = Console.ReadLine();

            if (inputanswer == "y")
            {
                await ErrandService.DeleteAsync(email);
                Console.WriteLine("The errand has been removed");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No email address specified.");
            }
        }
    }
}