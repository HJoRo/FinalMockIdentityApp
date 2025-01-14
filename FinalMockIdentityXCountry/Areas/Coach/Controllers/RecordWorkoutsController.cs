﻿using FinalMockIdentityXCountry.Models;
using FinalMockIdentityXCountry.Models.DataLayer.Repositories.IRepository.Interfaces;
using FinalMockIdentityXCountry.Models.ViewModelHelperClasses;
using FinalMockIdentityXCountry.Models.ViewModels.CoachAreaViewModels;
using FinalMockIdentityXCountry.Models.ViewModels.CoachAreaViewModels.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace FinalMockIdentityXCountry.Areas.Coach.Controllers
{
    [Authorize(Roles = "Master Admin, Coach")]
    [Area("Coach")] 
    public class RecordWorkoutsController : Controller
    {
        private readonly XCountryDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; // the UserManager object in question

        public RecordWorkoutsController(XCountryDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectPractice()
        {
            
            IEnumerable<Practice> practices = _context.Practices.Where(p => p.PracticeIsInProgress == true && p.WorkoutsAddedToPractice == false);

            if (practices == null)
            {
                TempData["error"] = "There are no current practices with zero workouts assigned.";
                return RedirectToAction("Index");
            }

            practices = practices.OrderByDescending(x => x.PracticeStartTimeAndDate);

            return View(practices);
        }
         
        public IActionResult AddPracticeWorkouts(int practiceId)
        {

            List<AddPracticeWorkoutsViewModel> addPracticeWorkoutsViewModels = new List<AddPracticeWorkoutsViewModel>();

            IEnumerable<WorkoutType> workoutTypes = _context.WorkoutTypes;
            
            if (workoutTypes == null || workoutTypes.Count() < 1)
            {
                TempData["error"] = "There were no workout types found in the database. Contact an administrator";
                return RedirectToAction("Home"); // Send to an error page in the future
            }

            var dbQueries = (from a in _context.Attendances
                             join aspnetusers in _context.ApplicationUsers
                             on a.RunnerId equals aspnetusers.Id 
                             where a.PracticeId == practiceId && a.IsPresent 
                             select new
                             {
                                 aspnetusers.FirstName,
                                 aspnetusers.LastName,
                                 a.PracticeId,
                                 a.RunnerId 
                             });

            bool dbQueryFound = false;

            foreach (var dbQuery in dbQueries)
            {
                dbQueryFound = true;
                AddPracticeWorkoutsViewModel addPracticeWorkoutVm = new AddPracticeWorkoutsViewModel 
                {
                    PracticeId = dbQuery.PracticeId, RunnerId = dbQuery.RunnerId , RunnerName = $"{dbQuery.FirstName} {dbQuery.LastName}"
                };

                addPracticeWorkoutsViewModels.Add(addPracticeWorkoutVm);
            }

            if (dbQueryFound)
            {
                foreach (var vm in addPracticeWorkoutsViewModels)
                {
                    foreach (var workoutType in workoutTypes)
                    {
                        AddPracticeWorkoutCheckboxOptions addPracticeWorkoutCheckbox = new AddPracticeWorkoutCheckboxOptions
                        {
                            PracticeId = vm.PracticeId,
                            RunnerId = vm.RunnerId,
                            WorkoutType = workoutType,
                            WorkoutTypeId = workoutType.Id
                        };

                        vm.SelectedWorkoutCheckboxOptions?.Add(addPracticeWorkoutCheckbox);
                    }
                }
                return View(addPracticeWorkoutsViewModels);
            }
            else
            {
                TempData["error"] = "There was no data found with the provided query";
                return RedirectToAction("Index"); // return an invalid page (error in database query)
            } 
        }

        [HttpPost]
        public IActionResult AddPracticeWorkouts(List<AddPracticeWorkoutsViewModel> addPracticeWorkoutsViewModels, int practiceId)
        {
            if (addPracticeWorkoutsViewModels != null && practiceId != 0)
            {
                foreach (var addPracticeWorkoutVm in addPracticeWorkoutsViewModels)
                {
                    if (addPracticeWorkoutVm.SelectedWorkoutCheckboxOptions != null && addPracticeWorkoutVm.SelectedWorkoutCheckboxOptions.Count > 0)
                    {
                        foreach (var checkboxOptions in addPracticeWorkoutVm.SelectedWorkoutCheckboxOptions)
                        {
                            if (checkboxOptions.IsSelected && checkboxOptions.PracticeId != 0)
                            {
                                WorkoutInformation workoutInfo = new WorkoutInformation
                                {
                                    PracticeId = checkboxOptions.PracticeId, 
                                    WorkoutTypeId = checkboxOptions.WorkoutTypeId
                                };

                                try
                                {
                                    workoutInfo.RunnerId = checkboxOptions.RunnerId;
                                }
                                catch (Exception)
                                {
                                    TempData["error"] = "An Invalid runner id found";
                                    continue;
                                }
                                _context.WorkoutInformation.Add(workoutInfo);
                            }
                        }
                    }
                       
                }

                Practice practice = _context.Practices.Where(p => p.Id == practiceId).FirstOrDefault();

                if (practice == null)
                {
                    TempData["error"] = "Invalid practice provided";
                    return RedirectToAction(nameof(SelectPractice));
                };

                practice.WorkoutsAddedToPractice = true;
                _context.Practices.Update(practice);

                _context.SaveChanges();

                TempData["success"] = "The workout(s) were added to the practice successfully";
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index"); // return error in the future
        }
    }
}
