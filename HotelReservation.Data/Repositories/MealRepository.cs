namespace HotelReservation.Data.Repositories
{
    using System;
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

        public Meal GetMealById(long id)
        {
            return _context.Meals.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Meal> GetMealsBySeasonDate(DateTime date)
        {
            var meals = _context.Meals
                .Where(r => _context.MealRates
               .Where(x => x.Season.StartingDate <= date && x.Season.EndingDate >= date)
               .Select(x => x.Meal.Id)
               .Contains(r.Id)).ToList();

            return meals;
        }

        public void UpdateMeal()
        {
            _context.SaveChanges();
        }

        public void DeleteMeal(Meal meal)
        {
            _context.Meals.Remove(meal);
            _context.SaveChanges();
        }

    }
}
