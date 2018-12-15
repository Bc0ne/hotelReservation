namespace HotelReservation.Core.Contracts
{
    using HotelReservation.Core.Entities;
    using System.Collections.Generic;

    public interface IMealRepository
    {
        ICollection<Meal> GetAllMeals();
        void AddMeal(Meal meal);
        Meal GetMealById(int id);
        void UpdateMeal();
    }
}
