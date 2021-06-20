using DubrovnikTours.Web.Views.Mappers;
using MarioTravel.Core.BLL.Services.Transfer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DubrovnikTours.Web.Controllers
{
    public class TransferController : Controller
    {
        private readonly TransferService transferService;
        private readonly TransferMapper transferMapper;

        public TransferController(TransferService transferService, TransferMapper transferMapper)
        {
            this.transferService = transferService ?? throw new ArgumentNullException(nameof(transferService));
            this.transferMapper = transferMapper ?? throw new ArgumentNullException(nameof(transferMapper));
        }

        public async Task<IActionResult> TransferBooking()
        {
            var transfer = await transferService.GetTransferAsync();

            if (transfer == null)
            {
                return RedirectToActionPermanent("Index", "Home");
            }

            var transferViewModel = transferMapper.ToTransferViewModel(transfer);
            return View(transferViewModel);
        }
    }
}