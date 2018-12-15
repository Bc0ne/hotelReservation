namespace HotelReservation.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Context;

    public class MealRepository : IMealRepository
    {
        private readonly ReservationContext _context;

        public MealRepository(ReservationContext context)
        {
            _context = context;
        }

        public void AddMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();
        }

        public ICollection<Meal> GetAllMeals()
        {
            return _context.Meals.ToList();
        }

        public Meal GetMealById(int id)
        {
            return _context.Meals.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateMeal()
        {
            _context.SaveChanges();
        }
    }
}
