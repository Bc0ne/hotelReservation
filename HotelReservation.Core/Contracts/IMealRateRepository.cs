using HotelReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Core.Contracts
{
    public interface IMealRateRepository
    {
        void AddMealRate(MealRate rate);
        ICollection<MealRate> GetAllMealRatesBySeasonId(long seasonId);
        ICollection<MealRate> GetAllMealRates();
        ICollection<Meal> GetMealsNotInSeasonById(long seasonId);
        MealRate GetMealRateBySeasonIdAndRoomId(long seasonId, long mealId);
        MealRate GetMealRateById(long id);
        void UpdateRate();
        void Delete(MealRate mealRate);
    }
}
