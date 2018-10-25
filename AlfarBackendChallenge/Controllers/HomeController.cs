using AlfarBackendChallenge.EF.Models;
using AlfarBackendChallenge.Services.Interfaces;
using AlfarBackendChallenge.Web.ViewModels;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlfarBackendChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IAddressService _addressService;
        public readonly ICustomerService _customerService;
        public HomeController(IAddressService addressService, ICustomerService customerService)
        {
            _addressService = addressService;
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewAddress()
        {

            var addressViewModel = new AddressViewModel();
            return View(addressViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAddress(AddressViewModel adressViewModel)
        {
            if (ModelState.IsValid)
            {

                Address address = new Address()
                {
                    City = adressViewModel.City,
                    Country = adressViewModel.Country,
                    CreationTimeStamp = DateTime.Now,
                    Line1 = adressViewModel.Line1,
                    Line2 = adressViewModel.Line2,
                    Name = adressViewModel.Name,
                    PostalCode = adressViewModel.PostalCode,
                    Region = adressViewModel.Region,
                    Id=Guid.NewGuid ()
                };
                address = _addressService.InsertAddress(address);
                if (address != null)
                {
                     string displayMessage = "ADDRESSS SUCCESSFULLY CREATED";
                      TempData["_ViewSuccessMessage"] = displayMessage;

                }

                return RedirectToAction("NewCustomer");
            }
            return View(adressViewModel);
        }

        public ActionResult NewCustomer()
        {
            var addresses = _addressService.GetAll().ToList();
            var customerViewModel = new CustomerViewModel
            {
                Addresses = addresses
            };
            return View(customerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewCustomer(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var address = _addressService.GetByID(customerViewModel.AddressId);

                Customer customer = new Customer()
                {
                    EmailAddress = customerViewModel.EmailAddress,
                    PreferredName = customerViewModel.PreferredName,
                    Name = customerViewModel.Name,
                    CreationTimeStamp = DateTime.Now,
                    Id = Guid.NewGuid(),
                    Address = address,
                    Biography = customerViewModel.Biography,
                    DateOfBirth = customerViewModel.DateOfBirth,
                    JobTitle = customerViewModel.JobTitle,
                    Title = customerViewModel.Title
                };
                customer = _customerService.InsertCustomer(customer);
                if (customer != null)
                {
                    AddressViewModel adressViewModel = new AddressViewModel()
                    {
                        City = address.City,
                        Country = address.Country,
                        CreationTimeStamp = address.CreationTimeStamp,
                        Id = address.Id,
                        Line1 = address.Line1,
                        Line2 = address.Line2,
                        Name = address.Name,
                        PostalCode = address.PostalCode,
                        Region = address.Region
                    };
                    customerViewModel.Address = adressViewModel;
                    var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:14786/") };
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var httpResponseMessage =
                        await httpClient.PostAsJsonAsync("api/alert/SendAlert", customerViewModel);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        string stateInfo = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    }
                     string displayMessage = "CUSTOMER SUCCESSFULLY CREATED";
                      TempData["_ViewSuccessMessage"] = displayMessage;
                }

                return RedirectToAction("NewCustomer");
            }
            return View(customerViewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}