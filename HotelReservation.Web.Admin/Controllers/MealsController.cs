namespace HotelReservation.Web.Admin.Controllers
{
    using HotelReservation.Core.Contracts;
    using HotelReservation.Core.Entities;
    using HoteReservation.Web.Models.Meal;
    using HoteReservation.Web.Models.Room;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("meals")]
    public class MealsController : Controller
    {
        public readonly IMealRepository _mealRepository;

        public MealsController(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult Index()
        {
            var meals = _mealRepository.GetAllMeals();

            List<MealViewModel> mealsOutputModel = new List<MealViewModel>();

            foreach (var meal in meals)
            {
                mealsOutputModel.Add(new MealViewModel()
                {
                    Id = meal.Id,
                    Type = meal.Type,
                });
            }

            return View(mealsOutputModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MealInputModel model)
        {
            if (ModelState.IsValid)
            {

                var meal = Meal.New(model.Type);

                _mealRepository.AddMeal(meal);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [Route("{id}")]
        public IActionResult Edit(int id)
        {
            var meal = _mealRepository.GetMealById(id);

            var mealOutputModel = new MealViewModel()
            {
                Id = meal.Id,
                Type = meal.Type,
            };

            return View(mealOutputModel);
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MealViewModel model)
        {
            if (ModelState.IsValid)
            {
                var meal = _mealRepository.GetMealById(id);

                meal.Update(model.Type);

                _mealRepository.UpdateMeal();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [Route("{id}/delete")]
        public ActionResult Delete(int id)
        {
            var meal = _mealRepository.GetMealById(id);

            _mealRepository.DeleteMeal(meal);

            return RedirectToAction(nameof(Index));
        }
    }
}