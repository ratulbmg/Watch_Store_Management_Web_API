using Watch_Store_Management_Web_API.DataAccessLayer.Entities;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Context
{
    public class SeedingInitialData
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    RoleName = "Customer"
                },
                new Role
                {
                    Id= 2,
                    RoleName = "Admin"
                }
            };
        }
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Smart Watch"
                },
                new Category
                {
                    Id = 2,
                    Name = "Digital Watch"
                },
                new Category
                {
                    Id = 3,
                    Name = "Analog Watch"
                }
            };
        }
        public static List<Brand> GetBrand()
        {
            return new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "Fastrack"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Casio"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Rolex"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Titan"
                },
                new Brand
                {
                    Id = 5,
                    Name = "Rado"
                },
                new Brand
                {
                    Id = 6,
                    Name = "Omega"
                },
                new Brand
                {
                    Id = 7,
                    Name = "Sonata"
                }
            };
        }
    }
}
