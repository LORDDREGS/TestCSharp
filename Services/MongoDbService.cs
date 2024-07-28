using MongoDB.Bson; // Добавьте этот using
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TestCSharp.Models;

namespace TestCSharp.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Plant> _plantsCollection;
        private readonly IMongoCollection<Department> _departmentsCollection;
        private readonly IMongoCollection<Position> _positionsCollection;
        private readonly IMongoCollection<User> _usersCollection;

        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var settings = mongoDbSettings.Value;
            var client = new MongoClient(settings.ConnectionString); 
            var database = client.GetDatabase(settings.DatabaseName); 

            _plantsCollection = database.GetCollection<Plant>("plants");
            _departmentsCollection = database.GetCollection<Department>("departments");
            _positionsCollection = database.GetCollection<Position>("positions");
            _usersCollection = database.GetCollection<User>("users");
        }

        // Plants
        public Task<List<Plant>> GetPlantsAsync() =>
            _plantsCollection.Find(_ => true).ToListAsync();

        public Task<Plant> GetPlantByIdAsync(string id) =>
            _plantsCollection.Find(plant => plant.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public Task CreatePlantAsync(Plant plant) =>
            _plantsCollection.InsertOneAsync(plant);

        public async Task UpdatePlantAsync(Plant plant)
        {
            await _plantsCollection.ReplaceOneAsync(p => p.Id == plant.Id, plant);
        }

        public async Task DeletePlantAsync(string id)
        {
            await _plantsCollection.DeleteOneAsync(plant => plant.Id == new ObjectId(id));
        }

        // Departments
        public Task<List<Department>> GetDepartmentsAsync() =>
            _departmentsCollection.Find(_ => true).ToListAsync();

        public Task<Department> GetDepartmentByIdAsync(string id) =>
            _departmentsCollection.Find(department => department.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public Task CreateDepartmentAsync(Department department) =>
            _departmentsCollection.InsertOneAsync(department);

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _departmentsCollection.ReplaceOneAsync(d => d.Id == department.Id, department);
        }

        public async Task DeleteDepartmentAsync(string id)
        {
            await _departmentsCollection.DeleteOneAsync(department => department.Id == new ObjectId(id));
        }

        // Positions
        public Task<List<Position>> GetPositionsAsync() =>
            _positionsCollection.Find(_ => true).ToListAsync();

        public Task<Position> GetPositionByIdAsync(string id) =>
            _positionsCollection.Find(position => position.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public Task CreatePositionAsync(Position position) =>
            _positionsCollection.InsertOneAsync(position);

        public async Task UpdatePositionAsync(Position position)
        {
            await _positionsCollection.ReplaceOneAsync(p => p.Id == position.Id, position);
        }

        public async Task DeletePositionAsync(string id)
        {
            await _positionsCollection.DeleteOneAsync(position => position.Id == new ObjectId(id));
        }

        // Users
        public Task<List<User>> GetUsersAsync() =>
            _usersCollection.Find(_ => true).ToListAsync();

        public Task<User> GetUserByIdAsync(string id) =>
            _usersCollection.Find(user => user.Id == new ObjectId(id)).FirstOrDefaultAsync();

        public Task CreateUserAsync(User user) =>
            _usersCollection.InsertOneAsync(user);

        public async Task UpdateUserAsync(User user)
        {
            await _usersCollection.ReplaceOneAsync(u => u.Id == user.Id, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _usersCollection.DeleteOneAsync(user => user.Id == new ObjectId(id));
        }
    }
}
