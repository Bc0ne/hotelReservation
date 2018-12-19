namespace HotelReservation.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HotelReservation.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public class MealRateRepository : IMealRateRepository
    {
        private readonly ReservationContext _context;

        public MealRateRepository(ReservationContext context)
        {
            _context = context;
        }

        public void AddMealRate(MealRate rate)
        {
            _context.MealRates.Add(rate);
            _context.SaveChanges();
        }

        public ICollection<MealRate> GetAllMealRates()
        {
            return _context
                .MealRates
                .Include(x => x.Meal)
                .Include(x => x.Season)
                .OrderBy(x => x.MealId).ToList();
        }

        public ICollection<MealRate> GetAllMealRatesBySeasonId(long seasonId)
        {
            return _context
                .MealRates
                .Include(x => x.Meal)
                .Include(x => x.Season)
                .Where(x => x.SeasonId == seasonId)
                .OrderBy(x => x.MealId).ToList();
        }

        public MealRate GetMealRateBySeasonIdAndRoomId(long seasonId, long mealId)
        {
            return _context.MealRates.Where(x => x.SeasonId == seasonId && x.MealId == mealId).FirstOrDefault();
        }

        public ICollection<Meal> GetMealsNotInSeasonById(long seasonId)
        {
            var meals = _context.Meals
                .Where(r => !_context.MealRates
               .Where(x => x.SeasonId == seasonId)
               .Select(x => x.Meal.Id)
               .Contains(r.Id)).ToList();

            return meals;
        }

        public void UpdateRate()
        {
            _context.SaveChanges();
        }

        public void Delete(MealRate mealRate)
        {
            _context.MealRates.Remove(mealRate);
            _context.SaveChanges();
        }

        public MealRate GetMealRateById(long id)
        {
            return _context.MealRates.FirstOrDefault(x => x.Id == id);
        }
    }
}
