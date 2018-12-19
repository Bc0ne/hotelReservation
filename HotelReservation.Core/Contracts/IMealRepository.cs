namespace HotelReservation.Core.Contracts
{
    using HotelReservation.Core.Entities;
    using System;
    using System.Collections.Generic;

    public interface IMealRepository
    {
        ICollection<Meal> GetAllMeals();
        void AddMeal(Meal meal);
        Meal GetMealById(long id);
        void UpdateMeal();
        ICollection<Meal> GetMealsBySeasonDate(DateTime date);
        void DeleteMeal(Meal meal);
    }
}
