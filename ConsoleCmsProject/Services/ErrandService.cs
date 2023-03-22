using ConsoleCmsProject.Contexts;
using ConsoleCmsProject.Models;
using ConsoleCmsProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleCmsProject.Services
{
    internal class ErrandService
    {
        private static readonly DataContext _context = new DataContext();
        public static async Task SaveAsync(Customer customer)
        {
            var _customerEntity = new CustomerEntity
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };
            var _errandEntity = await _context.Errands.FirstOrDefaultAsync(x => x.ErrandTitle == customer.ErrandTitle && x.Description == customer.Description);
            if (_errandEntity != null)
                _customerEntity.ErrandId = _errandEntity.Id;
            else
                _customerEntity.Errands = new ErrandEntity
                {
                    ErrandTitle = customer.ErrandTitle,
                    Description = customer.Description,
                    CreatedAt = DateTime.UtcNow,
                };
            var _adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.SteetName == customer.StreetName && x.PostalCode == customer.Postalcode && x.City == customer.City);
            if (_adressEntity != null)
                _customerEntity.AddressId = _adressEntity.Id;
            else
                _customerEntity.Addresses = new AddressEntity
                {
                    SteetName = customer.StreetName,
                    PostalCode = customer.Postalcode,
                    City = customer.City,
                };

            var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.UpdateComment == customer.UpdateComment && x.UpdatedAt == customer.UpdatedAt && x.Status == customer.Status);
            if (_commentEntity != null)
                _customerEntity.CommentsId = _commentEntity.Id;
            else
                _customerEntity.Comments = new CommentEntity
                {
                    UpdateComment = customer.UpdateComment,
                    UpdatedAt = DateTime.UtcNow,
                    Status = customer.Status,
                };


            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var _customers = new List<Customer>();

            foreach (var _customer in await _context.Customers.Include(x => x.Errands).ThenInclude(x => x.Addresses).Include(x => x.Comments).ToListAsync())

                _customers.Add(new Customer

                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    ErrandTitle = _customer.Errands.ErrandTitle,
                    Description = _customer.Errands.Description,
                    CreatedAt = DateTime.Now,
                    UpdateComment = _customer.Comments.UpdateComment,
                    Status = _customer.Comments.Status,
                    UpdatedAt = DateTime.Now,
                    StreetName = _customer.Addresses.SteetName,
                    Postalcode = _customer.Addresses.PostalCode,
                    City = _customer.Addresses.City,
                });
            return _customers;
        }


        public static async Task<Customer> GetAsync(string email)
        {
            var _customer = await _context.Customers.Include(x => x.Errands).ThenInclude(x => x.Addresses).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);
            if (_customer != null)
                return new Customer
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    ErrandTitle = _customer.Errands.ErrandTitle,
                    Description = _customer.Errands.Description,
                    CreatedAt = DateTime.Now,
                    UpdateComment = _customer.Comments.UpdateComment,
                    UpdatedAt = DateTime.Now,
                    StreetName = _customer.Addresses.SteetName,
                    Postalcode = _customer.Addresses.PostalCode,
                    City = _customer.Addresses.City,
                    Status = _customer.Comments.Status,
                };
            else
                return null!;
        }

        public static async Task UpdateAsync(Customer customer)
        {
            var _customerEntity = await _context.Customers.Include(x => x.Errands).FirstOrDefaultAsync(x => x.Id == customer.Id);
            if (_customerEntity != null)
            {
                if (!string.IsNullOrEmpty(customer.FirstName)) _customerEntity.FirstName = customer.FirstName;
                if (!string.IsNullOrEmpty(customer.LastName)) _customerEntity.LastName = customer.LastName;
                if (!string.IsNullOrEmpty(customer.Email)) _customerEntity.Email = customer.Email;
                if (!string.IsNullOrEmpty(customer.PhoneNumber)) _customerEntity.PhoneNumber = customer.PhoneNumber;

                if (!string.IsNullOrEmpty(customer.ErrandTitle) || !string.IsNullOrEmpty(customer.Description) || !string.IsNullOrEmpty(customer.UpdateComment) || !string.IsNullOrEmpty(customer.Status))
                    if (!string.IsNullOrEmpty(customer.StreetName) || !string.IsNullOrEmpty(customer.Postalcode) || !string.IsNullOrEmpty(customer.City))
                    {

                        var _commentEntity = await _context.Comments.FirstOrDefaultAsync(x => x.UpdateComment == customer.UpdateComment && x.UpdatedAt == customer.UpdatedAt && x.Status == customer.Status);
                        if (_commentEntity != null)
                            _customerEntity.CommentsId = _commentEntity.Id;
                        else
                            _customerEntity.Comments = new CommentEntity
                            {
                                UpdateComment = customer.UpdateComment,
                                UpdatedAt = DateTime.UtcNow,
                                Status = customer.Status,

                            };
                        var _errandEntity = await _context.Errands.FirstOrDefaultAsync(x => x.ErrandTitle == customer.ErrandTitle && x.Description == customer.Description);
                        if (_errandEntity != null)
                            _customerEntity.ErrandId = _errandEntity.Id;
                        else
                            _customerEntity.Errands = new ErrandEntity
                            {
                                ErrandTitle = customer.ErrandTitle,
                                Description = customer.Description,
                                CreatedAt = DateTime.Now,
                            };
                        var _adressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.SteetName == customer.StreetName && x.PostalCode == customer.Postalcode && x.City == customer.City);
                        if (_adressEntity != null)
                            _customerEntity.AddressId = _adressEntity.Id;

                        else
                            _customerEntity.Addresses = new AddressEntity
                            {
                                SteetName = customer.StreetName,
                                PostalCode = customer.Postalcode,
                                City = customer.City,
                            };
                    }
                _context.Update(_customerEntity);
                await _context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(string email)
        {
            var customer = await _context.Customers.Include(x => x.Errands).ThenInclude(x => x.Addresses).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Email == email);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
